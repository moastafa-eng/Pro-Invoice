# ProInvoice

### A Clean Architecture–Based Invoice Management REST API built with ASP.NET Core 8

<p align="center">
  <strong>ProInvoice</strong> is a backend application designed to manage customers, products, and invoices through a RESTful API. It follows Clean Architecture principles and incorporates CQRS, Domain Events, and the Transactional Outbox Pattern to promote maintainability, separation of concerns, and reliable event processing.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet" alt=".NET 8" />
  <img src="https://img.shields.io/badge/ASP.NET%20Core-Web%20API-512BD4?logo=dotnet" alt="ASP.NET Core" />
  <img src="https://img.shields.io/badge/Architecture-Clean%20Architecture-blue" alt="Clean Architecture" />
  <img src="https://img.shields.io/badge/Database-SQL%20Server-CC2927?logo=microsoftsqlserver" alt="SQL Server" />
  <img src="https://img.shields.io/badge/Cache-Redis-DC382D?logo=redis" alt="Redis" />
  <img src="https://img.shields.io/badge/Container-Docker-2496ED?logo=docker" alt="Docker" />
</p>

---

## Table of Contents

- [Overview](#overview)
- [Key Features](#key-features)
- [Architecture](#architecture)
- [Technology Stack](#technology-stack)
- [Project Structure](#project-structure)
- [API Endpoints](#api-endpoints)
- [Getting Started](#getting-started)
- [Running with Docker](#running-with-docker)
- [Configuration](#configuration)
- [API Documentation](#api-documentation)
- [Health Checks](#health-checks)
- [Future Improvements](#future-improvements)

---

## Overview

ProInvoice is a backend-focused invoice management system built using ASP.NET Core 8.

The application provides core business operations for managing customers, products, and invoices, with authentication and authorization mechanisms.

The project is structured around Clean Architecture, keeping business logic independent from infrastructure concerns and making the application easier to maintain, extend, and test.

It also implements several backend architectural patterns, including:

- CQRS for separating commands and queries.
- Domain Events for handling business-related events.
- Transactional Outbox Pattern for reliable event processing.
- Repository Pattern and Unit of Work for data access abstraction.
- Pipeline Behaviors for cross-cutting concerns.

## Key Features

### Authentication & Authorization
- User registration and login.
- JWT-based authentication infrastructure.
- Refresh token handling.
- Token revocation.
- Role-based authorization for protected operations.
- ASP.NET Core Identity integration.

### Customer Management
- Create customers.
- Retrieve a customer by ID.
- Retrieve all customers.
- Update customer information.
- Remove customers.

### Product Management
- Create products.
- Retrieve a product by ID.
- Retrieve all products.
- Update product information.
- Remove products.

### Invoice Management
- Create invoices associated with customers.
- Add purchased products to invoices.
- Calculate invoice totals based on product prices and quantities.
- Retrieve an invoice by ID.
- Retrieve all invoices.
- Update invoice information.
- Remove invoices.

### Application Infrastructure
- Global exception handling middleware.
- Request context logging.
- Structured logging using Serilog.
- Centralized logging with Seq.
- Redis caching infrastructure.
- SQL Server health checks.
- Redis health checks.
- Background job processing using Quartz.NET.
- API versioning.
- Swagger / OpenAPI integration.

### Reliable Event Processing
- Domain Events for important business operations.
- Transactional Outbox Pattern.
- Background processing of pending outbox messages.
- Event dispatching through MediatR.

---

## Architecture

The solution follows **Clean Architecture**, separating the application into four independent layers.

```text
                ProInvoice.API
                     |
                     v
             ProInvoice.Application
                     |
                     v
               ProInvoice.Domain
                     ^
                     |
          ProInvoice.Infrastructure
```

### 1. ProInvoice.API

The presentation layer responsible for:

- RESTful API endpoints.
- Controllers and HTTP request handling.
- API versioning.
- Swagger configuration.
- Middleware registration.
- Dependency injection composition.

### 2. ProInvoice.Application

The application layer contains:

- Business use cases.
- Commands and Queries.
- Command and Query Handlers.
- Application abstractions.
- MediatR pipeline behaviors.
- Mapping configurations.
- Application-level event handlers.

### 3. ProInvoice.Domain

The core business layer containing:

- Domain entities.
- Value Objects.
- Domain Events.
- Business rules and validations.
- Domain exceptions.
- Repository and Unit of Work abstractions.

### 4. ProInvoice.Infrastructure

The infrastructure layer provides implementations for:

- Entity Framework Core.
- SQL Server database access.
- Repository Pattern.
- Unit of Work.
- Redis caching.
- JWT token services.
- ASP.NET Core Identity.
- Outbox message persistence.
- Quartz background jobs.
- Health checks.

---

## Technology Stack

| Technology | Purpose |
|---|---|
| C# / .NET 8 | Backend development |
| ASP.NET Core Web API | RESTful API |
| Entity Framework Core | ORM and data access |
| SQL Server | Relational database |
| ASP.NET Core Identity | User management |
| JWT | Authentication infrastructure |
| MediatR | CQRS and request handling |
| AutoMapper | Object mapping |
| Redis | Distributed caching |
| Serilog | Structured logging |
| Seq | Centralized log monitoring |
| Quartz.NET | Background job scheduling |
| Docker & Docker Compose | Containerization |
| Swagger / OpenAPI | API documentation |

---

## Project Structure

```text
ProInvoice/
│
├── src/
│   │
│   ├── ProInvoice.API/
│   │   ├── Controllers/
│   │   │   ├── Version1/
│   │   │   │   ├── Authentication/
│   │   │   │   ├── Customers/
│   │   │   │   ├── Invoices/
│   │   │   │   └── Products/
│   │   ├── Extensions/
│   │   ├── Filters/
│   │   ├── Middlewares/
│   │   ├── OpenApi/
│   │   └── Program.cs
│   │
│   ├── ProInvoice.Application/
│   │   ├── Abstraction/
│   │   │   ├── Behaviours/
│   │   │   ├── Caching/
│   │   │   ├── Emailing/
│   │   │   └── Messaging/
│   │   └── Features/
│   │       ├── Customers/
│   │       ├── Invoices/
│   │       ├── Products/
│   │       └── Identity/
│   │
│   ├── ProInvoice.Domain/
│   │   ├── Abstraction/
│   │   ├── Entities/
│   │   │   ├── Customers/
│   │   │   ├── Invoices/
│   │   │   ├── InvoiceItems/
│   │   │   ├── Products/
│   │   │   └── Identity/
│   │   ├── Exceptions/
│   │   └── ValueObjects/
│   │
│   └── ProInvoice.Infrastructure/
│       ├── Configurations/
│       ├── Migrations/
│       ├── Outbox/
│       ├── Repositories/
│       ├── Services/
│       └── UnitOfWorks/
│
├── docker-compose.yml
├── docker-compose.override.yml
└── ProInvoice.sln
```

---

## API Endpoints

All API endpoints are versioned using the following base route:

```text
/api/v1
```

### Authentication

| Method | Endpoint | Description |
|---|---|---|
| POST | `/api/v1/auth/register` | Register a new user |
| POST | `/api/v1/auth/Login` | Authenticate a user |
| POST | `/api/v1/auth/RefreshToken` | Refresh access token |
| POST | `/api/v1/auth/RevokeUser` | Revoke user tokens |
| POST | `/api/v1/auth/RevokeAll` | Revoke tokens for all users |

### Customers

| Method | Endpoint | Description |
|---|---|---|
| POST | `/api/v1/customers` | Create customer |
| GET | `/api/v1/customers` | Get all customers |
| GET | `/api/v1/customers/{customerId}` | Get customer by ID |
| PUT | `/api/v1/customers/{customerId}` | Update customer |
| DELETE | `/api/v1/customers/{customerId}` | Remove customer |

### Products

| Method | Endpoint | Description |
|---|---|---|
| POST | `/api/v1/products` | Create product |
| GET | `/api/v1/products` | Get all products |
| GET | `/api/v1/products/{productId}` | Get product by ID |
| PUT | `/api/v1/products/{productId}` | Update product |
| DELETE | `/api/v1/products/{productId}` | Remove product |

### Invoices

| Method | Endpoint | Description |
|---|---|---|
| POST | `/api/v1/invoices` | Create invoice |
| GET | `/api/v1/invoices` | Get all invoices |
| GET | `/api/v1/invoices/{invoiceId}` | Get invoice by ID |
| PUT | `/api/v1/invoices/{invoiceId}` | Update invoice |
| DELETE | `/api/v1/invoices/{invoiceId}` | Remove invoice |

**Note:** Customers, Products, and Invoices endpoints require authorization. Token revocation endpoints also have role-based restrictions.

---

## Getting Started

### Prerequisites

Make sure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server 2022](https://www.microsoft.com/en-us/sql-server)
- [Redis](https://redis.io/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (recommended)
- Visual Studio 2022 or Visual Studio Code

### 1. Clone the Repository

```bash
git clone https://github.com/moastafa-eng/Pro-Invoice.git

cd Pro-Invoice
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Configure the Application

Update the connection strings and JWT settings in your development configuration or provide them through .NET User Secrets / environment variables.

### 4. Apply Database Migrations

Install the Entity Framework Core CLI if needed:

```bash
dotnet tool install --global dotnet-ef
```

Apply the existing migrations:

```bash
dotnet ef database update \
  --project src/ProInvoice.Infrastructure \
  --startup-project src/ProInvoice.API
```

Make sure SQL Server is running and the configured database connection is reachable before applying migrations.

### 5. Run the API

```bash
dotnet run --project src/ProInvoice.API
```

---

## Running with Docker

ProInvoice includes Docker Compose configuration for running the application and its supporting services.

The environment includes:

| Service | Description |
|---|---|
| ProInvoice API | ASP.NET Core Web API |
| SQL Server 2022 | Relational database |
| Redis | Distributed caching |
| Seq | Centralized logging |

Start the supporting infrastructure:

```bash
docker compose up -d proinvoice.sql proinvoice.redis proinvoice.serilog
```

Apply the database migrations using the Getting Started instructions, then start the application:

```bash
docker compose up --build
```

To stop the containers:

```bash
docker compose down
```

To remove containers and persisted database volumes:

```bash
docker compose down -v
```

**Warning:** The last command deletes the persisted database volume and its data.

---

## Configuration

The application uses configuration sections for its infrastructure services.

### Connection Strings

```json
{
  "ConnectionStrings": {
    "Database": "YOUR_SQL_SERVER_CONNECTION_STRING",
    "Cache": "YOUR_REDIS_CONNECTION_STRING"
  }
}
```

### JWT Settings

```json
{
  "JWT": {
    "Audience": "YOUR_AUDIENCE",
    "Issuer": "YOUR_ISSUER",
    "Secret": "YOUR_SECRET_KEY",
    "TokenValidityInMinutes": 15,
    "RefreshTokenValidityInDates": 60
  }
}
```

### Outbox Settings

```json
{
  "Outbox": {
    "IntervalInSeconds": 10,
    "BatchSize": 10
  }
}
```

**Security Notice:** Never commit production credentials, database passwords, or JWT signing keys to source control. Use .NET User Secrets or environment variables for sensitive configuration. Replace development credentials before deployment.

---

## API Documentation

Swagger / OpenAPI is configured for the API and enabled in the Development environment.

After starting the application, access the Swagger UI through:

```text
/swagger
```

Swagger provides an interactive interface for exploring and testing the available API endpoints.

---

## Health Checks

The application exposes a health-check endpoint:

```http
GET /health-check
```

The endpoint reports the health status of configured dependencies, including:

- SQL Server.
- Redis.

---

## Future Improvements

Potential areas for further development:

- Automated unit and integration tests.
- Pagination and filtering for collection endpoints.
- Enhanced API documentation with request and response examples.
- Production-ready secrets management.
- CI/CD pipeline integration.
- Additional invoice reporting capabilities.

---

## Author

**Mostafa Engineering**

GitHub: [@moastafa-eng](https://github.com/moastafa-eng)

Project Repository: [Pro-Invoice](https://github.com/moastafa-eng/Pro-Invoice)

---

<p align="center">
  If you find this project interesting, consider giving it a ⭐ on GitHub!
</p>
