using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SOLID_Start.Loggen;
using SOLID_Start.Persistentie;
using SOLID_Start.Serialisatie;
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
        FileKlantSource fileKlantSource;
        JsonKlantSerializer jsonKlantSerializer;
        public Processor()
        {
            logger = new Logger();
            fileKlantSource = new FileKlantSource();
            jsonKlantSerializer = new JsonKlantSerializer();
        }
        public void Process()
        {
            List<Klant> klanten = new List<Klant>();

            string json = fileKlantSource.GetKlantFromFile("peeters");
            var peeters = jsonKlantSerializer.GetKlantFromJsonString(json);

            if (String.IsNullOrEmpty(peeters.Naam))
            {
                logger.Log("Klant moet een naam hebben");
            }
            else
            {
                peeters.AddMovie(new Huur(new Movie("Godfather", 1), 3));
                klanten.Add(peeters);
            }

             json = fileKlantSource.GetKlantFromFile("vandeperre");
            var vandeperre = JsonConvert.DeserializeObject<Klant>(json, new StringEnumConverter());
            if (String.IsNullOrEmpty(vandeperre.Naam))
            {
                logger.Log("Klant moet een naam hebben");
            }
            else
            {
                vandeperre.AddMovie(new Huur(new Movie("Lion King", 2), 2));
                klanten.Add(vandeperre);
            }



            json = fileKlantSource.GetKlantFromFile("verlinden");
            var verlinden = JsonConvert.DeserializeObject<Klant>(json, new StringEnumConverter());
            if (String.IsNullOrEmpty(verlinden.Naam))
            {
                logger.Log("Klant moet een naam hebben");
            }
            else
            {
                verlinden.AddMovie(new Huur(new Movie("Rundskop", 1), 4));
                klanten.Add(verlinden);
            }



            json = fileKlantSource.GetKlantFromFile("dams");
            var dams = JsonConvert.DeserializeObject<Klant>(json, new StringEnumConverter());
            if (String.IsNullOrEmpty(dams.Naam))
            {
                logger.Log("Klant moet een naam hebben");
            }
            else
            {
                dams.AddMovie(new Huur(new Movie("Top Gun", 3), 1));
                klanten.Add(dams);
            }

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
