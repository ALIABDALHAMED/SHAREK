# SHAREK

## Run locally

Install the .NET 10 SDK and SQL Server LocalDB. Copy
`src/SHAREK.API/appsettings.Development.example.json` to
`src/SHAREK.API/appsettings.Development.json`, then set `DefaultConnection` to your
local database, for example:

```text
Server=(localdb)\MSSQLLocalDB;Database=SHAREK;Trusted_Connection=True;TrustServerCertificate=True
```

From the repository root, run:

```powershell
dotnet build SHAREK.sln
dotnet run --project src/SHAREK.API/SHAREK.API.csproj
```

In Development, the app applies migrations and seeds development data at startup.
Open `/swagger` for the API docs and `/health` for the health check.

## Folder rules

- `src/SHAREK.API/Modules` contains feature code. Work only in your assigned module.
- Keep each module's code in plain `Controllers`, `Services`, `DTOs`, `Entities`,
  `Configurations`, or `Enums` folders as needed. Do not add empty folders.
- `Data` contains the EF context, migrations, and seed data. `Common` contains
  shared types; `Infrastructure` contains storage, payments, and background jobs.
- `tests/SHAREK.Tests` contains all automated tests.
- Only the back lead creates migrations with
  `dotnet ef migrations add <Name> -p src/SHAREK.API`.

## Team workflow

- `development` is for daily work, `test` for weekly testing, and `production`
  for the final stable release. These are the only branches.
- Before pushing, pull `development`, build, run the app, then push and merge into
  `development` without changing other people's code. Work only in your assigned
  module.
- After a stable week, merge `development` into `test`. After all test cases pass,
  merge `test` into `production`.
