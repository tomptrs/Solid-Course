using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Loggen
{
    class Logger:ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message) ;
        }
    }
}
