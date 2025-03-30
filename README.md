# CleanArchitectureDDD .NET Template 🚀

A modern .NET solution following Clean Architecture and Domain-Driven Design (DDD) principles, featuring a WebAPI, WorkerService with Hangfire, and SQL Server integration.

[![.NET](https://img.shields.io/badge/.NET-9.0-purple)](https://dotnet.microsoft.com/)
[![EF Core](https://img.shields.io/badge/EF%20Core-9.0-blue)](https://learn.microsoft.com/ef/core/)
[![Hangfire](https://img.shields.io/badge/Hangfire-1.8+-yellowgreen)](https://www.hangfire.io/)

## Features ✨

- **Clean Architecture** with clear separation of layers (Domain, Application, Infrastructure).
- **WorkerService** for background jobs using Hangfire (scheduled hourly).
- **WebAPI** with RESTful endpoints and Scalar documentation.
- **SQL Server** integration with EF Core migrations.
- **Repository Pattern** for database operations.
- **Public API Integration** ([Advice Slip API](https://api.adviceslip.com/)).

## Technologies Used 🛠️

| Category               | Technologies                                                                 |
|------------------------|------------------------------------------------------------------------------|
| **Core**               | .NET 9, C#, Entity Framework Core, DDD                                      |
| **Web**                | ASP.NET Core WebAPI, Scalar (API Documentation)                             |
| **Background Processing** | Hangfire, Worker Service                                                |
| **Database**           | SQL Server, EF Core Migrations                                              |
| **Tools**              | Swagger (OpenAPI), HttpClient, Dependency Injection                         |

## Getting Started 🚦

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/sql-server) (or Docker)
- IDE (Visual Studio 2022+, VS Code, or JetBrains Rider)

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/CleanArchitectureDDD.git
   cd CleanArchitectureDDD
   ```

2. **Set up the database**:
   - Update connection strings in appsettings.json for both WebAPI and WorkerService.
   - Run migrations:
     ```bash
     # For WebAPI (Advices database):
     dotnet ef database update --project Infrastructure --startup-project WebAPI

     # For WorkerService (Hangfire database):
     dotnet ef database update --project Infrastructure --startup-project WorkerService
     ```

3. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

## Running the Project

1. **WebAPI** (Port 5219/7206):
   ```bash
   dotnet run --project WebAPI
   ```

2. **WorkerService** (Hangfire jobs):
   ```bash
   dotnet run --project WorkerService
   ```

## API Documentation 📖

Access interactive API documentation via Scalar:
```
http://localhost:5219/scalar
```

### Endpoints:

- **GET /api/advice** - List all advices
- **GET /api/advice/{externalId}** - Get advice by external ID
- **POST /api/advice** - Add/update advice

## Architecture Overview 🏗️

```
CleanArchitectureDDD/
├── Domain/          # Core business logic (Entities, Interfaces)
├── Application/     # Use Cases, DTOs, Service Interfaces
├── Infrastructure/  # EF Core, Repositories, External API Clients
├── WebAPI/          # REST API Controllers
├── WorkerService/   # Hangfire Jobs
└── HangfireJobs/    # Background Job Definitions
```

## Database Setup 🗄️

- **Advices Database** (WebAPI):
  - Stores advices from the external API.
  - Table: Advices (columns: Id, ExternalId, AdviceText, CreatedAt).

- **Hangfire Database** (WorkerService):
  - Manages Hangfire jobs and queues.

## Contributing 🤝

1. Fork the repository.
2. Create a feature branch: `git checkout -b feature/your-feature`.
3. Commit changes: `git commit -m 'Add your feature'`.
4. Push to the branch: `git push origin feature/your-feature`.
5. Open a Pull Request.

## License 📄

MIT License - See LICENSE for details.

---

Made with ❤️ by Hugo Stowasser.

> Note: This project is a template and uses the public Advice Slip API.
