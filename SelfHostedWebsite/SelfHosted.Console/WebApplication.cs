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
            WebModule module = new WebModule();
            Task.Run(() => module.StartAsync());

            System.Console.WriteLine("  WebUi is started.");
        }

        public void Stop()
        {
            System.Console.WriteLine("  WebUi is stoped.");
        }
    }
}
