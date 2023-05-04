using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using TheatreAvenue.Database;
using TheatreAvenue.Models.Interfaces;
using TheatreAvenue.Repository;
using TheatreAvenue.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TheatreAvenue.ML.Recommendations.Interfaces;
using TheatreAvenue.ML.Recommendations;

namespace TheatreAvenue.Backend
{
    public class Startup
    {
        public Startup()
        {
            // Gets the environment variable "Env" and sets it to "local" if it is null
            var environment = Environment.GetEnvironmentVariable("Env") ?? "local";

            // Prints the environment variable to the console
            Console.WriteLine($"Environment: {environment}");

            // Builds the configuration settings for the application
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                .AddUserSecrets<Startup>()
                .AddEnvironmentVariables();

            // Builds the configuration object using the above settings
            Configuration = builder.Build();
        }

        // Gets the configuration object for the application
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Gets the database connection string from the configuration settings
            string dbConnectionString = Configuration["Database:ConnectionString"];

            // Prints the database connection string to the console
            Console.WriteLine("dbConnectionString");
            Console.WriteLine(dbConnectionString);

            // Builds the options for the database context using the connection string
            DbContextOptionsBuilder<TheatreAvenueDbContext> opt = new DbContextOptionsBuilder<TheatreAvenueDbContext>();
            DataSeeder.SeedData(new TheatreAvenueDbContext(opt.UseSqlServer(dbConnectionString).Options));
            opt.UseSqlServer(dbConnectionString);

            // Adds the database context to the services container with transient lifetime
            services.AddDbContext<TheatreAvenueDbContext>(options => options.UseSqlServer(dbConnectionString), ServiceLifetime.Transient);

            // Adds controllers to the services container
            services.AddControllers();

            // Adds Mvc to the services container with endpoint routing disabled
            services.AddMvc(options => options.EnableEndpointRouting = false);

            // Adds ApiExplorer endpoints to the services container
            services.AddEndpointsApiExplorer();

            // Adds Swagger documentation generator to the services container
            services.AddSwaggerGen();

            // Sets up JWT authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    // Sets the symmetric security key for JWT authentication
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JWTSecretKey"))
                    )
                };
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            // Adds user repository to the services container with scoped lifetime
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVenueRepository, VenueRepository>();
            services.AddScoped<ITheatreAvenueRepository, TheatreAvenueRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();

            // Adds logger service to the services container with singleton lifetime
            services.AddSingleton<ILoggerService, LoggerService>();

            services.AddSingleton<IReccomenedTheatres, RecommenedTheatres>();
            services.AddSingleton<IReccomenedSeats, RecommenedSeats>();

            // Adds authentication service to the services container with singleton lifetime
            services.AddSingleton<IAuthService>(
                new AuthService(
                    Configuration.GetValue<string>("JWTSecretKey"),
                    Configuration.GetValue<int>("JWTLifespan")
                ));

            // Adds Mvc to the services container
            services.AddMvc();

            // Adds a CORS policy to the services container
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enables

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors();

            app.UseStaticFiles();//Enables serving static files like images, CSS, and JavaScript from the application's wwwroot folder.

            app.UseSwagger(); //Configures Swagger middleware to generate Swagger JSON and a Swagger UI for the API.

            app.UseSwaggerUI(); //Sets up a middleware to serve Swagger UI.

            app.UseCors("CorsPolicy"); // Adds a CORS policy named CorsPolicy to the application's request pipeline. This allows cross-origin requests from any source.
            
            app.UseHttpsRedirection(); //Enables HTTP to HTTPS redirection for secure communication.
            
            app.UseAuthorization(); //Adds authorization middleware to the pipeline.

            app.UseAuthentication(); // Enables authentication for the application.

            app.UseMvc(); //Adds MVC middleware to the pipeline.
        }
    }
}
