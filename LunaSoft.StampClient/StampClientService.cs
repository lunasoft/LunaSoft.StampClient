using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunaSoft.StampClient
{
    public class StampClientService : IStampClientService
    {
        /// <summary>
        /// Sella factura a partir de un objeto Comprobante.
        /// </summary>
        /// <param name="bCer"></param>
        /// <param name="bKey"></param>
        /// <param name="password"></param>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public Entities.SignResult SignInvoice(byte[] bCer, byte[] bKey, string password, Entities.Comprobante invoice)
        {
            Entities.SignResult res = new Entities.SignResult();
            try
            {
                ValidationService validation = new ValidationService();
                //Normalizamos CFDI
                Implement.Normalize.CFDI(ref invoice);

                //Validamos el Comprobante
                var valid = validation.ValidateXMLInvoice(invoice);
                if (valid.HasError)
                {
                    throw new Exception(valid.ErrorMessage.Replace("|", " ."));
                }
                //Obtenemos el PFX
                byte[] pfx = CSD.MakeCert.generatePFX(bCer, bKey, password);
                //Sellamos la factura
                res.InvoiceSigned = new Invoice.Issue().Sign(invoice, pfx, password);
                res.XmlSigned = Implement.SerializeFiscalDocument.Invoice(res.InvoiceSigned);
            }
            catch (Exception ex)
            {
                res.AddError("Factura Sello- " + ex.Message);
            }
            return res;
        }
        /// <summary>
        /// Sella factura a partir de un xml.
        /// </summary>
        /// <param name="bCer"></param>
        /// <param name="bKey"></param>
        /// <param name="password"></param>
        /// <param name="xmlInvoice"></param>
        /// <param name="rfcEmisor"></param>
        /// <returns></returns>
        public Entities.SignResult SignInvoice(byte[] bCer, byte[] bKey, string password, string xmlInvoice, string rfcEmisor)
        {
            Entities.SignResult res = new Entities.SignResult();
            try
            {
                ValidationService validation = new ValidationService();
                var invoice = validation.LoadInvoice(xmlInvoice);
                //Normalizamos CFDI
                Implement.Normalize.CFDI(ref invoice);

                //Validamos el Comprobante
                var valid = validation.ValidateXMLInvoice(invoice);
                if (valid.HasError)
                {
                    throw new Exception(valid.ErrorMessage.Replace("|", " ."));
                }
                //Obtenemos el PFX
                byte[] pfx = CSD.MakeCert.generatePFX(bCer, bKey, password);
                //Sellamos la factura
                res.InvoiceSigned = new Invoice.Issue().Sign(invoice, pfx, password);
                res.XmlSigned = Implement.SerializeFiscalDocument.Invoice(res.InvoiceSigned);
            }
            catch (Exception ex)
            {
                res.AddError("Factura Sello- " + ex.Message);
            }
            return res;
        }
        /// <summary>
        /// Timbra factura a traves de Luna Soft PCC desde un objeto comprobante.
        /// </summary>
        /// <param name="invoiceStamped"></param>
        /// <returns></returns>
        public Entities.StampResult Stamp(Entities.Comprobante invoice)
        {
            Entities.StampResult res = new Entities.StampResult();
            try
            {
                //Validamos la factura
                ValidationService validation = new ValidationService();
                var valid = validation.ValidateXMLSignInvoice(invoice);
                if (valid.HasError)
                {
                    throw new Exception(valid.ErrorMessage.Replace("|", " ."));
                }
                //Timbramos la factura con Luna Soft.
                var broker = new Stamp.BrokerStamping();
                res = broker.StampInvoice(invoice);
            }
            catch (Exception ex)
            {
                res.AddError("Factura - " + ex.Message);
            }
            return res;
        }
        /// <summary>
        /// Timbra factura a traves de Luna Soft PCC desde un xml.
        /// </summary>
        /// <param name="xmlInvoice"></param>
        /// <returns></returns>
        public Entities.StampResult Stamp(string xmlInvoice)
        {
            Entities.StampResult res = new Entities.StampResult();
            try
            {
                //Validamos la factura
                ValidationService validation = new ValidationService();
                var invoiceSigned = validation.LoadInvoice(xmlInvoice);
                var valid = validation.ValidateXMLSignInvoice(invoiceSigned);
                if (valid.HasError)
                {
                    throw new Exception(valid.ErrorMessage.Replace("|", " ."));
                }
                //Timbramos la factura con Luna Soft.
                var broker = new Stamp.BrokerStamping();
                res = broker.StampInvoice(invoiceSigned);
            }
            catch (Exception ex)
            {
                res.AddError("Factura - " + ex.Message);
            }
            return res;
        }

        public Entities.CancelResult Cancel(string UUID, string rfc, byte[] bCer, byte[] bKey, string password)
        {
            Entities.CancelResult res = new Entities.CancelResult();
            try
            {
                //Obtenemos el PFX
                byte[] pfx = CSD.MakeCert.generatePFX(bCer, bKey, password);
                //Cancelamos la factura con Luna Soft.
                var broker = new Stamp.BrokerStamping();
                res = broker.CancelInvoice(UUID, rfc, pfx, password);
            }
            catch (Exception ex)
            {
                res.AddError("Cancelación - " + ex.Message);
            }
            return res;
        }
    }
}
