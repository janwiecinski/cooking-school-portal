
https://jw-cookingschool-portal.azurewebsites.net

Login: janwiecinski@gmail.com	
Password: Juniordeveloper$

#cooking-school-portal is an application where you can add, update, select, delete recipes. You can register as a user and log in to the system.

Cooking-school-portal solution consists of four projects:
1. CookingSchool.DAL - data access layer utilizing Code First approach in Entity Framework 6.  It determines interaction with database. There is Generic Repository class that carries out typical CRUD operations on data. It is utilized in business layers of the applications. It uses Package Manager Console and migration to modify database, which as hosted as Azure SQL Database. 

2. CookingSchool .Portal - MVC 5 type application. It directly references CookingSchool.DAL layer. Controllers have Generic Repository objects injected for each model. It uses SimpleInjector and AutoMapper library. Application uses cookie authentication mode with Azure AD B2C. It is hosted in Azure App Service.

3. CookingSchool .Tests - includes unit tests for application using xUnit and Moq Library.

https://jw-cookingschool-api.azurewebsites.net

4. CookingSchool.WebApi –Web API 2 type application. It mediates between frontend applications (cooking-school-admin Angular 4 application) and CookingSchool.DAL layer. It has no connection to portal application. Api Controllers have Generic Repository objects for each model injected. For dependency injection there is SimpleInjector used. AutoMapper is used for data mapping. Application uses token authentication mode with Azure AD B2C. It is hosted on Azure Cloud as App Service.

