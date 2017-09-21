using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SelfHosted.Website;
using System;

namespace SelfHosted.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // ioc with .net standard 2.0
            //IServiceCollection serviceCollection = new ServiceCollection();
            //serviceCollection.AddSingleton<IApplication, WebApplication>();
            //serviceCollection.AddSingleton<IApplication, WebApiApplication>();
            //var provider = serviceCollection.BuildServiceProvider();


            // ioc with autofac for .net core
            var builder = new ContainerBuilder();
            builder.RegisterType<WebApplication>().As<IApplication>();
            builder.RegisterType<WebApiApplication>().As<IApplication>();
            var applicationContainer = builder.Build();
            var provider = new AutofacServiceProvider(applicationContainer);

            foreach (var app in provider.GetServices<IApplication>())
            {
                app.Start();
            }

            System.Console.WriteLine("All applications started. Press any key to stop.");
            System.Console.WriteLine(Environment.NewLine);
            System.Console.ReadKey();
           

        }
    }
}
