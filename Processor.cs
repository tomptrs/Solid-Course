using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SOLID_Start.Loggen;
using SOLID_Start.Movies;
using SOLID_Start.Persistentie;
using SOLID_Start.Serialisatie;
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
        public Processor()
        {
            logger = new Logger();
            fileKlantSource = new FileKlantSource();
            jsonKlantSerializer = new JsonKlantSerializer();
        }

       
        public void Process()
        {          
           
            ProcessKlant(SerializeKlant(ReadFile("peeters")),"The Godfather",1,3);
            ProcessKlant(SerializeKlant(ReadFile("vandeperre")), "Lion King",2, 2);
            ProcessKlant(SerializeKlant(ReadFile("verlinden")), "Rundskop", 1, 4);
            ProcessKlant(SerializeKlant(ReadFile("dams")), "Top Gun", 3,2);          

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

        private void ProcessKlant(Klant klant, string movieName, int priceCode, int aantalDagen)
        {
            if (Validate(klant))
            {
                AddMovie(movieName, priceCode, klant, aantalDagen);
            }
        }

        private void AddMovie(string movie_name,int movieType, Klant klant, int aantalDagen)
        {
            Movie movie=null;
            if(movieType == 1)
            {
                movie = new RegularMovie(movie_name);
              
            }
            if (movieType == 2)
            {
                movie = new ChildrenMovie(movie_name);
                
            }
            if (movieType == 3)
            {
                movie = new NewReleaseMovie(movie_name);
              
            }

            
            if (movie != null){
                klant.AddMovie(new Huur(movie, aantalDagen));
                klanten.Add(klant);
            }

        }

        private bool Validate(Klant klant)
        {
            if (String.IsNullOrEmpty(klant.Naam))
            {
                logger.Log("Klant moet een naam hebben");
                return false;
            }
            return true;
        }

        private void SendComfirmationMessage(Klant klant)
        {
            logger.Log("stuur een mail naar de klant");
            logger.Log("SENDING MAIL...");
        }
    }
}
