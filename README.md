# eCommerceSolution.ProductService

This repository contains a small Product Service used in an e-commerce example solution. It is split into three projects to separate responsibilities:

- `ProductService.API` - ASP.NET Core Web API (controllers and minimal endpoints). Hosts the HTTP endpoints for CRUD and search operations.
- `BuisnessLogicLayer` - Application services, DTOs, AutoMapper profiles and validation logic.
- `DataAccessLayer` - EF Core `DbContext`, entity definitions and repository implementations.

Key technologies

- .NET 8
- ASP.NET Core Web API (controllers + minimal APIs)
- Entity Framework Core (MySQL / Pomelo recommended)
- AutoMapper for DTO/entity mapping
- FluentValidation for request validation

Project structure (important files)

- `ProductService.API/Program.cs` - application startup, DI registration and endpoint registration.
- `ProductService.API/Controllers/ProductController.cs` and `ProductService.API/ApiEndpoints/ProductEndpoints.cs` - HTTP endpoints.
- `DataAccessLayer/Context/ApplicationDbContext.cs` - EF Core `DbContext`.
- `DataAccessLayer/Repositories/ProductRepository.cs` and `DataAccessLayer/RepositoryContracts/IProductRepository.cs` - repository layer.
- `BuisnessLogicLayer/Services/IProductService.cs` and `BuisnessLogicLayer/Services/ProductService.cs` - business services.
- `BuisnessLogicLayer/Mappers/*` - AutoMapper profiles.
- `BuisnessLogicLayer/Validations/*` - FluentValidation validators.

Prerequisites

- .NET 8 SDK
- A MySQL-compatible database. For EF Core 8 prefer `Pomelo.EntityFrameworkCore.MySql` + `MySqlConnector`.

Quick start

1. Update the connection string in `ProductService.API/appsettings.json` (key: `ConnectionStrings:MySql`).
2. Restore and build:

   dotnet restore
   dotnet build

3. Run the API (from the `ProductService.API` folder):

   dotnet run

Example requests

- Health check:

  GET /api/product/health

- Create product (POST /api/product)

  curl -X POST "https://localhost:7215/api/Product" -H "Content-Type: application/json" -d '{"productName":"Phone","category":"Electronics","unitPrice":299.99,"quantityInStock":10}'

Notes and troubleshooting

- Minimal APIs use separate JSON options. `Program.cs` configures `Microsoft.AspNetCore.Http.Json.JsonOptions` so enums serialize as strings.
- Avoid registering duplicate POST routes (both minimal endpoint and controller routes for the same path) — this can cause model binding errors.
- If you encounter `MissingMethodException` related to MySQL (`MySqlConnectionStringBuilder`), check installed MySQL provider packages and use Pomelo + MySqlConnector for EF Core 8 compatibility.

Contributing

Open an issue or submit a PR. Keep changes small and follow the existing layering (API -> BLL -> DAL) when adding features.