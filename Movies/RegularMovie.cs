using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Movies
{
    public class RegularMovie : Movie
    {
        public RegularMovie(string title, int priceCode) : base(title, priceCode)
        {


        }
        public override double RekeningVoor(int AantalDagen)
        {
            double thisAmount = 0;
            
                    thisAmount += 2;
                    if (AantalDagen > 2)
                    {
                        thisAmount += (AantalDagen - 2) * 1.5;
                    }
            return thisAmount;
        }
    }
}
