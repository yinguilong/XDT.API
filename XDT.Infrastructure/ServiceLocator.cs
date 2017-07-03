using System;
using System.Collections.Generic;
using System.Text;

namespace XDT.Infrastructure
{
    public class ServiceLocator
    {
        public static IServiceProvider Instance { get; set; }
    }
}
