# EJADA E-Invoice Middleware

E-Invoice Middleware is a system that enables integration with SAP, POS Systems, and RMS to get invoices, debit notes, or credit notes and send them to the Invoice Portal (ZATCA or Egyptian invoice portal). It also includes APIs that allow customers to integrate with it and send invoices, debit notes, or credit notes or retrieve them.

## Technologies

- .NET Core 6
- Angular 14
- SQL Server
- Entity Framework Core
- MediatR
- AutoMapper
- Swagger

## Features

- Integration with SAP, POS Systems, and RMS
- Send invoices, debit notes, or credit notes to the Invoice Portal
- APIs for customers to send or retrieve invoices, debit notes, or credit notes
- Authentication and Authorization
- Audit trail logging
- Exception handling and error reporting
- Swagger API documentation

## Getting Started

### Prerequisites

- .NET Core 6 SDK
- Node.js and npm
- SQL Server

## Usage

The application consists of two main parts: the server-side API and the client-side web application. The server-side API provides endpoints for sending and retrieving invoices, debit notes, and credit notes. The client-side web application provides a user interface for interacting with the API.

### Server-side API

The server-side API is built using .NET Core 6 and exposes RESTful endpoints for sending and retrieving invoices, debit notes, and credit notes. The API is secured using authentication and authorization. Swagger is used for API documentation.

### Client-side Web Application

The client-side web application is built using Angular 14 and provides a user interface for interacting with the server-side API. The web application includes forms for sending invoices, debit notes, and credit notes and tables for retrieving them.

