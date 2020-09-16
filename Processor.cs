using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SOLID_Start.Factory;
using SOLID_Start.Loggen;
using SOLID_Start.Movies;
using SOLID_Start.Persistentie;
using SOLID_Start.Serialisatie;
using SOLID_Start.Validatie;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;

namespace SOLID_Start
{
    class Processor
    {
        Logger logger;
        FileKlantSource fileKlantSource;
        JsonKlantSerializer jsonKlantSerializer;
        List<Klant> klanten = new List<Klant>();
        MovieFactory movieFactory;
        KlantValidatie validator;

        public Processor()
        {
            logger = new Logger();
            fileKlantSource = new FileKlantSource();
            jsonKlantSerializer = new JsonKlantSerializer();
            movieFactory = new MovieFactory();
            validator = new KlantValidatie();
        }

       
        public void Process()
        {          
           
            ProcessKlant(SerializeKlant(ReadFile("peeters")),"The Godfather","RegularMovie",3);
            ProcessKlant(SerializeKlant(ReadFile("vandeperre")), "Lion King","ChildrenMovie", 2);
            ProcessKlant(SerializeKlant(ReadFile("verlinden")), "Rundskop", "NewReleaseMovie", 4);
            ProcessKlant(SerializeKlant(ReadFile("dams")), "Top Gun", "RegularMovie",2);          

            logger.Log("start berekenen prijs");
            foreach (Klant klant in klanten)
            {

                logger.Log(klant.GetRekening());

                SendComfirmationMessage(klant);
            }
            logger.Log("einde berekening...");
                        
        }

        private string ReadFile(string klant_naam)
        {
            string json = fileKlantSource.GetKlantFromFile(klant_naam);
            return json;
        }

        private Klant SerializeKlant(string jsonObject)
        {
            return jsonKlantSerializer.GetKlantFromJsonString(jsonObject);
        }

        private void ProcessKlant(Klant klant, string movieName, string type, int aantalDagen)
        {
            if (validator.Validate(klant))
            {
                AddMovie(movieName, type, klant, aantalDagen);
            }
        }

        private void AddMovie(string movie_name,string type, Klant klant, int aantalDagen)
        {

            var movie = movieFactory.Create(type,movie_name);


            if (movie != null){
                klant.AddMovie(new Huur(movie, aantalDagen));
                klanten.Add(klant);
            }

        }

       

        private void SendComfirmationMessage(Klant klant)
        {
            logger.Log("stuur een mail naar de klant");
            logger.Log("SENDING MAIL...");
        }
    }
}
