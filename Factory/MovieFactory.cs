using SOLID_Start.Movies;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Factory
{
    class MovieFactory
    {

        public Movie Create(string type, string movie_name)
        {

            try
            {
                Movie m= (Movie)Activator.CreateInstance(Type.GetType($"SOLID_Start.Movies.{type}"), new Object[] { movie_name });
                return m;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
