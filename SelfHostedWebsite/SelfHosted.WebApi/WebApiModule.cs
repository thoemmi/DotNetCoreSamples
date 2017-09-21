using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SelfHosted.WebApi
{
    public class WebApiModule
    {
        private IWebHost _host;

        public Task StartAsync()
        {
            _host = new WebHostBuilder()
               .UseKestrel()
               .UseUrls("http://localhost:5004")
               .UseContentRoot(Path.GetDirectoryName(GetType().Assembly.Location))
               .UseIISIntegration()
               .UseStartup<Startup>()
               .Build();

            _host.Run();

            return Task.CompletedTask;
        }
    }
}
