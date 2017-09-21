using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using PeterKottas.DotNetCore.WindowsService.Base;
using PeterKottas.DotNetCore.WindowsService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfHosted.Console.WindowsService
{
    public class SelfHostedWindowService : MicroService, IMicroService
    {
        private IServiceProvider _provider;

        public void Start()
        {
            this.StartBase();

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

            _provider = new AutofacServiceProvider(applicationContainer);

            foreach (var app in _provider.GetServices<IApplication>())
            {
                app.Start();
            }

            System.Console.WriteLine("Windows services started.");
        }

        public void Stop()
        {
            this.StopBase();

            foreach (var app in _provider.GetServices<IApplication>())
            {
                app.Stop();
            }

            System.Console.WriteLine("Windows services stopped.");
        }
    }
}
