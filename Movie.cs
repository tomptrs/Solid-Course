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
    }
}
