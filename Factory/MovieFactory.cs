using SOLID_Start.Movies;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Factory
{
    class MovieFactory
    {

        public Movie Create(int movieType, string movie_name)
        {
            Movie movie = null;
            if (movieType == 1)
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

            return movie;
        }
    }
}
