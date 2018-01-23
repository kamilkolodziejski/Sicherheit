using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicherheitCore.Services
{
    public interface ILogger
    {
        void Log(String message);
        void Debug(String message);
    }
}
