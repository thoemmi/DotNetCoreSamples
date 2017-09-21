# DotNetCoreSamples
Some .net core and standard examples


## Initial database creation ##

1. Change connection string to your database server in SelfHosted.DataAccess.DataContextFactory

    ```builder.UseSqlServer("Server=(local);Initial Catalog=SelfHostedDb;Trusted_Connection=True;");```

2. Executing the following commands:

    ```dotnet ef migrations add InitialCreate --startup-project ..\SelfHosted.Console\```
    
    ```dotnet ef database update --startup-project ..\SelfHosted.Console\```
