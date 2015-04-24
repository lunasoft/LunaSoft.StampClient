using Mono.Security.Authenticode;
using Mono.Security.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LunaSoft.StampClient.CSD
{
    internal class MakeCert
    {
        /// <summary>
        /// Genera PFX utilizando certificado , llave privada y password.
        /// </summary>
        /// <param name="bytescer"></param>
        /// <param name="byteskey"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal static byte[] generatePFX(byte[] bytescer, byte[] byteskey, string password)
        {
            try
            {
                char[] arrayOfChars = password.ToCharArray();

                //////---BOUNCY CASTLE IMPLEMENTATION - Problem known with special character password , use chillkat instead.
                AsymmetricKeyParameter privateKey = Org.BouncyCastle.Security.PrivateKeyFactory.DecryptKey(arrayOfChars, byteskey);
                RSA subjectKey = CSD.DotNetUtilities.ToRSA((RsaPrivateCrtKeyParameters)privateKey);

                PKCS12 p12 = new PKCS12();
                p12.Password = password;

                ArrayList list = new ArrayList();
                list.Add(new byte[4] { 1, 0, 0, 0 });
                Hashtable attributes = new Hashtable(1);
                attributes.Add(PKCS9.localKeyId, list);

                p12.AddCertificate(new X509Certificate(bytescer), attributes);

                p12.AddPkcs8ShroudedKeyBag(subjectKey, attributes);

                return p12.GetBytes();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
