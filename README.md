# Telefon bok

Using:
.NET Framework using C#

API 
.NET Core with Entity Framework with SQL Server.

# setup for SQL DB
Create an initial migration to generate the database schema based on your model classes:
Command: dotnet ef migrations add InitialCreate

Apply the migration to create the database:
Command: dotnet ef database update
