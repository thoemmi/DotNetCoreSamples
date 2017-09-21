using System;


namespace SelfHosted.Console
{
    public class WebApiApplication : IApplication
    {
        public void Start()
        {
            System.Console.WriteLine("WebApi is starting ...");
        }
    }
}
