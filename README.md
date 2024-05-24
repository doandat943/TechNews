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

### 1. Go to the project folder
```sh
cd path/to/your/project
```

### 2. Set database environment

#### On Windows:
```sh
set DBHOST=joverse.us
set DBPORT=3001
set DBPASSWORD=12345678
dotnet watch run
```

#### On Linux/macOS:
```sh
export DBHOST=joverse.us
export DBPORT=3001
export DBPASSWORD=12345678
```

### 3. Migrate database structure
```sh
dotnet ef migrations add InitialCreate
```

### 4. Update database structure
```sh
dotnet ef database update
```

### 5. Run the application
```sh
dotnet run
```

## Build Image

```
dotnet publish /p:PublishProfile=DefaultContainer
docker-compose build
docker-compose up
```