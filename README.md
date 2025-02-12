# FactoryKPIs
FactoryKPIs is a Blazor Server App designed to monitor live production data using dynamic charts.  
It displays real-time KPIs and cycles through different chart types automatically.  

# Features
- Blazor Bootstrap for UI design
- Live production data visualization  
- Auto-cycling charts based on selected assembly lines  
- Real-time updates via SignalR (no page reloads)  
- Hosted on GBBLWAS002 via IIS for internal factory use

# Prerequisites
- Microsoft Visual Studio Community 2022 (64-bit) - Version 17.12.4
- .NET 8.0.405 SDK (Installed on local machine)
- IIS installed and configured for hosting
- ASP.NET Core Runtime 8.0.12 Windows Hosting Bundle (Installed on the hosting server)
- SQL Server (Read-only database access)

# Respository
- Latest version of the repoo is stored here: T:\GB-IGDoors\IT-Team\repos\FactoryKPIs
	- This repo has no version history and is only used to Publish
- All versions of the repo are stored here: https://github.com/ajsadler/FactoryKPIs
	- This repo has full version history of changes, and can be used to rollback files when needed
- To add to the repo, you will firstly need to clone the Master repo
- Open a terminal
- cd path/to/your/folder where you want to store the project
- git clone https://github.com/ajsadler/FactoryKPIs.git
- cd FactoryKPIs
- Then you will need to create a new branch of the repo, in order to work on a new feature or fix without affecting the Master branch
- git checkout -b new-branch-name (tip: name the branch relating to the feature or fix that you are working on, so it's easily identified)
- After working on your new branch, you will need to push the changes back to GitHub
- git add .
- git commit -m "Comments about your branch and the features/fixes that have been made"
- git push origin new-branch-name
- The repo owner can then review the changes and merge the branch into the Master repo

# Files
- .gitignore - Which files and folders to ignore when commiting to GitHub
- appsettings.json - Defines the connection string to the database. This is included in .gitignore because it contains the database credentials
- wwwroot/
 	- app.css - Controls css for the whole site
- Components/
 	- Layout/
		- MainLayout.razor - Sidebar design
	- Pages/
 		- _Host.cshtml - Entry point for the Blazor Server app, it acts as the main host page that loads the Blazor application
		- Error.razor - Error page
		- Home.razor - Home page
	- _Imports.razor - Simplifies namespace use throughout the app, without needing to specify these on each Razor component
	- App.razor - Along with _Host.cshtml, serves as the entry point for the Blazor Server app, responsible for initialising and rendering the Blazor application
	- Routes.razor - Handles navigation and layout
- Data/
	- ApplicationDbContext.cs - Defines a class for the database context, bridging the SQL database to C#
	- *Database*.cs - Defines which columns to pull from the table and what datatype to format them as
	- *Database*Service.cs - Defines functions to act as a data access layer to fetch the data from the *Database*
- Services/
	- NavigationCycleService.cs - Defines a set of functions to cycle through pages from the Home page
- Program.cs - Entry point in ASP.NET Core, defining services, middleware and routing for the web app