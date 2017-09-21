# DotNetCoreSamples
Some .net core and standard examples


## Inital database creation ##

1. Change connection string to your database server in SelfHosted.DataAccess.DataContextFactory

    ```var builder = new DbContextOptionsBuilder<DataContext>();builder.UseSqlServer("Server=(local);Initial Catalog=SelfHostedDb;Trusted_Connection=True;");```

2. Execute the following commands:

    ```dotnet ef migrations add InitialCreate --startup-project ..\SelfHosted.Console\```
    ```dotnet ef database update --startup-project ..\SelfHosted.Console\```