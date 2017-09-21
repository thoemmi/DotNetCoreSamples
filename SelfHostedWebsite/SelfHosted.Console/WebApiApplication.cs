using SelfHosted.WebApi;
using System;
using System.Threading.Tasks;

namespace SelfHosted.Console
{
    public class WebApiApplication : IApplication
    {
        public void Start()
        {
            WebApiModule module = new WebApiModule();
            Task.Run(() => module.StartAsync());

            System.Console.WriteLine("  WebApi is started.");
        }

        public void Stop()
        {
            System.Console.WriteLine("  WebApi is stoped.");
        }
    }
}
