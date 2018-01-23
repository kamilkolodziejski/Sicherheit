using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicherheitCore.Services.Concret
{
    public class SimplyLogger : ILogger
    {
        public void Debug(string message)
        {
            System.Diagnostics.Debug.WriteLine($"[ DEBUG | {DateTime.Now} ] {message}");
        }

        public void Log(string message)
        {
            System.Diagnostics.Debug.WriteLine($"[ LOG | {DateTime.Now} ] {message}");
        }
    }
}
