using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Prijs
{
    public class ChildrenPrijs : PrijsT
    {
        public override double Bereken(int aantalDagen)
        {
            double thisAmount = 0;

            thisAmount += 1.5;
            if (aantalDagen > 3)
            {
                thisAmount += (aantalDagen - 3) * 1.2;
            }
            return thisAmount;
        }
    }
}
