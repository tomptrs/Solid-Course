using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Persistentie
{
    interface IKlantSource
    {
        string GetKlantFromSource(string klant);
    }
}
