using SOLID_Start.Loggen;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Movies
{
    class NullMovie:Movie
    {
        Logger logger;
        public NullMovie(string movie_name):base(movie_name)
        {
            logger = new Logger();
        }

        public override double RekeningVoor(int AantalDagen)
        {
            logger.Log("unknown movie type");
            return 0;
        }
    }
}
