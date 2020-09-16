using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start
{
    class Movie
    {
        public const int CHILDREN = 1;
        public const int REGULAR = 2;
        public const int NEW_RELEASE = 3;

        public int PriceCode { get; set; }
        public string Title { get; set; }
        public Movie(string title, int priceCode)
        {
            this.Title = title;
            this.PriceCode = priceCode;
        }

        public double RekeningVoor(int AantalDagen)
        {
            double thisAmount = 0;
            switch (PriceCode)
            {
                case REGULAR:
                    thisAmount += 2;
                    if (AantalDagen > 2)
                    {
                        thisAmount += (AantalDagen - 2) * 1.5;
                    }
                    break;

                case NEW_RELEASE:
                    thisAmount += AantalDagen * 3;
                    break;

                case CHILDREN:
                    thisAmount += 1.5;
                    if (AantalDagen > 3)
                    {
                        thisAmount += (AantalDagen - 3) * 1.2;
                    }
                    break;
            }
            return thisAmount;
        }
    }
}
