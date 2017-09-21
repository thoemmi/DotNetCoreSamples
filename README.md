# DotNetCoreSamples
Some .net core and standard examples


## Inital database creation ##

1. Change connection string to your database server in SelfHosted.DataAccess.DataContextFactory
    ```var builder = new DbContextOptionsBuilder<DataContext>();builder.UseSqlServer("Server=(local);Initial Catalog=SelfHostedDb;Trusted_Connection=True;");```