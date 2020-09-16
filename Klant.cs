using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start
{
    class Klant
    {
        List<Huur> movies = new List<Huur>();
        public string Naam { get; set; }
        public Klant(string naam)
        {
            this.Naam = naam;
        }

        public void AddMovie(Huur huur)
        {
            movies.Add(huur);
        }

        public double RekeningVoor(Huur h)
        {
            return h.RekeningVoor();
           
        }

        public string GetRekening()
        {
            double totalAmount = 0;

            string result = "Huur Record for " + Naam + "\n";

            foreach (Huur h in movies)
            {

                double thisAmount = RekeningVoor(h);
                //Show figures for this rental 
                result += "\t" + h.Movie.Title + "\t" + thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }

            //Add footer lines 
            result += "Amount owned is " + totalAmount.ToString() + "\n";

            return result;
        }
    }
}
