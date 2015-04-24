using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Xml;

namespace LunaSoft.StampClient.CSD
{
    internal class SignatureXML
    {
        /// <summary>
        /// Sella documento XML
        /// </summary>
        /// <param name="certX509"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        internal Signature ApplySignature(X509Certificate2 certX509, string xml)
        {
            try
            {
                RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)certX509.PrivateKey;
                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = false;
                doc.LoadXml(xml);

                Signature signature = this.Sign(doc, rsa);

                return signature;
            }
            catch (Exception)
            {
                throw new Exception("No fue posible sellar el documento.");
            }
        }
        private Signature Sign(XmlDocument doc, RSA key)
        {
            if (doc == null || key == null)
                throw new ArgumentException("Datos invalidos para la firma.");

            SignedXml signedXml = new SignedXml(doc);

            signedXml.SigningKey = key;

            Reference reference = new Reference();
            reference.Uri = "";

            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            signedXml.AddReference(reference);

            signedXml.ComputeSignature();

            XmlElement xmlDigitalSignature = signedXml.GetXml();
            Signature XmlSignature = signedXml.Signature;

            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));

            return XmlSignature;
        }
    }
}
