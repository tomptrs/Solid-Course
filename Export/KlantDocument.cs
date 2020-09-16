using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Export
{
    class KlantDocument : IExportableDocument
    {
        Klant klant;
        public KlantDocument(Klant klant)
        {
            this.klant = klant;
        }

        public byte[] ToPdf()
        {
            throw new NotImplementedException();
        }

        public string ToText()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("klant:").Append(klant.Naam);
            klant.movies.ForEach(klant =>
            {
                sb.Append("gehuurde film:").Append(klant.Movie.Title);
            });
            return sb.ToString();
        }
    }
}
