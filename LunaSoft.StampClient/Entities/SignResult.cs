using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunaSoft.StampClient.Entities
{
    public class SignResult : Base.BLBaseClass
    {
        private string xmlSigned;

        public string XmlSigned
        {
            get { return xmlSigned; }
            set { xmlSigned = value; }
        }
        private Comprobante invoiceSigned;

        public Comprobante InvoiceSigned
        {
            get { return invoiceSigned; }
            set { invoiceSigned = value; }
        }
    }
}
