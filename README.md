
# Ppr Final Case

This project is a robust .NET-based application implementing various architectural patterns and best practices, including CQRS, UnitOfWork, GenericRepository, layered architecture, Mapper, JWT authentication, and FluentValidation. The project covers essential functionalities like account management, authorization, coupon handling, order processing, product and category management, and point tracking.

## Table of Contents

- [Project Overview](#project-overview)
- [Technologies Used](#technologies-used)
- [Features](#features)
- [Architecture](#architecture)
- [Setup](#setup)
- [Usage](#usage)
- [API Documentation](#api-documentation)
- [Contributing](#contributing)
- [License](#license)

## Project Overview

This application is designed to manage different aspects of an e-commerce platform. It includes the following main components:

- **Account**: Manages user accounts and related information.
- **Authorization**: Handles user authentication and authorization using JWT.
- **Coupon**: Manages discount coupons, including creation, validation, and expiration.
- **Order**: Handles order processing, including applying coupons and using points.
- **OrderDetail**: Manages the details of each order, including product information and quantities.
- **Product**: Manages the product catalog, including product details and pricing.
- **Category**: Organizes products into categories for easier browsing.
- **ProductCategory**: Manages the many-to-many relationship between products and categories.
- **Point**: Handles the points system, allowing users to earn and redeem points.

## Technologies Used

- **C# and .NET Core**: The primary language and framework for building the application.
- **Entity Framework Core**: For database interactions, using the Code-First approach.
- **CQRS**: Command Query Responsibility Segregation pattern to separate read and write operations.
- **UnitOfWork and GenericRepository**: For managing transactions and generic CRUD operations.
- **AutoMapper**: For mapping between entities and data transfer objects (DTOs).
- **JWT Authentication**: For secure user authentication and authorization.
- **FluentValidation**: For validating request models with a clean and fluent API.
- **Swagger**: For API documentation and testing.
- **Postman**: For API testing and documentation generation.

## Features

- **Account Management**: Register, login, and manage user accounts.
- **JWT Authentication**: Secure token-based authentication.
- **Coupon Management**: Create, apply, and manage discount coupons.
- **Order Processing**: Create orders, apply coupons, and use points.
- **Product and Category Management**: Organize and manage products in categories.
- **Points System**: Earn and redeem points for discounts on orders.
- **API Documentation**: Automatically generated and interactive API documentation.

## Architecture

The project follows a layered architecture, separating concerns into different layers:

- **Presentation Layer**: Contains the API controllers and handles HTTP requests and responses.
- **Application Layer**: Implements business logic, CQRS commands, and queries.
- **Domain Layer**: Contains the core entities, repositories, and business rules.
- **Infrastructure Layer**: Handles database interactions, JWT token generation, and other external concerns.

## Setup

1. Clone the repository from GitHub:
   ```bash
   git clone https://github.com/your-username/your-repo-name.git
2. Navigate to the project directory:
   ```bash
   cd your-repo-name
Ensure you have all necessary dependencies installed
3. Install dependencies:
   ```bash```
   dotnet restore
Open appsettings.json and update the connection string to point to your database.
4. Configure the database connection:
   ```bash```
   dotnet restore
Apply the Entity Framework Core migrations to set up the database schema.
5. Apply migrations:
    ```bash
    dotnet ef database update

6. Clone the repository from GitHub:
   ```bash
   dotnet build
   dotnet run

The application will be available at https://localhost:5001 by default.



## Usage

- **API Testing**: Use Postman or any other API client to test the API endpoints.
- **Swagger UI**: Access interactive API documentation at https://localhost:5001/swagger.

## Documentation

https://documenter.getpostman.com/view/24591310/2sA3s4kpsZ
