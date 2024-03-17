# VSBlog

VSBlog is a blogging platform built with .NET 8.0, using a modular monolith architecture.

## Project Structure

The project is structured into several folders, each representing a different aspect of the application:

- `Data/`: Contains the `ApplicationDbContext` class, which is responsible for interacting with the database using Entity Framework Core.
- `Features/`: Contains the business logic for the application, divided into different modules (Articles and Comments). Each module has its own Controller, Commands, Queries, and Models.
- `Helpers/`: Contains helper classes, such as `MappingProfile` for AutoMapper configurations.
- `Migrations/`: Contains Entity Framework Core migrations.

## Architecture

VSBlog uses a "vertical slice" or "modular monolith" architecture. This means that instead of dividing the application into layers (e.g., data access, business logic, UI), it's divided into vertical slices or modules. Each module corresponds to a specific feature or business capability, and contains all the necessary code for that feature, from the database to the UI.

This architecture has several benefits:

- **Cohesion**: All the code related to a specific feature is located in the same place.
- **Decoupling**: Changes in one module are less likely to affect others.
- **Scalability**: It's easy to add new features by simply adding new modules.

## Getting Started

To get started with VSBlog, you'll need .NET 8.0 and a SQLite database. Once you have these, you can run the application using the `dotnet run` command.

## License

VSBlog is licensed under the [MIT License](#).
