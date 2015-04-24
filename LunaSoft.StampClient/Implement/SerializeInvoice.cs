using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace LunaSoft.StampClient.Implement
{
    internal class SerializeFiscalDocument
    {
        internal static string Invoice(Entities.Comprobante comprobante)
        {
            MemoryStream stream = null;
            TextWriter writer = null;
            try
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("cfdi", "http://www.sat.gob.mx/cfd/3");

                string schemaValues = "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd";

                if (null != comprobante.Complemento && null != comprobante.Complemento.Any)
                {
                    foreach (XmlElement element in comprobante.Complemento.Any)
                    {
                        switch (element.Name.ToLower())
                        {
                            case "detallista:detallista":
                                schemaValues += " http://www.sat.gob.mx/detallista http://www.sat.gob.mx/sitio_internet/cfd/detallista/detallista.xsd";
                                ns.Add("detallista", "http://www.sat.gob.mx/detallista");
                                break;
                            case "divisas:divisas":
                                schemaValues += " http://www.sat.gob.mx/divisas http://www.sat.gob.mx/sitio_internet/cfd/divisas/Divisas.xsd";
                                ns.Add("divisas", "http://www.sat.gob.mx/divisas");
                                break;
                            case "implocal:impuestoslocales":
                                schemaValues += " http://www.sat.gob.mx/implocal http://www.sat.gob.mx/sitio_internet/cfd/implocal/implocal.xsd";
                                ns.Add("implocal", "http://www.sat.gob.mx/implocal");
                                break;
                            case "ecc:estadodecuentacombustible":
                                schemaValues += " http://www.sat.gob.mx/ecc http://www.sat.gob.mx/sitio_internet/cfd/ecc/ecc.xsd";
                                ns.Add("ecc", "http://www.sat.gob.mx/ecc");
                                break;
                            case "ecb:estadodecuentabancario":
                                schemaValues += " http://www.sat.gob.mx/ecb http://www.sat.gob.mx/sitio_internet/cfd/ecb/ecb.xsd";
                                ns.Add("ecb", "http://www.sat.gob.mx/ecb");
                                break;
                            case "donat:donatarias":
                                schemaValues += " http://www.sat.gob.mx/donat http://www.sat.gob.mx/sitio_internet/cfd/donat/donat11.xsd";
                                ns.Add("donat", "http://www.sat.gob.mx/donat");
                                break;
                            case "leyendasfisc:leyendasfiscales":
                                schemaValues += " http://www.sat.gob.mx/leyendasFiscales http://www.sat.gob.mx/sitio_internet/cfd/leyendasFiscales/leyendasFisc.xsd";
                                ns.Add("leyendasfisc", "http://www.sat.gob.mx/leyendasFiscales");
                                break;
                            case "pfic:pfintegrantecoordinado":
                                schemaValues += " http://www.sat.gob.mx/pfic http://www.sat.gob.mx/sitio_internet/cfd/pfic/pfic.xsd";
                                ns.Add("pfic", "http://www.sat.gob.mx/pfic");
                                break;
                            case "tpe:turistapasajeroextranjero":
                                schemaValues += " http://www.sat.gob.mx/TuristaPasajeroExtranjero http://www.sat.gob.mx/sitio_internet/cfd/TuristaPasajeroExtranjero/TuristaPasajeroExtranjero.xsd";
                                ns.Add("tpe", "http://www.sat.gob.mx/TuristaPasajeroExtranjero");
                                break;
                            case "spei:complemento_spei":
                                schemaValues += " http://www.sat.gob.mx/spei http://www.sat.gob.mx/sitio_internet/cfd/spei/spei.xsd";
                                ns.Add("spei", "http://www.sat.gob.mx/spei");
                                break;
                            case "registrofiscal:cfdiregistrofiscal":
                                schemaValues += " http://www.sat.gob.mx/registrofiscal http://www.sat.gob.mx/sitio_internet/cfd/cfdiregistrofiscal/cfdiregistrofiscal.xsd";
                                ns.Add("registrofiscal", "http://www.sat.gob.mx/registrofiscal");
                                break;
                            case "nomina:nomina":
                                schemaValues += " http://www.sat.gob.mx/nomina http://www.sat.gob.mx/sitio_internet/cfd/nomina/nomina11.xsd";
                                ns.Add("nomina", "http://www.sat.gob.mx/nomina");
                                break;
                            case "pagoenespecie:pagoenespecie":
                                schemaValues += " http://www.sat.gob.mx/pagoenespecie http://www.sat.gob.mx/sitio_internet/cfd/pagoenespecie/pagoenespecie.xsd";
                                ns.Add("pagoenespecie", "http://www.sat.gob.mx/pagoenespecie");
                                break;
                            case "consumodecombustibles:consumodecombustibles":
                                schemaValues += " http://www.sat.gob.mx/consumodecombustibles http://www.sat.gob.mx/sitio_internet/cfd/consumodecombustibles/consumodecombustibles.xsd";
                                ns.Add("consumodecombustibles", "http://www.sat.gob.mx/consumodecombustibles");
                                break;
                            case "valesdedespensa:valesdedespensa":
                                schemaValues += " http://www.sat.gob.mx/valesdedespensa http://www.sat.gob.mx/sitio_internet/cfd/valesdedespensa/valesdedespensa.xsd";
                                ns.Add("valesdedespensa", "http://www.sat.gob.mx/valesdedespensa");
                                break;
                            case "aerolineas:aerolineas":
                                schemaValues += " http://www.sat.gob.mx/aerolineas http://www.sat.gob.mx/sitio_internet/cfd/aerolineas/aerolineas.xsd";
                                ns.Add("aerolineas", "http://www.sat.gob.mx/aerolineas");
                                break;
                            case "notariospublicos:notariospublicos":
                                schemaValues += " http://www.sat.gob.mx/notariospublicos http://www.sat.gob.mx/sitio_internet/cfd/notariospublicos/notariospublicos.xsd";
                                ns.Add("notariospublicos", "http://www.sat.gob.mx/notariospublicos");
                                break;
                        }
                    }
                }

                if (null != comprobante.Conceptos &&
                  comprobante.Conceptos.Length > 0)
                {
                    foreach (Entities.ComprobanteConcepto conceptos in comprobante.Conceptos)
                    {
                        if (conceptos.ComplementoConcepto != null && conceptos.ComplementoConcepto.Any != null)
                        {
                            foreach (XmlElement element in (conceptos.ComplementoConcepto.Any))
                            {
                                switch (element.Name.ToLower())
                                {
                                    case "iedu:insteducativas":
                                        schemaValues += " http://www.sat.gob.mx/iedu http://www.sat.gob.mx/sitio_internet/cfd/iedu/iedu.xsd";
                                        ns.Add("iedu", "http://www.sat.gob.mx/iedu");
                                        break;

                                    case "ventavehiculos:ventavehiculos":
                                        schemaValues += " http://www.sat.gob.mx/ventavehiculos http://www.sat.gob.mx/sitio_internet/cfd/ventavehiculos/ventavehiculos11.xsd";
                                        ns.Add("ventavehiculos", "http://www.sat.gob.mx/ventavehiculos");
                                        break;

                                    case "terceros:porcuentadeterceros":
                                        schemaValues += " http://www.sat.gob.mx/terceros http://www.sat.gob.mx/sitio_internet/cfd/terceros/terceros11.xsd";
                                        ns.Add("terceros", "http://www.sat.gob.mx/terceros");
                                        break;
                                }
                            }
                        }
                    }
                }

                UTF8Encoding encoding = new UTF8Encoding();
                stream = new MemoryStream();

                writer = new StreamWriter(stream, encoding);
                XmlSerializer serializer = new XmlSerializer(typeof(Entities.Comprobante));
                serializer.Serialize(writer, comprobante, ns);
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);

                string xml = encoding.GetString(arr).Trim();

                //Cambio para evitar que en la recepcion se haga fix a los decimales fechas etc. 
                //Esto para evitar error validación del sello
               xml = GetFiscalXML(xml);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                XmlAttribute aSchemaLocation = doc.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance");
                aSchemaLocation.Value = schemaValues;
                doc.ChildNodes[1].Attributes.InsertBefore(aSchemaLocation, doc.ChildNodes[1].Attributes[0]);

                return doc.OuterXml;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (stream != null) stream.Close();
                if (writer != null) writer.Close();
            }
        }
        internal static string GetFiscalXML(string xml)
        {
            xml = Etc.TextUtil.dateTimeFix("fecha", xml, "=");
            xml = Etc.TextUtil.dateTimeFix("FechaFolioFiscalOrig", xml, "=");
            xml = Etc.TextUtil.dateTimeFix("FechaTimbrado", xml, "=");
            xml = Etc.TextUtil.fixOriginalStringDecimal(xml);
            xml = Etc.TextUtil.removeInvalidCharacters(xml);
            xml = Etc.TextUtil.replaceCharacterAndEmptySpaces(xml);

            return xml;
        }
        internal static string TimbreFiscalDigital(Entities.TimbreFiscalDigital tfd)
        {
            MemoryStream stream = null;
            TextWriter writer = null;
            try
            {
                UTF8Encoding encoding = new UTF8Encoding();
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");

                stream = new MemoryStream(); // read xml in memory

                writer = new StreamWriter(stream, encoding);

                XmlSerializer serializer = new XmlSerializer(typeof(Entities.TimbreFiscalDigital));
                serializer.Serialize(writer, tfd, ns); // read object
                int count = (int)stream.Length; // saves object in memory stream
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);

                stream.Read(arr, 0, count);

                string xml = encoding.GetString(arr).Trim();
                xml = Etc.TextUtil.removeInvalidCharacters(xml);
                xml = GetFiscalXML(xml);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                doc.Prefix = "tfd";

                XmlAttribute aSchemaLocation = doc.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance");
                aSchemaLocation.Value = "http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/TimbreFiscalDigital/TimbreFiscalDigital.xsd";
                doc.ChildNodes[1].Attributes.InsertBefore(aSchemaLocation, doc.ChildNodes[1].Attributes[0]);


                return doc.OuterXml;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (stream != null) stream.Close();
                if (writer != null) writer.Close();
            }
        }
        internal static string TimbreFiscalDigital<T>(T tfd)
        {
            MemoryStream stream = null;
            TextWriter writer = null;
            try
            {
                UTF8Encoding encoding = new UTF8Encoding();
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");

                stream = new MemoryStream(); // read xml in memory

                writer = new StreamWriter(stream, encoding);

                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, tfd, ns); // read object
                int count = (int)stream.Length; // saves object in memory stream
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);

                stream.Read(arr, 0, count);

                string xml = encoding.GetString(arr).Trim();
                xml = Etc.TextUtil.removeInvalidCharacters(xml);
                xml = GetFiscalXML(xml);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                doc.Prefix = "tfd";

                XmlAttribute aSchemaLocation = doc.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance");
                aSchemaLocation.Value = "http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/TimbreFiscalDigital/TimbreFiscalDigital.xsd";
                doc.ChildNodes[1].Attributes.InsertBefore(aSchemaLocation, doc.ChildNodes[1].Attributes[0]);


                return doc.OuterXml;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (stream != null) stream.Close();
                if (writer != null) writer.Close();
            }
        }
    }   
}
