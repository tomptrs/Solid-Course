using System;
using System.Collections.Generic;
using System.Text;
using SOLID_Start.Prijs;

namespace SOLID_Start
{
    public class Movie
    {
        
    
        public string Title { get; set; }
        public PrijsT Prijs { get; set; }

        public Movie(string title)
        {
            this.Title = title;
          
        }

        public  double RekeningVoor(int AantalDagen)
        {
            return this.Prijs.Bereken(AantalDagen);
        }
    }
}
