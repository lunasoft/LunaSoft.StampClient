using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LunaSoft.StampClient.Etc
{
    internal class CertUtil
    {
        /// <summary>
        /// Obtiene el numero de certificado
        /// </summary>
        /// <param name="cert"></param>
        /// <returns></returns>
        internal static string getCertNumber(X509Certificate2 cert)
        {
            return hexString2Ascii(cert.SerialNumber);
        }
        internal static string hexString2Ascii(string hexString)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hexString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }
    }
}
