using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SelfHosted.Website
{
    public class WebModule
    {
        private IWebHost _host;

        public Task StartAsync()
        {
            _host = new WebHostBuilder()
               .UseKestrel()
               .UseUrls("http://localhost:5003")
               .UseContentRoot(Path.GetDirectoryName(GetType().Assembly.Location))
               .UseIISIntegration()
               .UseStartup<Startup>()
               .Build();

            _host.Run();

            return Task.CompletedTask;
        }

    }
}
