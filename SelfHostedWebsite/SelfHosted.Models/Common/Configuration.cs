using System;
using System.Collections.Generic;
using System.Text;

namespace SelfHosted.Models.Common
{
    public class Configuration
    {
        public Service Services { get; set; }
    }

    public class Service
    {
        public string WebApiUrl { get; set; }
    }
}
