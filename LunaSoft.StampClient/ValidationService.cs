using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunaSoft.StampClient
{
    public class ValidationService : IValidationService
    {
        /// <summary>
        /// Metodo para la validación del Certificado Publico y Llave Privada del SAT.
        /// </summary>
        /// <param name="bCER"></param>
        /// <param name="rfc"></param>
        /// <param name="bKEY"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Entities.ValidateCerResponse ValidateCertificate(byte[] bCER, string rfc, byte[] bKEY, string password)
        {
            var res = new Entities.ValidateCerResponse();
            try
            {
                var validate = new CSD.ValidateCSD();
                res = validate.Certificate(bCER, rfc, bKEY, password);
            }
            catch (Exception ex)
            {
                res.AddError("Error no Controlado: " + ex.Message);
            }
            return res;
        }
        /// <summary>
        /// Metodo para la validacion del Certificado Publico del SAT.
        /// </summary>
        /// <param name="bCER"></param>
        /// <returns></returns>
        public Entities.ValidateCerResponse ValidatePublicKey(byte[] bCER)
        {
            var res = new Entities.ValidateCerResponse();
            try
            {
                var validate = new CSD.ValidateCSD();
                res = validate.Certificate(bCER);
            }
            catch (Exception ex)
            {
                res.AddError("Error no Controlado: " + ex.Message);
            }
            return res;
        }
        /// <summary>
        /// Valida RFC y Password corresponda al Certificado/FIEL.
        /// </summary>
        /// <param name="bCER"></param>
        /// <param name="rfc"></param>
        /// <param name="bKEY"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Entities.ValidateCerResponse ValidateCertificatePassword(byte[] bCER, string rfc, byte[] bKEY, string password)
        {
            var res = new Entities.ValidateCerResponse();
            try
            {
                var validate = new CSD.ValidateCSD();
                res = validate.ValidateCertificatePassword(bCER, rfc, bKEY, password);
            }
            catch (Exception ex)
            {
                res.AddError("Error no Controlado: " + ex.Message);
            }
            return res;
        }
        /// <summary>
        /// Valida el CFDI solamente su estructura.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public Entities.ValidateXMLResponse ValidateXMLInvoice(Entities.Comprobante invoice)
        {
            var res = new Entities.ValidateXMLResponse();
            try
            {
                var validate = new Invoice.ValidateCFDI();
                res = validate.ValidateInvoiceRemoveAddenda(invoice);
            }
            catch (Exception ex)
            {
                res.AddError("Error no Controlado: " + ex.Message);
            }
            return res;
        }
        /// <summary>
        /// Valida el CFDI , estructura y sello.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public Entities.ValidateXMLResponse ValidateXMLSignInvoice(Entities.Comprobante invoice)
        {
            var res = new Entities.ValidateXMLResponse();
            try
            {
                var validate = new Invoice.ValidateCFDI();
                res = validate.ValidateInvoiceAndSignRemoveAddenda(invoice);
            }
            catch (Exception ex)
            {
                res.AddError("Error no Controlado: " + ex.Message);
            }
            return res;
        }
        /// <summary>
        /// Carga xml y regresa Objecto Comprobante.
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public Entities.Comprobante LoadInvoice(string xml)
        {
            var valid = new Invoice.ValidateCFDI().LoadInvoice(xml);
            if (valid.HasError)
                throw new Exception(valid.ErrorMessage.Replace("|", " ."));

            return valid.cfdi;
        }
    }
}
