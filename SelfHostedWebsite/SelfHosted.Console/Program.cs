using Microsoft.Extensions.DependencyInjection;
using SelfHosted.Website;
using System;

namespace SelfHosted.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IApplication, WebApplication>();
            serviceCollection.AddSingleton<IApplication, WebApiApplication>();

            var provider = serviceCollection.BuildServiceProvider();

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
