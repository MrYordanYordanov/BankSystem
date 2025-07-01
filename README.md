# BankSystem
Banking System Reporting API
This project is a RESTful API for a banking system that allows for importing transactions from XML, exporting entities to CSV, and querying data through a structured API. 
The system is built with .NET 8, C#, and follows Clean Architecture principles using MediatR and the Repository Pattern.

Architectural Design
The solution is built following the principles of Clean Architecture. This separates the project into several layers, each with a distinct responsibility.
Domain: Contains the core business entities (Partner, Merchant, Transaction) and enums. This layer has no dependencies on any other layer.
Infrastructure: Handles all external concerns. This includes the database implementation (DbContext, repositories, migrations) and any other interaction with outside systems. It depends on the Domain layer.
Application (BankSystem project): This is the core of the application. It contains the business logic, CQRS handlers (using MediatR), DTOs, AutoMapper profiles, and service interfaces. It depends on Domain and the repository interfaces defined in Infrastructure.
Presentation (Controllers): The API Controllers are kept thin, with their only job being to receive HTTP requests, send a command or query to MediatR, and return the result.
This project also implements the CQRS (Command Query Responsibility Segregation) pattern using the MediatR library to decouple the API controllers from the business logic handlers.
Technology Stack
Framework: .NET 8
Language: C# 12
Database: PostgreSQL
ORM: Entity Framework Core 8
API: ASP.NET Core Web API
Design Patterns:
Clean Architecture
CQRS with MediatR
Repository and Unit of Work Pattern
Dependency Injection
Libraries:
MediatR: For implementing the CQRS pattern.
AutoMapper: For mapping between entities and DTOs.
CsvHelper: For generating CSV files.
ClosedXML (Optional, if Excel export is added).
Npgsql: PostgreSQL provider for EF Core.

API Endpoints
All endpoints are available under the /api prefix.
Partners
GET /api/partners
Retrieves a paginated list of all partners, including their nested merchants.
Query Parameters: pageNumber (int), pageSize (int).
Merchants
GET /api/merchants
Retrieves a paginated list of all merchants, including their nested transactions.
Query Parameters: pageNumber (int), pageSize (int).
Transactions
GET /api/transactions
Retrieves a paginated and filtered list of transactions.
Query Parameters:
pageNumber (int)
pageSize (int)
startDate (datetime, e.g., 2023-01-01)
endDate (datetime)
minAmount (decimal)
maxAmount (decimal)
direction (string: Debit or Credit)
status (string: Successful or Failed)
POST /api/transactions/import/{merchantId}
Imports transactions for a specific merchant from an XML file.
Request Body: multipart/form-data with a key file containing the XML file.
URL Parameter: merchantId (int) - The ID of the merchant to assign the transactions to.
Export
GET /api/export/partners
Downloads a CSV file containing all partners.
GET /api/export/merchants
Downloads a CSV file containing all merchants.
GET /api/export/transactions
Downloads a CSV file containing all transactions with their related merchant and partner info.
Project Structure
The solution is organized into the following projects:
BankSystem: The main ASP.NET Core Web API project. Contains Controllers, MediatR handlers, DTOs, AutoMapper profiles, and the Program.cs startup file. This is the Application & Presentation Layer.
Domain: A class library containing the core business entities (Partner.cs, Merchant.cs, Transaction.cs) and enums.
Infrastructure: A class library responsible for data access. Contains the BankingDbContext, EF Core migrations, and Repository implementations.
Dtos: (Optional) A dedicated class library for Data Transfer Objects.
Services: (Optional) A dedicated class library for business service interfaces and implementations.
