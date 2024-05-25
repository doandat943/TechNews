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
set DBHOST=your_database_host
set DBPORT=your_database_port
set DBUSERID=your_database_userid
set DBPASSWORD=your_database_password
```

#### On Linux/macOS:
```sh
export DBHOST=your_database_host
export DBPORT=your_database_port
export DBUSERID=your_database_userid
export DBPASSWORD=your_database_password
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

## Credits

- Homepage template: [Biznews by HTML Codex](https://htmlcodex.com/free-news-website-template/)
- Admin template: [NiceAdmin by BootstrapMade](https://bootstrapmade.com/nice-admin-bootstrap-admin-html-template/)
