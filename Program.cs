using System;
using System.Collections.Generic;

namespace SOLID_Start
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo-Application

            List<Klant> klanten = new List<Klant>();
            Klant k = new Klant("Peeters");

            k.AddMovie(new Huur(new Movie("Godfather", 1), 3));
            klanten.Add(k);

            Klant k2 = new Klant("Vandeperre");
            k2.AddMovie(new Huur(new Movie("Lion King", 2), 2));
            klanten.Add(k2);


            Klant c3 = new Klant("Verlinden");
            c3.AddMovie(new Huur(new Movie("Rundskop", 1), 4));
            klanten.Add(c3);


            Klant c4 = new Klant("Dams");
            c4.AddMovie(new Huur(new Movie("Top Gun", 3), 1));
            klanten.Add(c4);

            foreach (Klant klant in klanten)
            {
                Console.WriteLine(klant.GetRekening());
            }

            Console.ReadLine();
        }
    }
}
