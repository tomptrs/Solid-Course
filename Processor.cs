using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SOLID_Start.Loggen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace SOLID_Start
{
    class Processor
    {
        Logger logger;
        public Processor()
        {
            logger = new Logger();
        }
        public void Process()
        {
            List<Klant> klanten = new List<Klant>();

            string json = File.ReadAllText("./peeters.json"); 
            var peeters = JsonConvert.DeserializeObject<Klant>(json, new StringEnumConverter());
            if(String.IsNullOrEmpty(peeters.Naam))
            {
                logger.Log("Klant moet een naam hebben");
            }           
            peeters.AddMovie(new Huur(new Movie("Godfather", 1), 3));
            klanten.Add(peeters);

            json = File.ReadAllText("./vandeperre.json");
            var vandeperre = JsonConvert.DeserializeObject<Klant>(json, new StringEnumConverter());
            if (String.IsNullOrEmpty(vandeperre.Naam))
            {
                logger.Log("Klant moet een naam hebben");
            }
            vandeperre.AddMovie(new Huur(new Movie("Lion King", 2), 2));
            klanten.Add(vandeperre);


            json = File.ReadAllText("./verlinden.json");
            var verlinden = JsonConvert.DeserializeObject<Klant>(json, new StringEnumConverter());
            if (String.IsNullOrEmpty(verlinden.Naam))
            {
                logger.Log("Klant moet een naam hebben");
            }
            verlinden.AddMovie(new Huur(new Movie("Rundskop", 1), 4));
            klanten.Add(verlinden);


            json = File.ReadAllText("./dams.json");
            var dams = JsonConvert.DeserializeObject<Klant>(json, new StringEnumConverter());
            if (String.IsNullOrEmpty(dams.Naam))
            {
                logger.Log("Klant moet een naam hebben");
            }
            dams.AddMovie(new Huur(new Movie("Top Gun", 3), 1));
            klanten.Add(dams);

            logger.Log("start berekenen prijs");
            foreach (Klant klant in klanten)
            {
                logger.Log(klant.GetRekening());
                SendComfirmationMessage(klant);
            }
            logger.Log("einde berekening...");

            
        }

        private void SendComfirmationMessage(Klant klant)
        {
            logger.Log("stuur een mail naar de klant");
            logger.Log("SENDING MAIL...");
        }
    }
}
