# Important

Issues of this repository are tracked. Please create your issues on https://github.com/doandat943/TechNews/issues.

# TechNews

TechNews is a modern online news website that provides the latest and most exciting technology news. Built on the ASP.NET Core framework with a MySQL database, TechNews leverages the MVC (Model-View-Controller) architecture to deliver a smooth and efficient user experience.

## Key Features

- **Technology News**: Continuously updated articles about the latest technology trends.
- **Content Management**: Easily manage articles, categories, and authors through an admin interface.
- **Responsive Design**: User-friendly interface compatible with all devices, from desktops to mobile phones.
- **Advanced Search**: Allows users to search and filter articles based on various criteria.

## Technologies Used

- **ASP.NET Core**: A powerful framework by Microsoft for building web applications.
- **MySQL**: A popular open-source relational database management system.
- **MVC (Model-View-Controller)**: A software design pattern that separates the application into distinct sections, making the codebase easier to maintain and extend.
- **Entity Framework Core**: An ORM (Object-Relational Mapping) tool that simplifies database interactions.

# Getting Started

To get started with the TechNews project, follow the instructions below in this document.

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

## Build and run with Docker

```
dotnet publish /p:PublishProfile=DefaultContainer
docker-compose up
```

## Credits

- Homepage template: [BizNews by HTML Codex](https://htmlcodex.com/free-news-website-template/)
- Admin template: [NiceAdmin by BootstrapMade](https://bootstrapmade.com/nice-admin-bootstrap-admin-html-template/)