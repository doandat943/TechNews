# Important

Issues of this repository are tracked on https://github.com/aspnetboilerplate/aspnetboilerplate. Please create your issues on https://github.com/aspnetboilerplate/aspnetboilerplate/issues.

# ASP.NET Core & EntityFramework Core Based Startup Template

This template is a simple startup project to start with ABP
using ASP.NET Core and EntityFramework Core.

## Prerequirements

* Visual Studio/Visual Studio Code
* .NET Core SDK
* MySQL/MariaDB

## How To Run

* Go to project folder
* Migrate database structure `dotnet ef migrations add InitialCreate`
* Update database structure `dotnet ef database update`
* Run the application `dotnet run`

## Build Image

```
dotnet publish /p:PublishProfile=DefaultContainer
docker-compose build
docker-compose up
```