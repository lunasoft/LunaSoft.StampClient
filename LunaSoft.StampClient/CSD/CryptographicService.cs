using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LunaSoft.StampClient.CSD
{
    internal class CryptographicService
    {
        internal Entities.SignDataResult EncryptPFX(String password, byte[] PFX, string strToSign)
        {
            var signData = new Entities.SignDataResult();

            try
            {
                X509Certificate2 certX509 = default(X509Certificate2);
                RSACryptoServiceProvider rsa = default(RSACryptoServiceProvider);
                SHA1CryptoServiceProvider cspSha1 = default(SHA1CryptoServiceProvider);
                NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                byte[] bytesFirmados = default(byte[]);

                nfi.NumberDecimalDigits = 1;

                certX509 = new X509Certificate2(PFX, password);


                rsa = (RSACryptoServiceProvider)certX509.PrivateKey;

                byte[] data = Encoding.UTF8.GetBytes(strToSign);

                cspSha1 = new SHA1CryptoServiceProvider();
                bytesFirmados = rsa.SignData(data, cspSha1);

                signData.DigitalSeal = Convert.ToBase64String(bytesFirmados);
                signData.CertificateNumber = Etc.CertUtil.hexString2Ascii(certX509.SerialNumber);
                signData.Version = certX509.Version.ToString("N", nfi);
                signData.Certificate = Convert.ToBase64String(certX509.GetRawCertData());
            }
            catch (Exception)
            {
                throw new Exception("La contraseña del certificado no es válida.");
            }

            return signData;
        }
    }
}
