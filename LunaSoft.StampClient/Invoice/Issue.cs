using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LunaSoft.StampClient.Invoice
{
    internal class Issue
    {
       /// <summary>
        /// Emision factura CFDI 3.2
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        internal Entities.Comprobante Sign(Entities.Comprobante invoice, byte[] PFX, string password)
        {

            //removemos la addenda
            var addendaElement = new Entities.ComprobanteAddenda();
            if (invoice.Addenda != null)
            {
                addendaElement.Any = invoice.Addenda.Any;
                invoice.Addenda = null;
            }
            //serializamos el documento
            string xmlSign = Implement.SerializeFiscalDocument.Invoice(invoice);

            //obtenemos la cadena original
            var originalChain = Xslt.GetOriginalChainCFDI(xmlSign);

            //Sellamos el Documento
            var signedInvoice = new SignInvoice().Sign(originalChain, password, PFX);

            //Asignamos el resultado al documento
            invoice.noCertificado = signedInvoice.CertificateNumber;
            invoice.sello = signedInvoice.DigitalSeal;
            invoice.certificado = signedInvoice.Certificate;

            if (addendaElement.Any != null)
            {
                invoice.Addenda = addendaElement;
            }

            return invoice;
        }
    }
}
