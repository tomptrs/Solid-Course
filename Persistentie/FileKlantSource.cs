using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLID_Start.Persistentie
{
    class FileKlantSource:IKlantSource
    {


        public string GetKlantFromSource(string klant)
        {
            return File.ReadAllText($"{klant}.json");
        }
    }
}
