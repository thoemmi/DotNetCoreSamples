using SelfHosted.WebApi;
using System;
using System.Threading.Tasks;

namespace SelfHosted.Console
{
    public class WebApiApplication : IApplication
    {
        public void Start()
        {
            System.Console.WriteLine("WebApi is starting ...");


            WebApiModule module = new WebApiModule();
            Task.Run(() => module.StartAsync());
        }
    }
}
