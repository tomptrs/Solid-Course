using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Serialisatie
{
    class JsonKlantSerializer
    {
        public Klant GetKlantFromJsonString(string jsonString)
        {
            return JsonConvert.DeserializeObject<Klant>(jsonString, new StringEnumConverter());
        }
    }
}
