# TheatreAvenue Project

The TheatreAvenue project is a web application that provides users with information about different theatre productions. The project consists of three main components: a backend written in C# ASP.NET, a frontend written in React, and a database that stores all the necessary data. The database creation is implemented using EF Core and MSSQL.

## Components

### TheatreAvenueBackend

The TheatreAvenueBackend is the main component of the project, responsible for handling the application's logic and serving data to the frontend. It is written in ASP.NET and utilizes the Entity Framework Core to interact with the database. 

Link: [TheatreAvenueBackend](https://github.com/Tencho0/TheatreAvenue/tree/main/TheatreAvenueBackend)

### TheatreAvenueFrontend

The TheatreAvenueFrontend is the user-facing component of the project, responsible for displaying information to the user and handling user interactions. It is written in React and communicates with the backend using HTTP requests. For the frontend, we use Husky for Git hooks, Yarn as the package manager, and Axios for HTTP requests.

Link: [TheatreAvenueFrontend](https://github.com/Tencho0/TheatreAvenue/tree/main/TheatreAvenueFrontend)

### TheatreAvenueDatabaseData

The TheatreAvenueDatabaseData file contains the data that is used to populate the database. It includes information about different theatre productions, such as the title, description, cast, and performance dates.

Link: [TheatreAvenueDatabaseData](https://github.com/Tencho0/TheatreAvenue/tree/main/TheatreAvenueDatabaseData)

## Getting Started

To get started with the TheatreAvenue project, you will need to have the following tools installed:

- Visual Studio or Visual Studio Code
- Node.js
- Microsoft SQL Server Management Studio

After installing the necessary tools, follow these steps to set up the project:

1. Clone the repository to your local machine.
2. Open the TheatreAvenueBackend folder in Visual Studio or Visual Studio Code and build the solution.
3. Open the TheatreAvenueFrontend folder in your preferred text editor and run the command `yarn install` to install the necessary dependencies.
4. Create a new database in Microsoft SQL Server Management Studio and update the connection string in the appsettings.json file in the TheatreAvenueBackend folder to reflect your database.
5. Run the Entity Framework Core migration command to create the necessary tables in the database.
6. Load the data from the TheatreAvenueDatabaseData file into the database using the Entity Framework Core command-line interface.

Once you have completed these steps, you should be able to run the application by starting the backend server and the frontend server.

## Contributing

Contributions to the TheatreAvenue project are welcome. If you notice any issues or have any ideas for improvements, please feel free to open an issue or submit a pull request.

## License

The TheatreAvenue project is licensed under the MIT license. See the LICENSE file for more details.
