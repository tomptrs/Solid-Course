using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Movies
{
    public class NewReleaseMovie:Movie
    {
        public NewReleaseMovie(string title) : base(title)
        {

        }
        public override double RekeningVoor(int AantalDagen)
        {
            double thisAmount = 0;

            thisAmount += AantalDagen * 3;

            return thisAmount;
        }
    }
}
