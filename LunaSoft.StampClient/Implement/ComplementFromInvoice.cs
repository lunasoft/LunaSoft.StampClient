using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LunaSoft.StampClient.Implement
{
    internal class ComplementFromInvoice
    {
        /// <summary>
        /// Funcion para obtener un complemento de un cfdi
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="complement">tfd:timbrefiscaldigital nomina:nomina</param>
        /// <param name="comprobante"></param>
        /// <returns></returns>
        internal static T Get<T>(string complement, Entities.Comprobante comprobante)
        {
            object obj = null;
            //Complementos
            if (null != comprobante.Complemento && null != comprobante.Complemento.Any)
            {
                foreach (XmlElement element in comprobante.Complemento.Any)
                {

                    switch (element.Name.ToLower())
                    {
                        case "nomina:nomina":
                        case "nomina":
                            StringBuilder xmlOutput = new StringBuilder();
                            using (XmlWriter writer = XmlWriter.Create(xmlOutput))
                            {
                                element.WriteTo(writer);
                            }
                            obj = Serializer.DeserializeObject<Entities.Nomina>(xmlOutput.ToString());
                            break;
                        case "tfd:timbrefiscaldigital":
                        case "timbrefiscaldigital":
                            StringBuilder xmlOutputTimbre = new StringBuilder();
                            using (XmlWriter writer = XmlWriter.Create(xmlOutputTimbre))
                            {
                                element.WriteTo(writer);
                            }
                            obj = Serializer.DeserializeObject<Entities.TimbreFiscalDigital>(xmlOutputTimbre.ToString());
                            break;
                    }
                }
            }
            return (T)obj;
        }
        internal static void AddStampToInvoice(Entities.TimbreFiscalDigital tfd, ref Entities.Comprobante invoice)
        {
            List<XmlElement> elementTimbreList = new List<XmlElement>();

            XmlElement elementoTimbre = GetXMLELStamp(tfd);
            elementTimbreList.Add(elementoTimbre);

            if (null != invoice.Complemento && null != invoice.Complemento.Any && 0 < invoice.Complemento.Any.Length)
                elementTimbreList.AddRange(invoice.Complemento.Any);

            if (invoice.Complemento == null)
            {
                invoice.Complemento = new Entities.ComprobanteComplemento();
            }
            invoice.Complemento.Any = elementTimbreList.ToArray();
        }
        internal static XmlElement GetXMLELStamp(Entities.TimbreFiscalDigital tfd)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(SerializeFiscalDocument.TimbreFiscalDigital(tfd));
            return doc.DocumentElement;
        }
    }
}
