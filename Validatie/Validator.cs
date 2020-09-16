using SOLID_Start.Loggen;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Validatie
{
    abstract class Validator<T>
    {
        ILogger logger;
      
   
        public Validator( ILogger logger)
        {
            this.logger = logger;
            
        }
        public abstract bool Validate(T type);


    }
}
