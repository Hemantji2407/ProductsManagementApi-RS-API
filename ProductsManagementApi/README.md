Products Management API
This ASP.NET Core Web API project manages products. It includes CRUD operations for products, custom middleware for error handling, global action filters for logging, and Swagger integration for API documentation.

Table of Contents :
Controllers
Filters
Middleware
Models
Services
Usage
Contributing
License


Controllers
ProductsController.cs: Manages endpoints related to product CRUD operations.

Filters
CustomActionFilter.cs: Global action filter for logging.

Middleware
ErrorHandlingMiddleware.cs: Custom middleware for global error handling.

Models
Product.cs: Represents the product model with properties like Id, Name, Price, and Quantity.

Services
ProductService.cs: Implements the business logic for product management, including methods for getting, adding, updating, and deleting products.

Usage
1. Clone the repository:

git clone https://github.com/hemantji247/ProductsManagementApi.git
2. Open the project in your preferred IDE or code editor.

3. Configure the app settings and database connection string if needed.

4. Build and run the application.

5. Use Swagger UI or API endpoints to interact with the API.

Contributing:
Contributions to this project are welcome. Follow these steps to contribute:

Fork the repository.
Create a new branch (git checkout -b feature/my-feature).
Make your changes.
Commit your changes (git commit -am 'Add new feature').
Push to the branch (git push origin feature/my-feature).
Create a new Pull Request.
License
This project is licensed under the MIT License. See the LICENSE file for details.