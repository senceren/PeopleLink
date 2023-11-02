## PeopleLink
	N-Layered .NET Core Human Resources Management Project Demonstrating Onion Architecture and the Generic Repository Pattern.

### Infrastructure
```
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore
```

## Migrations
Before running the following commands, make sure that Web is set as startup project. Run the follwoing commands on the project "Infrastructure".

### Infrastructure
```
Add-Migration InitialCreate -Context PeopleLinkContext -OutputDir Data/Migrations
Update-Database -Context PeopleLinkContext
Remove-Migration -Context PeopleLinkContext
Update-Database 0 -Context PeopleLinkContext

Add-Migration InitialIdentity -Context PeopleLinkIdentityContext -OutputDir Identity/Migrations
Update-Database -Context PeopleLinkIdentityContext
Remove-Migration -Context PeopleLinkIdentityContext
Update-Database 0 -Context PeopleLinkIdentityContext




```
