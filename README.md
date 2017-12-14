# Tower

This is a personal graduate project done in ASP.NET CORE and c#.

Tower is a project management platform for IT departments to manage tickets, assets, clients, consultants. It will allow managers to gather reports of costs associated with technicians as they perform daily duties such as traveling to clients, working on projects, and billing time.

Required Components
.Net Core
ASP.NET Core
SQL Server 2017

Recommend Components
Visual Studio 2017

Installation Instructions

Download repository from the GitHub website using a Git program or by clicking “Download.” A URL or ZIP option is available.
Use Visual Studio 2017 to install ASP.NET Core and .NET Core required components.
Optionally, see https://docs.microsoft.com/en-us/aspnet/core/getting-started if you want to use the command line version. 
Install SQL Server 2017. See https://www.microsoft.com/en-us/sql-server/sql-server-downloads for instructions on how to download and install on Windows or Linux. Install the Express version
Once installed, create a local database called “TowerDb” as a local database. 
Navigate to the root folder of Tower’s download. Open the root solution file (Tower.sln) project using visual studio or the command line.
Initial migrations will need to be applied to the database. In Visual Studio, open package manager console and type “Update-Database”.
Tower is now ready to start. Use the command line or Visual Studio to build and run the project. Navigated to the correct local web address you’ve setup on your operating system.
Once the homepage loads, create an initial account by clicking “Create an Account.”
