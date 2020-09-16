using SOLID_Start.Loggen;
using SOLID_Start.Persistentie;
using SOLID_Start.Serialisatie;
using SOLID_Start.Validatie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SOLID_Start
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo-Application
            ILogger logger = new Logger();
            IKlantSource source = new FileKlantSource();
            IKlantSerializer serializer = new JsonKlantSerializer();
            Validator<Klant> validator = new KlantValidator(logger);
            Processor processor = new Processor(logger,source, serializer,validator);
            processor.Process();

            Console.ReadLine();
        }
    }
}
