using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SelfHosted.DataAccess.Repository;
using SelfHosted.DataAccess.SqlDataContext;
using SelfHosted.Models.Interfaces;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace SelfHosted.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration["ConnectionStrings:SelfHostedSqlDatabase"]));

            //services.Configure<MoneyTrackerOptions>(Configuration);

            // register IUserRepo in ioc container from .net core
            //services.AddSingleton<IUserRepository, UserRepository>();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new Info { Title = "My SelfHosted API", Version = "v2" });
            });

            services.AddMvc();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();
            this.ApplicationContainer = containerBuilder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            loggerFactory.ConfigureNLog("nLogConfigFiles/nlog_webapi.config");

            //loggerFactory.AddConsole();
            //loggerFactory.AddDebug();

            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseCors("MyPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "My SelfHosted V1");
            });

            app.UseMvc();
        }

    }
}
