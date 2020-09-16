using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start
{
    public class Movie
    {
     /*   public const int CHILDREN = 1;
        public const int REGULAR = 2;
        public const int NEW_RELEASE = 3;*/

      //  public int PriceCode { get; set; }
        public string Title { get; set; }
        public Movie(string title)
        {
            this.Title = title;
           // this.PriceCode = priceCode;
        }

        public virtual double RekeningVoor(int AantalDagen)
        {
            return 0;
        }
    }
}
