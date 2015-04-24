using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using System.Xml;
using System.IO;
using System.Web;
using System.Runtime.Caching;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Reflection;

namespace LunaSoft.StampClient.Invoice
{
    internal class ValidateCFDI
    {
        private Entities.ValidateXMLResponse res;
        ObjectCache cache = MemoryCache.Default;
        internal ValidateCFDI()
        {
            res = new Entities.ValidateXMLResponse();
        }
        /// <summary>
        /// Valida estructura comprobante sin addenda.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        internal Entities.ValidateXMLResponse ValidateInvoiceRemoveAddenda(Entities.Comprobante invoice)
        {
            //removemos la addenda
            var addendaElement = new Entities.ComprobanteAddenda();
            if (invoice.Addenda != null)
            {
                addendaElement.Any = invoice.Addenda.Any;
                invoice.Addenda = null;
            }

            string xmlResult = Implement.SerializeFiscalDocument.Invoice(invoice);

            var res = ValidateInvoice(invoice, xmlResult);

            if (addendaElement.Any != null)
            {
                invoice.Addenda = addendaElement;
                xmlResult = Implement.SerializeFiscalDocument.Invoice(invoice);
            }

            res.xmlValid = xmlResult;
            return res;

        }
        /// <summary>
        /// Valida el comprobante, estructura y sello
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        internal Entities.ValidateXMLResponse ValidateInvoiceAndSignRemoveAddenda(Entities.Comprobante invoice)
        {
            //removemos la addenda
            var addendaElement = new Entities.ComprobanteAddenda();
            if (invoice.Addenda != null)
            {
                addendaElement.Any = invoice.Addenda.Any;
                invoice.Addenda = null;
            }

            string xmlResult = Implement.SerializeFiscalDocument.Invoice(invoice);

            var res = ValidateInvoice(invoice, xmlResult);
            try
            {
                var cadenaOriginal = Xslt.GetOriginalChainCFDI(xmlResult);
                X509Certificate2 certificate = new X509Certificate2(Convert.FromBase64String(invoice.certificado));

                if (!ValidateSign(cadenaOriginal, invoice.sello, certificate))
                    res.AddError("El sello del comprobante es invalido.");
            }
            catch (Exception)
            {
                res.AddError("Sello Invalido. No fue posible verificar el sello del comprobante.");
            }


            if (addendaElement.Any != null)
            {
                invoice.Addenda = addendaElement;
                xmlResult = Implement.SerializeFiscalDocument.Invoice(invoice);
            }

            res.xmlValid = xmlResult;
            return res;

        }
        /// <summary>
        /// Carga xml comprobante y devuelve Objeto Comprobante.ValidateInvoice
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        internal Entities.ValidateXMLResponse LoadInvoice(string xml)
        {
            try
            {
                res.cfdi = Implement.Serializer.DeserializeObject<Entities.Comprobante>(xml);
            }
            catch (Exception)
            {
                res.cfdi = null;
                res.AddError("El comprobante CFDI no es valido. Su estructura es invalida");
            }
            return res;
        }
        private Entities.ValidateXMLResponse ValidateInvoice(Entities.Comprobante invoice, string xml)
        {
            try
            {
                XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
                xmlReaderSettings.ValidationEventHandler += new ValidationEventHandler(configCFD_ValidationEventHandler);
                xmlReaderSettings.ValidationType = ValidationType.Schema;
                xmlReaderSettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                xmlReaderSettings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

                xmlReaderSettings.Schemas.Add(GetSchema("cfdv32.xsd"));

                if (null != invoice.Complemento && null != invoice.Complemento.Any)
                {
                    if (invoice.Complemento.Any.ToList().Exists(p => p.Name.ToLower() == "tfd:timbrefiscaldigital"))
                        xmlReaderSettings.Schemas.Add(GetSchema("TimbreFiscalDigital.xsd"));
                    if (invoice.Complemento.Any.ToList().Exists(p => p.Name.ToLower() == "divisas:divisas"))
                        xmlReaderSettings.Schemas.Add(GetSchema("Divisas.xsd"));
                    if (invoice.Complemento.Any.ToList().Exists(p => p.Name.ToLower() == "detallista:detallista"))
                        xmlReaderSettings.Schemas.Add(GetSchema("detallista.xsd"));
                    if (invoice.Complemento.Any.ToList().Exists(p => p.Name.ToLower() == "donat:donatarias"))
                        xmlReaderSettings.Schemas.Add(GetSchema("donat11.xsd"));
                    if (invoice.Complemento.Any.ToList().Exists(p => p.Name.ToLower() == "leyendasfisc:leyendasfiscales"))
                        xmlReaderSettings.Schemas.Add(GetSchema("leyendasFisc.xsd"));
                    if (invoice.Complemento.Any.ToList().Exists(p => p.Name.ToLower() == "pfic:pfintegrantecoordinado"))
                        xmlReaderSettings.Schemas.Add(GetSchema("pfic.xsd"));
                    if (invoice.Complemento.Any.ToList().Exists(p => p.Name.ToLower() == "tpe:turistapasajeroextranjero"))
                        xmlReaderSettings.Schemas.Add(GetSchema("TuristaPasajeroExtranjero.xsd"));
                    if (invoice.Complemento.Any.ToList().Exists(p => p.Name.ToLower() == "implocal:impuestoslocales"))
                        xmlReaderSettings.Schemas.Add(GetSchema("implocal.xsd"));
                    if (invoice.Complemento.Any.ToList().Exists(p => p.Name.ToLower() == "ecc:estadodecuentacombustible"))
                        xmlReaderSettings.Schemas.Add(GetSchema("ecc.xsd"));
                    if (invoice.Complemento.Any.ToList().Exists(p => p.Name.ToLower() == "spei:complemento_spei"))
                        xmlReaderSettings.Schemas.Add(GetSchema("spei.xsd"));
                    if (invoice.Complemento.Any.ToList().Exists(p => p.Name.ToLower() == "registrofiscal:cfdiregistrofiscal"))
                        xmlReaderSettings.Schemas.Add(GetSchema("cfdiregistrofiscal.xsd"));
                    if (invoice.Complemento.Any.ToList().Exists(p => p.Name.ToLower() == "nomina:nomina"))
                        xmlReaderSettings.Schemas.Add(GetSchema("nomina11.xsd"));
                    if (invoice.Complemento.Any.ToList().Exists(p => p.Name.ToLower() == "pagoenespecie:pagoenespecie"))
                        xmlReaderSettings.Schemas.Add(GetSchema("pagoenespecie.xsd"));
                    //Complemetos 2014
                    if (invoice.Complemento.Any.ToList().Exists(p => p.Name.ToLower() == "consumodecombustibles:consumodecombustibles"))
                        xmlReaderSettings.Schemas.Add(GetSchema("consumodecombustibles.xsd"));
                    if (invoice.Complemento.Any.ToList().Exists(p => p.Name.ToLower() == "valesdedespensa:valesdedespensa"))
                        xmlReaderSettings.Schemas.Add(GetSchema("valesdedespensa.xsd"));
                    if (invoice.Complemento.Any.ToList().Exists(p => p.Name.ToLower() == "aerolineas:aerolineas"))
                        xmlReaderSettings.Schemas.Add(GetSchema("aerolineas.xsd"));
                    if (invoice.Complemento.Any.ToList().Exists(p => p.Name.ToLower() == "notariospublicos:notariospublicos"))
                        xmlReaderSettings.Schemas.Add(GetSchema("notariospublicos.xsd"));

                }
                if (null != invoice.Conceptos &&
                  invoice.Conceptos.Length > 0)
                {
                    foreach (Entities.ComprobanteConcepto conceptos in invoice.Conceptos)
                    {
                        if (conceptos.ComplementoConcepto != null && conceptos.ComplementoConcepto.Any != null)
                        {
                            foreach (XmlElement element in (conceptos.ComplementoConcepto.Any))
                            {
                                switch (element.Name.ToLower())
                                {
                                    case "iedu:insteducativas":
                                        if (!xmlReaderSettings.Schemas.Contains("http://www.sat.gob.mx/iedu"))
                                            xmlReaderSettings.Schemas.Add(GetSchema("iedu.xsd"));
                                        break;

                                    case "terceros:porcuentadeterceros":
                                        if (!xmlReaderSettings.Schemas.Contains("http://www.sat.gob.mx/terceros"))
                                            xmlReaderSettings.Schemas.Add(GetSchema("terceros11.xsd"));
                                        break;

                                    case "ventavehiculos:ventavehiculos":
                                        if (!xmlReaderSettings.Schemas.Contains("http://www.sat.gob.mx/ventavehiculos"))
                                            xmlReaderSettings.Schemas.Add(GetSchema("ventavehiculos.xsd"));
                                        break;
                                }
                            }
                        }
                    }
                }

                xmlReaderSettings.Schemas.Compile();
                StringReader stream = new StringReader(xml);
                using (XmlReader cfd = XmlReader.Create(stream, xmlReaderSettings))
                { while (cfd.Read()) { } }
            }
            catch (Exception)
            {
                res.AddError("Factura - Validacion XML Error no Controlado.");
            }
            return res;

        }
        private void configCFD_ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Error)
            {
                res.AddError(e.Message);
            }
            else if (e.Severity == XmlSeverityType.Warning)
            {
                res.AddWarning(e.Message);
            }
        }
        private XmlSchema GetSchema(string fileNameXSD)
        {
            XmlSchema result = null;
            try
            {
                string schemaB64 = (string)cache[fileNameXSD];
                if (schemaB64 == null)
                {
                    //Descargamos el XSD desde S3
                    string pathXSD = Implement.ConfigValue.Get("pathXSD");
                    string fullPathFolderXSD = Etc.FileUtil.GetAppDirectory(pathXSD);
                    string fullPathFileXSD = Path.Combine(fullPathFolderXSD, fileNameXSD);
                    if (File.Exists(fullPathFileXSD))
                    {
                        schemaB64 = Convert.ToBase64String(File.ReadAllBytes(fullPathFileXSD));
                        //Guardamos en Cache el XSD
                        CacheItemPolicy filePolicy = new CacheItemPolicy();
                        filePolicy.ChangeMonitors.Add(new HostFileChangeMonitor(new List<string> { fullPathFileXSD }));
                        cache.Set(fileNameXSD, schemaB64, filePolicy);
                    }
                }
                using (var schemaStream = new MemoryStream(Convert.FromBase64String(schemaB64)))
                {
                    result = XmlSchema.Read(schemaStream, null);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Factura - Validacion XML Error no Controlado.", ex);
            }

            return result;
        }
        /// <summary>
        /// Valida el sello de un comprobante contra la cadena original y el certificado.
        /// </summary>
        /// <param name="cadenaOriginal"></param>
        /// <param name="sello"></param>
        /// <param name="certificado"></param>
        /// <returns></returns>
        internal bool ValidateSign(string cadenaOriginal, string sello, X509Certificate2 certificado)
        {
            bool bValidacionSello = false;
            try
            {

                byte[] byteCadenaOriginal = Encoding.UTF8.GetBytes(cadenaOriginal);
                byte[] byteSello = Convert.FromBase64String(sello);

                if (certificado == null)
                {
                    //El certificado proporcionado no es válido.
                    return false;
                }
                RSACryptoServiceProvider rsaCryptoServiceProvider = (RSACryptoServiceProvider)certificado.PublicKey.Key;

                bValidacionSello = rsaCryptoServiceProvider.VerifyData(byteCadenaOriginal, CryptoConfig.MapNameToOID("SHA1"), byteSello);

                if (cadenaOriginal == null || cadenaOriginal == String.Empty)
                {
                    return false;
                }
                else if (!bValidacionSello)
                {
                    //El sello proporcionado no es válido las cadenas son diferentes.
                    return false;
                }
            }
            catch (Exception ex)
            {
                //Error no controlado en el proceso de validacion del sello.
                return false;
            }
            return bValidacionSello;
        }
        #region timbrefiscal
        /// <summary>
        /// Valida Estructura Timbre Fiscal Digital
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        internal Entities.TimbreFiscalDigital ValidateNamespaceStructTFD(Entities.Comprobante invoice)
        {
            Entities.TimbreFiscalDigital tfd = null;

            XmlElement timbreXmlElement = invoice.Complemento.Any.ToList().SingleOrDefault(p => p.LocalName.ToLower().Contains("timbrefiscaldigital"));

            //Validacion de namespace y prefijo
            if (timbreXmlElement.NamespaceURI != "http://www.sat.gob.mx/TimbreFiscalDigital" || timbreXmlElement.Prefix != "tfd")
            {
                if (timbreXmlElement.NamespaceURI != "http://www.sat.gob.mx/TimbreFiscalDigital")
                {
                    //Namespace del timbre fiscal digital incorrecto
                    res.AddError("El namespace del timbre fiscal digital es incorrecto.");
                }

                if (timbreXmlElement.Prefix != "tfd")
                {
                    res.AddError("El prefijo del timbre fiscal digital es incorrecto.");
                }
            }

            try
            {
                tfd = Implement.ComplementFromInvoice.Get<Entities.TimbreFiscalDigital>("tfd:timbrefiscaldigital", invoice);
                if (tfd == null)
                    res.AddError("El elemento Timbre Fiscal Digital no se encuentra o no es valido.");
            }
            catch (Exception)
            {
                res.AddError("El elemento Timbre Fiscal Digital no se encuentra o no es valido.");
            }
            return tfd;
        }
        #endregion timbrefiscal
    }
}
