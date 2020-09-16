using SOLID_Start.Loggen;
using System;
using System.Collections.Generic;

namespace SOLID_Start
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo-Application
            ILogger logger = new Logger();
            Processor processor = new Processor(logger);
            processor.Process();

            Console.ReadLine();
        }
    }
}
