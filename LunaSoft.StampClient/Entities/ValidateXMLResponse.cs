using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunaSoft.StampClient.Entities
{
    public class ValidateXMLResponse : Base.BLBaseClass
    {
        public string xmlValid { get; set; }
        public Entities.Comprobante cfdi { get; set; }        
        public Entities.TimbreFiscalDigital tfd { get; set; }
    }
}
