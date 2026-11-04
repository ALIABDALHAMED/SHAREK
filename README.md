# SHAREK

SHAREK is organized as a layered .NET solution:

- `src/SHAREK.API` — ASP.NET Core API, feature controllers, hubs, middleware, filters, and extensions.
- `src/SHAREK.Application` — application features, commands, queries, DTOs, validators, and common abstractions.
- `src/SHAREK.Domain` — domain entities, enums, events, and shared domain code.
- `src/SHAREK.Infrastructure` — persistence, repositories, configurations, and infrastructure services.
- `tests/SHAREK.UnitTests` — unit tests.
- `tests/SHAREK.IntegrationTests` — integration tests.
- `tests/SHAREK.ArchitectureTests` — architecture tests.

Project references follow the dependency direction: API depends on Application and Infrastructure; Application depends on Domain; Infrastructure depends on Application; Domain has no project references.

Most feature folders are scaffolding placeholders; add implementation files as each feature is developed. The Identity `User`, Admin `AuditLog`, and `Persistence/AppDbContext` provide the initial identity and persistence types.

Copy `src/SHAREK.API/appsettings.Development.example.json` to `appsettings.Development.json` and set a local SQL Server connection string. The local development settings file is ignored by Git.

## Database migrations

```powershell
dotnet ef migrations add InitialSchema -p src/SHAREK.Infrastructure -s src/SHAREK.API -o Persistence/Migrations
dotnet ef database update -p src/SHAREK.Infrastructure -s src/SHAREK.API
```

## Build and test

```powershell
dotnet build SHAREK.sln
dotnet test SHAREK.sln
```

The API includes a starter health endpoint at `/health`.