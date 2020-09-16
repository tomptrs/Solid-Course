using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Prijs
{
    public class NewReleasePrijs : PrijsT
    {
        public override double Bereken(int aantalDagen)
        {
            double thisAmount = 0;

            thisAmount += aantalDagen * 3;

            return thisAmount;
        }
    }
}
