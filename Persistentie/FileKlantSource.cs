using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLID_Start.Persistentie
{
    class FileKlantSource
    {

        public string GetKlantFromFile(string klant)
        {
            return File.ReadAllText($"{klant}.json");
        }
    }
}
