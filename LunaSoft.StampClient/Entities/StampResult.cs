using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunaSoft.StampClient.Entities
{
    public class StampResult : Base.BLBaseClass
    {
        private TimbreFiscalDigital tfd;
        private string xmlStamped;

        public string XmlStamped
        {
            get { return xmlStamped; }
            set { xmlStamped = value; }
        }
        private Comprobante invoiceStamped;

        public Comprobante InvoiceStamped
        {
            get { return invoiceStamped; }
            set { invoiceStamped = value; }
        }        
        public TimbreFiscalDigital TFD
        {
            get { return tfd; }
            set { tfd = value; }
        }
    }

    public class CancelResult : Base.BLBaseClass
    {
        private string xmlResult;

        public string XmlResult
        {
            get { return xmlResult; }
            set { xmlResult = value; }
        }
    }
}
