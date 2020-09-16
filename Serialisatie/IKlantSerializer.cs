using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Serialisatie
{
    interface IKlantSerializer
    {
        Klant GetSerializedKlant(string jsonString);
    }
}
