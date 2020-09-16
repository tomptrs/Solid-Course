using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Prijs
{
    public class RegularPrijs : PrijsT
    {
        public override double Bereken(int aantalDagen)
        {
            double thisAmount = 0;

            thisAmount += 2;
            if (aantalDagen > 2)
            {
                thisAmount += (aantalDagen - 2) * 1.5;
            }
            return thisAmount;
        }
    }
}
