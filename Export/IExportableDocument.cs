using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Export
{
    interface IExportableDocument
    {
        string ToText();
        byte[] ToPdf();
    }
}
