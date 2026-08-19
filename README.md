# REST Application

A simple **ASP.NET Core Web API** project built as a Junior-level backend application.

The project demonstrates the basic principles of building a RESTful API using a layered architecture, Entity Framework Core, Repository Pattern, DTOs, AutoMapper, logging, and centralized exception handling.

## 🚀 Features

* RESTful API
* CRUD operations for Products
* Entity Framework Core
* SQL database
* Repository Pattern
* DTOs
* AutoMapper
* Dependency Injection
* Logging
* Centralized Exception Handling
* Database Migrations
* Swagger / OpenAPI
* Clean and maintainable project structure

## 🛠️ Technologies

* **C#**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **SQL Server**
* **AutoMapper**
* **Swagger / OpenAPI**
* **Repository Pattern**
* **Dependency Injection**

## 📁 Project Structure

```text
REST_Application/
│
├── Controllers/
│   └── ProductController.cs
│
├── Models/
│   └── Product.cs
│
├── DTOs/
│   └── ProductDto.cs
│
├── Repositories/
│   ├── IProductRepository.cs
│   └── ProductRepository.cs
│
├── Data/
│   └── ApplicationDbContext.cs
│
├── Mapping/
│   └── MappingProfile.cs
│
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
│
├── Migrations/
│
├── Program.cs
└── appsettings.json
```

## 🧱 Architecture

The application follows a simple layered approach:

```text
Controller
    ↓
Repository
    ↓
Entity Framework Core
    ↓
SQL Server
```

### Controller

Controllers handle HTTP requests and return HTTP responses.

Example endpoints:

```text
GET     /api/products
GET     /api/products/{id}
POST    /api/products
PUT     /api/products/{id}
DELETE  /api/products/{id}
```

### Repository

The Repository Pattern separates database access from the controllers.

This makes the application easier to maintain, test, and extend.

### DTO

Data Transfer Objects are used to control which data is received from or returned to the client.

The API does not expose the database entity directly when a DTO is more appropriate.

### AutoMapper

AutoMapper is used to map between entities and DTOs.

```text
Product
   ↕
ProductDto
```

## 📦 Product Model

The main entity contains the following properties:

```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
```

## 🔄 CRUD Operations

The API supports the standard CRUD operations.

| Method | Endpoint             | Description          |
| ------ | -------------------- | -------------------- |
| GET    | `/api/products`      | Get all products     |
| GET    | `/api/products/{id}` | Get product by ID    |
| POST   | `/api/products`      | Create a new product |
| PUT    | `/api/products/{id}` | Update a product     |
| DELETE | `/api/products/{id}` | Delete a product     |

## 🗄️ Database

Entity Framework Core is used for database communication.

Database changes are managed using **EF Core Migrations**.

Create a migration:

```bash
dotnet ef migrations add InitialCreate
```

Update the database:

```bash
dotnet ef database update
```

## ⚠️ Exception Handling

The API contains centralized exception handling.

Instead of handling exceptions separately inside every controller, exceptions are handled through middleware.

This provides a consistent error response and keeps controllers cleaner.

## 📝 Logging

Application events and exceptions are logged using the ASP.NET Core logging system.

Logging helps with:

* debugging
* monitoring
* troubleshooting
* tracking application errors

## 🔐 Security

The project also takes dependency security into consideration.

NuGet packages should be kept up to date and known vulnerabilities should be reviewed regularly.

## ▶️ Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/vardanpoxosyan/REST_Application.git
```

### 2. Navigate to the project

```bash
cd REST_Application
```

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Apply database migrations

```bash
dotnet ef database update
```

### 5. Run the application

```bash
dotnet run
```

## 📖 Swagger

After starting the application, Swagger can be used to test the API.

```text
/swagger
```

Swagger provides an interactive interface for testing the available endpoints.

## 🎯 Learning Goals

This project was created to practice the fundamentals of backend development with ASP.NET Core.

The main goals are:

* Understanding REST API architecture
* Working with ASP.NET Core Web API
* Understanding DTOs
* Implementing Repository Pattern
* Working with Entity Framework Core
* Creating database migrations
* Using Dependency Injection
* Mapping entities with AutoMapper
* Implementing logging
* Handling exceptions centrally
* Writing maintainable backend code

## 📌 Future Improvements

Possible improvements for the project:

* Authentication and Authorization
* JWT authentication
* FluentValidation
* Unit Tests
* Integration Tests
* Pagination
* Filtering and Sorting
* Docker support
* CI/CD
* API versioning

## 👨‍💻 Author

**Vardan Poghosyan**

GitHub:
https://github.com/vardanpoxosyan

## 📄 License

This project is created for educational and portfolio purposes.
