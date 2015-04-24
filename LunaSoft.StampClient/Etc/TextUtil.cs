using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace LunaSoft.StampClient.Etc
{
    internal class TextUtil
    {
        internal static string dateTimeFix(string attribute, string xmlComprobante, string character)
        {
            Regex exp = new Regex(attribute + @"" + character + @"""(?<captured>[^\?=\&\#]*)""", RegexOptions.Compiled);
            MatchCollection MatchList = exp.Matches(xmlComprobante);
            if (0 < MatchList.Count)
            {
                string oldValue = MatchList[0].ToString();
                DateTime dateTime = DateTime.Parse(MatchList[0].Groups[1].Value);

                string newValue = attribute + @"" + character + @"""" + String.Format("{0:s}", dateTime) + @"""";

                xmlComprobante = xmlComprobante.Replace(oldValue, newValue);
            }

            return xmlComprobante;
        }

        internal static string replaceCharacterAndEmptySpaces(string value)
        {
            if (null != value)
            {
                while (value.IndexOf("  ") >= 0)
                {
                    value = value.Replace("  ", " ");
                }
            }
            return value;
        }

        internal static string fixOriginalStringDecimal(string xmlComprobante)
        {
            xmlComprobante = dateTimeFix("fecha", xmlComprobante, "=");
            xmlComprobante = decimal6Fix("total", xmlComprobante);
            xmlComprobante = decimal6Fix("subTotal", xmlComprobante);
            xmlComprobante = decimal6Fix("cantidad", xmlComprobante);
            xmlComprobante = decimal6Fix("valorUnitario", xmlComprobante);
            xmlComprobante = decimal6Fix("importe", xmlComprobante);
            xmlComprobante = decimal6Fix("tasa", xmlComprobante);
            xmlComprobante = decimal6Fix("importe", xmlComprobante);
            xmlComprobante = decimal6Fix("totalImpuestosTrasladados", xmlComprobante);
            xmlComprobante = decimal6Fix("totalImpuestosRetenidos", xmlComprobante);
            xmlComprobante = decimal6Fix("detallista:Amount", xmlComprobante);

            return xmlComprobante;
        }

        internal static string removeInvalidCharacters(string xmlComprobante)
        {
            xmlComprobante = xmlComprobante.Replace("\r\n", "");
            xmlComprobante = xmlComprobante.Replace("\r", "");
            xmlComprobante = xmlComprobante.Replace("\n", "");
            xmlComprobante = xmlComprobante.Replace(@"<?xml version=""1.0"" encoding=""utf-16""?>", @"<?xml version=""1.0"" encoding=""utf-8""?>").Trim();
            xmlComprobante = xmlComprobante.Replace("﻿", "");
            xmlComprobante = xmlComprobante.Replace(@"
", "");

            return xmlComprobante;
        }

        internal static string decimal6Fix(string attribute, string xmlComprobante)
        {
            Regex exp = new Regex(attribute + @"=""(?<captured>[^\?=\&\#]*)""", RegexOptions.Compiled);
            MatchCollection MatchList = exp.Matches(xmlComprobante);
            if (0 < MatchList.Count)
            {
                foreach (Match currentMatch in MatchList)
                {
                    string oldValue = currentMatch.ToString();

                    Decimal decimalValue = Decimal.Parse(currentMatch.Groups[1].Value, CultureInfo.InvariantCulture);

                    string testdec = Convert.ToString(decimalValue, CultureInfo.InvariantCulture);
                    // ND 52
                    int positions = 0;
                    if (testdec.IndexOf(".") != -1)
                    {

                        int s = (testdec.IndexOf(".") + 1);
                        positions = ((testdec.Length) - s);

                    }
                    // FIn 52
                    if (positions > 6)
                    {
                        throw new Exception("El XML no cumple con el estandar. Los importes no deben ser mayor a 6 decimales.");
                    }
                }
            }

            return xmlComprobante;
        }

        private static readonly RegexOptions Options =
    RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase |
    RegexOptions.Compiled | RegexOptions.Singleline;
        internal static string EncodeTo64(string toEncode)
        {
            UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] toEncodeAsBytes = encoding.GetBytes(toEncode);
            string returnValue = Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
        internal static string DecodeFrom64(string m_enc)
        {
            byte[] encodedDataAsBytes = Convert.FromBase64String(m_enc);
            string returnValue = Encoding.UTF8.GetString(encodedDataAsBytes);
            return returnValue;
        }
    }
}
