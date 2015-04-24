using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaSoft.StampClient.Invoice
{
    internal class SignInvoice
    {
        /// <summary>
        /// Sella Cadena Original CFDI 3.2
        /// </summary>
        /// <param name="originalChain"></param>
        /// <param name="password"></param>
        /// <param name="PFX"></param>
        /// <returns></returns>
        internal Entities.SignDataResult Sign(string originalChain, string password, byte[] PFX)
        {
            var result = new Entities.SignDataResult();

            try
            {
                var cryptoService = new CSD.CryptographicService();
                var res = cryptoService.EncryptPFX(password, PFX, originalChain);

                result.Certificate = res.Certificate;
                result.DigitalSeal = res.DigitalSeal;
                result.CertificateNumber = res.CertificateNumber;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
