using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace LunaSoft.StampClient.Invoice
{
    internal static class Xslt
    {
        internal static string GetOriginalChainCFDI(string xml)
        {
            string result = string.Empty;
            StringWriter writer = new StringWriter();
            try
            {
                //to replace caracters in original string to HTML caracters               
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(typeof(cadenaoriginal32));
                XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
                xslt.Transform(xmlReader, null, writer);
                result = writer.ToString().Trim();
            }
            catch (Exception ex)
            {
                throw new Exception("No es posible obtener la cadena original del comprobante", ex);
            }
            finally
            {
                if (writer != null) writer.Close();
            }

            return result;
        }
        internal static string GetOriginalChainTFD(string xml)
        {
            string result = string.Empty;
            StringWriter writer = new StringWriter();
            try
            {
                //to replace caracters in original string to HTML caracters               
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(typeof(cadenaoriginalTFD10));
                XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
                xslt.Transform(xmlReader, null, writer);
                result = writer.ToString().Trim();
            }
            catch (Exception ex)
            {
                throw new Exception("No es posible obtener la cadena original del TimbreFiscal", ex);
            }
            finally
            {
                if (writer != null) writer.Close();
            }

            return result;
        }
    }

}
