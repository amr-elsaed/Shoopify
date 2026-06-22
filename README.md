# Shoopify 🛒

A modern, full-featured E-Commerce web application built with **ASP.NET Core 9.0 MVC**. Shoopify allows users to browse products, manage a shopping cart using session state, securely place orders, and view their order history.

## 🌟 Features

* **User Authentication & Authorization**: Secure login and registration powered by ASP.NET Core Identity.
* **Product Catalog**: Browse a wide variety of products, complete with categories, descriptions, and dynamic image uploading.
* **Ingredient Tracking**: Detailed tracking of ingredients for specific products.
* **Shopping Cart**: Session-based shopping cart for a seamless adding and updating of products before checkout.
* **Order Management**: Secure checkout process and a dedicated section for users to view their past orders.
* **Repository Pattern**: Clean and maintainable data access using the Repository design pattern.
* **Responsive Design**: Views are built to be responsive and user-friendly across all devices.

## 🛠️ Technologies & Stack

* **Framework**: ASP.NET Core 9.0 MVC
* **Database**: SQL Server
* **ORM**: Entity Framework Core 9.0
* **Authentication**: ASP.NET Core Identity
* **State Management**: In-Memory Caching & Session State
* **Frontend**: Razor Views, HTML5, CSS3, Bootstrap

## 🏗️ Architecture

* **MVC (Model-View-Controller)**: Standard structural pattern for separation of concerns.
* **Repository Pattern**: Abstracts the data layer (`ProductRepo`, `OrderRepo`, `IngredientRepo`) making the code more testable and organized.
* **Dependency Injection**: Extensively used for services, repositories, and database contexts.

## 🚀 Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

* [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express or Developer edition)
* [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/Shoopify.git
   cd Shoopify
   ```

2. **Configure the Database Connection**
   Open `appsettings.json` and update the `DefaultConnection` string with your SQL Server credentials.
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=ShoopifyDB;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"
   }
   ```

3. **Apply Entity Framework Migrations**
   Open your Package Manager Console (PMC) in Visual Studio or terminal and run the following command to create the database:
   ```bash
   # Using .NET CLI
   dotnet ef database update
   
   # Using Package Manager Console in Visual Studio
   Update-Database
   ```

4. **Run the Application**
   ```bash
   dotnet run
   ```
   Navigate to the URL provided in the console output (usually `https://localhost:xxxx`) in your web browser.

## 📂 Project Structure

* `Controllers/`: Handles HTTP requests and application logic (e.g., `ProductController`, `OrderController`).
* `Models/`: Contains Domain Entities (`Product`, `Order`, `Category`) and ViewModels.
* `Models/Repository/`: Data access logic abstraction using the Repository Pattern.
* `Views/`: Razor pages for the user interface.
* `Data/`: Entity Framework `ApplicationDbContext` and database migrations.
* `wwwroot/`: Static files such as CSS, JS, and uploaded Images.

## 🤝 Contributing

Contributions, issues, and feature requests are welcome! Feel free to check the issues page.

## 📝 License

This project is open source and available under the [MIT License](LICENSE).
