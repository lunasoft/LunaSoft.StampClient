using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunaSoft.StampClient.Implement
{
    internal class Normalize
    {
        internal static void CFDI(ref Entities.Comprobante cfdi)
        {
            try
            {
                //Inicializamos los valores de la factura                
                cfdi.certificado = "00000000000000000000";
                cfdi.noCertificado = "00000000000000000000";
                cfdi.sello = "";
                cfdi.version = "3.2";

                //To Upper Case y validamos minlength = 1
                if (cfdi.Emisor != null)
                {
                    cfdi.Emisor.rfc = cfdi.Emisor.rfc != null ? cfdi.Emisor.rfc.ToUpper() : null;
                    cfdi.Emisor.nombre = !string.IsNullOrEmpty(cfdi.Emisor.nombre) ? cfdi.Emisor.nombre.ToUpper() : null;
                    if (cfdi.Emisor.DomicilioFiscal != null)
                    {
                        cfdi.Emisor.DomicilioFiscal.noExterior =
                            string.IsNullOrEmpty(cfdi.Emisor.DomicilioFiscal.noExterior) ? null : cfdi.Emisor.DomicilioFiscal.noExterior;

                        cfdi.Emisor.DomicilioFiscal.noInterior =
                            string.IsNullOrEmpty(cfdi.Emisor.DomicilioFiscal.noInterior) ? null : cfdi.Emisor.DomicilioFiscal.noInterior;

                        cfdi.Emisor.DomicilioFiscal.colonia =
                            string.IsNullOrEmpty(cfdi.Emisor.DomicilioFiscal.colonia) ? null : cfdi.Emisor.DomicilioFiscal.colonia;

                        cfdi.Emisor.DomicilioFiscal.localidad =
                            string.IsNullOrEmpty(cfdi.Emisor.DomicilioFiscal.localidad) ? null : cfdi.Emisor.DomicilioFiscal.localidad;

                        cfdi.Emisor.DomicilioFiscal.referencia =
                            string.IsNullOrEmpty(cfdi.Emisor.DomicilioFiscal.referencia) ? null : cfdi.Emisor.DomicilioFiscal.referencia;
                    }

                }
                if (cfdi.Receptor != null)
                {
                    cfdi.Receptor.rfc = cfdi.Emisor.rfc != null ? cfdi.Receptor.rfc.ToUpper() : null;
                    cfdi.Receptor.nombre = !string.IsNullOrEmpty(cfdi.Emisor.nombre) ? cfdi.Receptor.nombre.ToUpper() : null;

                    if (cfdi.Receptor.Domicilio != null)
                    {
                        cfdi.Receptor.Domicilio.calle =
                            string.IsNullOrEmpty(cfdi.Receptor.Domicilio.calle) ? null : cfdi.Receptor.Domicilio.calle;

                        cfdi.Receptor.Domicilio.noExterior =
                            string.IsNullOrEmpty(cfdi.Receptor.Domicilio.noExterior) ? null : cfdi.Receptor.Domicilio.noExterior;

                        cfdi.Receptor.Domicilio.noInterior =
                            string.IsNullOrEmpty(cfdi.Receptor.Domicilio.noInterior) ? null : cfdi.Receptor.Domicilio.noInterior;

                        cfdi.Receptor.Domicilio.colonia =
                            string.IsNullOrEmpty(cfdi.Receptor.Domicilio.colonia) ? null : cfdi.Receptor.Domicilio.colonia;

                        cfdi.Receptor.Domicilio.localidad =
                            string.IsNullOrEmpty(cfdi.Receptor.Domicilio.localidad) ? null : cfdi.Receptor.Domicilio.localidad;

                        cfdi.Receptor.Domicilio.referencia =
                            string.IsNullOrEmpty(cfdi.Receptor.Domicilio.referencia) ? null : cfdi.Receptor.Domicilio.referencia;

                        cfdi.Receptor.Domicilio.municipio =
                            string.IsNullOrEmpty(cfdi.Receptor.Domicilio.municipio) ? null : cfdi.Receptor.Domicilio.municipio;

                        cfdi.Receptor.Domicilio.estado =
                            string.IsNullOrEmpty(cfdi.Receptor.Domicilio.estado) ? null : cfdi.Receptor.Domicilio.estado;
                    }
                }
                cfdi.serie = string.IsNullOrEmpty(cfdi.serie) ? null : cfdi.serie;
                cfdi.condicionesDePago = string.IsNullOrEmpty(cfdi.condicionesDePago) ? null : cfdi.condicionesDePago;
                cfdi.motivoDescuento = string.IsNullOrEmpty(cfdi.motivoDescuento) ? null : cfdi.motivoDescuento;

            }
            catch { }
        }
    }
}
