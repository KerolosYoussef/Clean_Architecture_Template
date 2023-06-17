# Clean Architecture Template for .NET Core 7

This is a template project for .NET Core 7 using Clean Architecture principles. It provides a starting point for building your own .NET Core 7 applications using the Clean Architecture pattern.

## Technologies

This template uses the following technologies:

- .NET Core 7
- Entity Framework Core 6
- MediatR
- AutoMapper
- Fluent Validation
- Serilog
- Swagger

## Getting Started

To get started with this template, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution file (CleanArchitectureTemplate.sln) in Visual Studio or another compatible IDE.
3. Run the application using the debugger or by pressing F5.
4. The application should launch in your default web browser to view the Swagger UI.

## Project Structure

This template follows the Clean Architecture pattern, which promotes separation of concerns and testability. The project is structured as follows:

- Api: This project contains the API controllers and the Swagger configuration.
- Application: This project contains the application logic, including commands, queries, and handlers.
- Domain: This project contains the domain models and interfaces.
- Infrastructure: This project contains the implementation of the interfaces defined in the domain layer, including database context, repositories, and other services.
