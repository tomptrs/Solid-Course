using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start
{
    class ChildrenMovie:Movie
    {
        public ChildrenMovie(string title, int priceCode):base(title,priceCode)
        {
          
        }
        public override double RekeningVoor(int AantalDagen)
        {
            double thisAmount = 0;

            thisAmount += 1.5;
            if (AantalDagen > 3)
            {
                thisAmount += (AantalDagen - 3) * 1.2;
            }
            return thisAmount;
        }
    }
}
