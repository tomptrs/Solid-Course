using SOLID_Start.Prijs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Factory
{
    class PrijsFactory
    {
        public PrijsT Create(string type)
        {

            try
            {
                PrijsT p = (PrijsT)Activator.CreateInstance(Type.GetType($"SOLID_Start.Prijs.{type}Prijs"), new Object[] { });
                return p;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
