# absa_phonebook
ABSA CIB Digital Tech Assessment


## SETUP

The project is dependant on 
> Install-Package Microsoft.EntityFrameworkCore.SqlServer

Once the project is cloned, to initiate it run the following on NuGet Package Manager > Package Manager Console (PMC):

> Remove-Migration
> Add-Migration InitialCreate
> Update-Database


Check the coneection string in appsettings.json to ensure that a database connection can be established. 

> Check the connectionstring server, username and password