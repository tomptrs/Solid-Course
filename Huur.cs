using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SOLID_Start
{
    class Huur
    {
        public Movie Movie { get; set; }
        public int AantalDagen { get; set; }
        public Huur(Movie movie, int aantalDagen)
        {
            this.Movie = movie;
            this.AantalDagen = aantalDagen;
        }
    }
}
