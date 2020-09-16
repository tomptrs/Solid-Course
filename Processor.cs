﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SOLID_Start.Factory;
using SOLID_Start.Loggen;
using SOLID_Start.Messaging;
using SOLID_Start.Movies;
using SOLID_Start.Persistentie;
using SOLID_Start.Serialisatie;
using SOLID_Start.Validatie;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;

namespace SOLID_Start
{
    class Processor
    {
        ILogger logger;
        IKlantSource fileKlantSource;
        IKlantSerializer klantSerializer;
        List<Klant> klanten = new List<Klant>();
        MovieFactory movieFactory;
        Validator<Klant> validator;
        MailMessaging mailMessenger;

        public Processor(ILogger logger, IKlantSource klantSource,IKlantSerializer serializer, Validator<Klant> validator)
        {
            this.logger = logger;
            this.fileKlantSource = klantSource;
            this.klantSerializer = serializer;
            this.validator = validator;           
           
            movieFactory = new MovieFactory();
         
            mailMessenger = new MailMessaging();

        }

       
        public void Process()
        {          
           
            ProcessKlant(SerializeKlant(ReadFile("peeters")),"The Godfather","Regular",3);
            ProcessKlant(SerializeKlant(ReadFile("vandeperre")), "Lion King","Children", 2);
            ProcessKlant(SerializeKlant(ReadFile("verlinden")), "Rundskop", "NewRelease", 4);
            ProcessKlant(SerializeKlant(ReadFile("dams")), "Top Gun", "Regular",2);          

            logger.Log("start berekenen prijs");
            foreach (Klant klant in klanten)
            {

                logger.Log(klant.GetRekening());
                mailMessenger.SendComfirmationMessage(klant);
            }
            logger.Log("einde berekening...");
                        
        }

        private string ReadFile(string klant_naam)
        {
            string json = fileKlantSource.GetKlantFromSource(klant_naam);
            return json;
        }

        private Klant SerializeKlant(string jsonObject)
        {
            return klantSerializer.GetSerializedKlant(jsonObject);
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

            var movie = new Movie(movie_name);//movieFactory.Create(type,movie_name);1
           
            PrijsFactory factory = new PrijsFactory();
            movie.Prijs = factory.Create(type);

            klant.AddMovie(new Huur(movie, aantalDagen));
            klanten.Add(klant);
            

        }

       

      
    }
}
