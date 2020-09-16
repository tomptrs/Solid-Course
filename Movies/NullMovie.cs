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

      
    }
}
