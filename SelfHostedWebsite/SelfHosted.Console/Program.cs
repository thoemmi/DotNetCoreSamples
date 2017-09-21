using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using PeterKottas.DotNetCore.WindowsService;
using SelfHosted.Console.WindowsService;
using SelfHosted.Website;
using System;

namespace SelfHosted.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Available commands on startup:");
            System.Console.WriteLine("  action:install      //install the service");
            System.Console.WriteLine("  action:uninstall    //uninstall the service");
            System.Console.WriteLine("  action:start        //start the service");
            System.Console.WriteLine("  action:stop         //stop the service");
            System.Console.WriteLine(Environment.NewLine);
            System.Console.ForegroundColor = ConsoleColor.Gray;


            // Run as windows service with https://github.com/PeterKottas/DotNetCore.WindowsService
            ServiceRunner<SelfHostedWindowService>.Run(config =>
            {
                var serviceName = "SelfHosted.WindowsService";

                config.SetName(serviceName);
                config.Service(serviceConfig =>
                {
                    serviceConfig.ServiceFactory((service, extraArguments) =>
                    {
                        return new SelfHostedWindowService();
                    });

                    serviceConfig.OnStart((service, extraArguments) =>
                    {
                        System.Console.WriteLine("Service {0} started", serviceName);
                        service.Start();
                    });

                    serviceConfig.OnStop((service) =>
                    {
                        System.Console.WriteLine("Service {0} stopped", serviceName);
                        service.Stop();
                    });

                    serviceConfig.OnError(e =>
                    {
                        System.Console.WriteLine($"Service '{serviceName}' errored with exception : {e.Message}");
                    });
                });
            });

            System.Console.WriteLine("All applications started. Press any key to stop.");
            System.Console.WriteLine(Environment.NewLine);
            System.Console.ReadKey();
        }
    }
}
