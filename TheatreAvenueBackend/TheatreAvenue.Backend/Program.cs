using System;  // Importing the System namespace
using Microsoft.AspNetCore;  // Importing the Microsoft.AspNetCore namespace
using Microsoft.AspNetCore.Hosting;  // Importing the Microsoft.AspNetCore.Hosting namespace
using Newtonsoft.Json;  // Importing the Newtonsoft.Json namespace

namespace TheatreAvenue.Backend  
{
    public class Program  
    {
        public static void Main(string[] args)  
        {
            // NLog: setup the logger first to catch all errors
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();  // Configuring NLog logger using the "nlog.config" file and getting the logger instance for the current class

            try  // Starting a try block to catch any exceptions
            {
                logger.Debug("init main");  // Logging a debug message using NLog
                Console.WriteLine("ARGS should be an empty string");  // Writing a message to the console
                Console.WriteLine(JsonConvert.SerializeObject(args));  // Writing the serialized JSON string of the args array to the console using Newtonsoft.Json
                CreateWebHostBuilder(args).Build().Run();  // Building and running the web host using the CreateWebHostBuilder method and the provided args array
            }
            catch (Exception ex)  // Catching any unhandled exceptions and passing them to the catch block
            {
                //NLog: catch setup errors
                logger.Error(ex, "Stopped program because of exception");  // Logging an error message using NLog and passing the exception object as a parameter
                throw;  // Rethrowing the exception to propagate it further up the call stack
            }
            finally  // Starting a finally block to execute some code before exiting the method
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();  // Shutting down the NLog logger to avoid any segmentation faults on Linux
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>  // Defining a public static method named CreateWebHostBuilder that takes an array of string arguments named args and returns an IWebHostBuilder object
            WebHost.CreateDefaultBuilder(args)  // Creating a default web host builder using the provided args array
                .UseStartup<Startup>();  // Configuring the web host builder to use the Startup class as the application startup class
    }
}

//This code sets up a web host using ASP.NET Core, logs any errors using NLog, and catches and handles any unhandled exceptions using a try-catch-finally block. 
//It also defines a method for creating the web host builder and specifies the Startup class as the application startup class.