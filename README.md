# Product_List
A simple web application built with ASP.NET Core MVC (Razor Views), Dapper, and SQL Server to manage a product catalog. This app demonstrates basic CRUD operations (Create, Read, Update, Delete) using Dapper for data access and a clean, responsive UI using Bootstrap.

📋 Features
  1.Homepage
    - Displays a list of products with names and prices.
    - Data is retrieved from SQL Server using Dapper.
  
  2. Add Product
     - Allows the user to add a new product.
     - Saves the data to the database using Dapper.
       
  3. Edit Product
     - Allows the user to update an existing product's details.
     - Updates the database using Dapper.
       
  4. Delete Product
     - Allows the user to delete a product.
     - Deletes the record using Dapper.
       
  5. Responsive UI
     - Designed using Bootstrap 5.
     - Razor views are used for dynamic content rendering.

🚀 Getting Started
1. Clone the Repository
2. Setup the Database
   - Create a new database in SQL Server
   - Run the SQL schema below to create the Product table.
       <pre> CREATE TABLE Product ( ID INT IDENTITY(1,1) PRIMARY KEY, ProductName VARCHAR(50), ProductDescription VARCHAR(100), Price DECIMAL(18, 0), Stock INT, CreatedDate DATETIME, UpdatedDate DATETIME ); </pre>
   - Update the connection string in appsettings.json:
       <pre> "ConnectionStrings": {
          "DefaultConnection": "Server=YOUR_SERVER;Database=ProductInventory;Trusted_Connection=True;"
        } </pre>
3. Run the Application
   - dotnet build
   - dotnet run
   - Visit https://localhost:5001 (or the port shown in your terminal).
  
📄 License
This project is intended for demonstration purposes.
