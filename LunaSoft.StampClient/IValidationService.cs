using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunaSoft.StampClient
{
    public interface IValidationService
    {
        Entities.ValidateCerResponse ValidateCertificate(byte[] bCER, string rfc, byte[] bKEY, string password);
        Entities.ValidateCerResponse ValidatePublicKey(byte[] bCER);
        Entities.ValidateCerResponse ValidateCertificatePassword(byte[] bCER, string rfc, byte[] bKEY, string password);
        Entities.ValidateXMLResponse ValidateXMLInvoice(Entities.Comprobante invoice);
        Entities.ValidateXMLResponse ValidateXMLSignInvoice(Entities.Comprobante invoice);
        Entities.Comprobante LoadInvoice(string xml);
    }
}
