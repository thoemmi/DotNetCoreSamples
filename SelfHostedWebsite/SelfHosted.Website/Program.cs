using Microsoft.AspNetCore.Hosting;
using SelfHosted.Website;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SelfHosted.Website
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebHost _host = new WebHostBuilder()
               .UseKestrel()
               .UseUrls("http://localhost:5002")
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseIISIntegration()
               .UseStartup<Startup>()
               .Build();

            _host.Run();
        }
    }
}
