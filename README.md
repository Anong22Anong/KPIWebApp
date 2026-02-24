# KPI Calculation Web Application

ASP.NET Core MVC (.NET 8) application for managing employees and calculating KPIs.

## Features

- **Employee CRUD**: Create, Read, Update, Delete employees
- **KPI auto-calculation** on save:
  - **SalesScore** = (ActualSales / TargetSales) × 100
  - **AttendanceScore** = (AttendanceDays / TotalWorkingDays) × 100
  - **FinalKPI** = (SalesScore × 0.7) + (AttendanceScore × 0.3)
- **Dashboard**: Average KPI, Top 5 employees, KPI bar chart (Chart.js)
- **Stack**: EF Core + SQL Server, Repository pattern, KPI Service layer, Bootstrap 5

## Prerequisites

- .NET 8 SDK
- SQL Server (or LocalDB)

## Setup

1. Update `appsettings.json` connection string if needed (default: LocalDB).
2. Restore and run:

```bash
dotnet restore
dotnet run
```

3. Open http://localhost:5000 (or the URL shown in the console).

The database is created via EF Core migrations. If you need to recreate it:

```bash
dotnet ef database update
```

To add new migrations after model changes:

```bash
dotnet ef migrations add YourMigrationName
dotnet ef database update
```

## Project Structure

- **Models**: `Employee`, view models
- **Data**: `ApplicationDbContext`
- **Repositories**: `IEmployeeRepository`, `EmployeeRepository`
- **Services**: `IKpiService`, `KpiService` (KPI calculation)
- **Controllers**: `HomeController` (dashboard), `EmployeesController` (CRUD)
- **Views**: Razor views with Bootstrap 5 and Chart.js
