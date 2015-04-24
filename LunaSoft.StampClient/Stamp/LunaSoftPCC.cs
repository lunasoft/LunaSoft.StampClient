using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;

namespace LunaSoft.StampClient.Stamp
{
    internal class LunaSoftPCC : IStamping
    {
        string tokenKey = "tokenLS";
        public Entities.StampResult GetStamp(Entities.Comprobante invoice)
        {
            var result = new Entities.StampResult();
            //removemos la addenda
            var addendaElement = new Entities.ComprobanteAddenda();
            if (invoice.Addenda != null)
            {
                addendaElement.Any = invoice.Addenda.Any;
                invoice.Addenda = null;
            }

            //Obtenemos el documento valido serializado
            string xmlInvoice = Implement.SerializeFiscalDocument.Invoice(invoice);

            //preparamos la llamada al servicio

            //Obtenemos el Token
            var tokenPAC = GetToken();
            if (string.IsNullOrEmpty(tokenPAC))
            {
                result.AddError("SuFacturacion - No es posible autenticar el servicio.");
                return result;
            }

            //Timbramos y obtenemos el error
            lunasoft.cfdi.timbrado.wsTimbrado wsTimbra = new lunasoft.cfdi.timbrado.wsTimbrado();
            wsTimbra.Timeout = 300000; // 5min
            wsTimbra.Url = Implement.ConfigValue.Get("URLStampingLS");

            var resultTimbre = string.Empty;
            try
            {
                resultTimbre = wsTimbra.TimbrarXML(xmlInvoice, tokenPAC);
            }
            catch (Exception ex)
            {
                result.AddError(TreatErrorMessage(ex));
            }
            //Agregamos el timbre al complemento
            if (!string.IsNullOrEmpty(resultTimbre))
            {
                result.TFD = GetLocalStamp(resultTimbre);
                Implement.ComplementFromInvoice.AddStampToInvoice(result.TFD, ref invoice);
                result.InvoiceStamped = invoice;
                result.XmlStamped = Implement.SerializeFiscalDocument.Invoice(invoice);
            }
            else
            {
                var ex = new Exception("SuFacturacion - Timbre No Valido: " + xmlInvoice);
                result.AddError(ex.Message);
            }
            return result;
        }
        public Entities.CancelResult CancelStamp(string UUID, string rfc, byte[] pfx, string passwordPFX)
        {
            var result = new Entities.CancelResult();
            try
            {
                lunasoft.cfdi.cancelacion.wsCancelacion wsCancela = new lunasoft.cfdi.cancelacion.wsCancelacion();
                lunasoft.cfdi.cancelacion.Cancelacion cancelacion = new lunasoft.cfdi.cancelacion.Cancelacion();
                wsCancela.Url = Implement.ConfigValue.Get("URLCancelacionLS");
                wsCancela.Timeout = 3000000;

                //Autenticamos el servicio
                var tokenPAC = GetToken();

                Guid guidUUID = Guid.Empty;
                if (!Guid.TryParse(UUID, out guidUUID))
                    throw new Exception("Cancelación - El UUID a cancelar no es valido.");


                cancelacion.Fecha = DateTime.Now.CentralTime();
                cancelacion.Folios = new List<lunasoft.cfdi.cancelacion.CancelacionFolios>() { new lunasoft.cfdi.cancelacion.CancelacionFolios() { UUID = UUID } }.ToArray();
                cancelacion.RfcEmisor = rfc;
                cancelacion.Signature = new lunasoft.cfdi.cancelacion.SignatureType();

                Entities.CancelacionSerializarSF.Cancelacion cancelacionSerializar = new Entities.CancelacionSerializarSF.Cancelacion();
                cancelacionSerializar.Fecha = cancelacion.Fecha;
                cancelacionSerializar.Folios =
                    new List<Entities.CancelacionSerializarSF.CancelacionFolios>() { new Entities.CancelacionSerializarSF.CancelacionFolios() { UUID = UUID } }.ToArray();
                cancelacionSerializar.RfcEmisor = cancelacion.RfcEmisor;

                String mensajeCancelacion = Implement.Serializer.SerializeObject(cancelacionSerializar);

                X509Certificate2 certClient = new X509Certificate2(pfx, passwordPFX, X509KeyStorageFlags.MachineKeySet);

                CSD.SignatureXML signatureXML = new CSD.SignatureXML();
                System.Security.Cryptography.Xml.Signature signatureResult = signatureXML.ApplySignature(certClient, mensajeCancelacion);

                cancelacion.Signature = new lunasoft.cfdi.cancelacion.SignatureType();
                cancelacion.Signature.SignedInfo = new lunasoft.cfdi.cancelacion.SignedInfoType();
                cancelacion.Signature.SignedInfo.CanonicalizationMethod = new lunasoft.cfdi.cancelacion.CanonicalizationMethodType();

                cancelacion.Signature.SignedInfo.CanonicalizationMethod.Algorithm = signatureResult.SignedInfo.CanonicalizationMethodObject.Algorithm;
                cancelacion.Signature.SignedInfo.SignatureMethod = new lunasoft.cfdi.cancelacion.SignatureMethodType();

                cancelacion.Signature.SignedInfo.SignatureMethod.Algorithm = signatureResult.SignedInfo.SignatureMethod;
                cancelacion.Signature.SignedInfo.Reference = new lunasoft.cfdi.cancelacion.ReferenceType();
                Reference reference = (Reference)signatureResult.SignedInfo.References[0];
                cancelacion.Signature.SignedInfo.Reference.URI = reference.Uri;

                List<lunasoft.cfdi.cancelacion.TransformType> lstTransform = new List<lunasoft.cfdi.cancelacion.TransformType>();
                lstTransform.Add(new lunasoft.cfdi.cancelacion.TransformType() { Algorithm = "http://www.w3.org/2000/09/xmldsig#enveloped-signature" });
                cancelacion.Signature.SignedInfo.Reference.Transforms = lstTransform.ToArray();

                cancelacion.Signature.SignedInfo.Reference.DigestMethod = new lunasoft.cfdi.cancelacion.DigestMethodType();
                cancelacion.Signature.SignedInfo.Reference.DigestMethod.Algorithm = reference.DigestMethod;

                cancelacion.Signature.SignedInfo.Reference.DigestValue = reference.DigestValue;

                cancelacion.Signature.SignatureValue = signatureResult.SignatureValue;
                cancelacion.Signature.KeyInfo = new lunasoft.cfdi.cancelacion.KeyInfoType();
                cancelacion.Signature.KeyInfo.X509Data = new lunasoft.cfdi.cancelacion.X509DataType();
                cancelacion.Signature.SignedInfo.Reference.DigestValue = reference.DigestValue;

                cancelacion.Signature.SignatureValue = signatureResult.SignatureValue;
                cancelacion.Signature.KeyInfo = new lunasoft.cfdi.cancelacion.KeyInfoType();
                cancelacion.Signature.KeyInfo.X509Data = new lunasoft.cfdi.cancelacion.X509DataType();
                cancelacion.Signature.KeyInfo.X509Data.X509IssuerSerial = new lunasoft.cfdi.cancelacion.X509IssuerSerialType();
                cancelacion.Signature.KeyInfo.X509Data.X509IssuerSerial.X509IssuerName = certClient.Issuer;
                cancelacion.Signature.KeyInfo.X509Data.X509IssuerSerial.X509SerialNumber = certClient.GetSerialNumberString();
                cancelacion.Signature.KeyInfo.X509Data.X509Certificate = certClient.GetRawCertData();

                //Llamada al servicio de Cancelacion PCC
                var resultPAC = wsCancela.Cancelar(cancelacion, tokenPAC);
                if (resultPAC == null)
                    throw new Exception("Cancelación - Su Factura no ha sido Cancelada. El servicio del SAT no esta disponible o su Factura aun no esta disponible para cancelación. ");

                if (!string.IsNullOrEmpty(resultPAC.CodEstatus))
                    throw new Exception("Cancelación - Su Factura no ha sido Cancelada. El servicio del SAT detecto un problema en la cancelación. Favor de intentar de nuevo, si el problema persiste contactar a Soporte Tecnico.");

                //Convertimos a objeto a local
                var acuseCancelaPAC = Implement.Serializer.SerializeObject<lunasoft.cfdi.cancelacion.Acuse>(resultPAC);
                result.XmlResult = acuseCancelaPAC;

            }
            catch (Exception ex)
            {
                result.AddError(TreatErrorMessage(ex));
            }
            return result;
        }
        private Entities.TimbreFiscalDigital GetLocalStamp(string timbre)
        {
            List<XmlElement> elementTimbreList = new List<XmlElement>();
            //serializamos timbre            
            var timbreLocal = Implement.Serializer.DeserializeObject<Entities.TimbreFiscalDigital>(timbre);
            return timbreLocal;
        }
        private string GetToken()
        {
            var res = string.Empty;
            try
            {
                ObjectCache cache = MemoryCache.Default;
                res = cache[tokenKey] as string;
                if (res == null)
                {
                    //Autenticacion con LunaSoft , obtenemos el token.
                    lunasoft.cfdi.autenticacion.wsAutenticacion wsAutentica = new lunasoft.cfdi.autenticacion.wsAutenticacion();
                    wsAutentica.Url = Implement.ConfigValue.Get("URLAutenticateLS");
                    string userSF = Implement.ConfigValue.Get("UserLS");
                    string passSF = Implement.ConfigValue.Get("PassLS");
                    wsAutentica.Timeout = 300000; //50min
                    res = wsAutentica.AutenticarBasico(userSF, passSF);
                    cache.Set(tokenKey, res, new DateTimeOffset(DateTime.Now.Add(new TimeSpan(0, 100, 0))));
                }
            }
            catch (Exception) { }
            return res;
        }
        private string TreatErrorMessage(Exception ex)
        {
            string result = "";
            try
            {
                string msg = ex.Message.Replace("SuFacturacion ", "LunaSoft");
                string code = msg.Substring(0, msg.IndexOf('.')).Replace(".", "");
                result = msg;
            }
            catch (Exception e) { }
            return string.IsNullOrEmpty(result) ? ex.Message : result;

        }
    }
}
