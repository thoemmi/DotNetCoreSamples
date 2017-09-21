using SelfHosted.Website;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SelfHosted.Console
{
    public class WebApplication : IApplication
    {
        public void Start()
        {
            System.Console.WriteLine("WebSite is starting ...");

            WebModule module = new WebModule();
            Task.Run(() => module.StartAsync());
        }
    }
}
