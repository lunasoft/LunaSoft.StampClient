using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace LunaSoft.StampClient.Entities
{
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3", IsNullable = false)]
    [DataContract(Namespace = "http://www.sat.gob.mx/cfd/3", Name = "Comprobante", IsReference = true)]
    public partial class Comprobante
    {

        private ComprobanteEmisor emisorField;

        private ComprobanteReceptor receptorField;

        private ComprobanteConcepto[] conceptosField;

        private ComprobanteImpuestos impuestosField;

        private ComprobanteComplemento complementoField;

        private ComprobanteAddenda addendaField;

        private string versionField;

        private string serieField;

        private string folioField;

        private string lugarExpedicionField;

        private string numCtaPagoField;

        private string folioFiscalOrigField;

        private string serieFolioFiscalOrigField;

        private System.DateTime fechaFolioFiscalOrigField;

        private bool fechaFolioFiscalOrigFieldSpecified;

        private decimal montoFolioFiscalOrigField;

        private bool montoFolioFiscalOrigFieldSpecified;

        private System.DateTime fechaField;

        private string selloField;

        private string formaDePagoField;

        private string noCertificadoField;

        private string certificadoField;

        private string condicionesDePagoField;

        private decimal subTotalField;

        private decimal descuentoField;

        private bool descuentoFieldSpecified;

        private string motivoDescuentoField;

        private string tipoCambioField;

        private string monedaField;

        private decimal totalField;

        private string metodoDePagoField;

        private ComprobanteTipoDeComprobante tipoDeComprobanteField;

        public Comprobante()
        {
            //this.versionField = "3.0";
        }

        /// <comentarios/>
        [DataMember]
        public ComprobanteEmisor Emisor
        {
            get
            {
                return this.emisorField;
            }
            set
            {
                this.emisorField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        public ComprobanteReceptor Receptor
        {
            get
            {
                return this.receptorField;
            }
            set
            {
                this.receptorField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Concepto", IsNullable = false)]
        [DataMember]
        public ComprobanteConcepto[] Conceptos
        {
            get
            {
                return this.conceptosField;
            }
            set
            {
                this.conceptosField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        public ComprobanteImpuestos Impuestos
        {
            get
            {
                return this.impuestosField;
            }
            set
            {
                this.impuestosField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        public ComprobanteComplemento Complemento
        {
            get
            {
                return this.complementoField;
            }
            set
            {
                this.complementoField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        public ComprobanteAddenda Addenda
        {
            get
            {
                return this.addendaField;
            }
            set
            {
                this.addendaField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember(Name = "version")]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string serie
        {
            get
            {
                return this.serieField;
            }
            set
            {
                this.serieField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember(Name = "folio")]
        public string folio
        {
            get
            {
                return this.folioField;
            }
            set
            {
                this.folioField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string LugarExpedicion
        {
            get
            {
                return this.lugarExpedicionField;
            }
            set
            {
                this.lugarExpedicionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string NumCtaPago
        {
            get
            {
                return this.numCtaPagoField;
            }
            set
            {
                this.numCtaPagoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string FolioFiscalOrig
        {
            get
            {
                return this.folioFiscalOrigField;
            }
            set
            {
                this.folioFiscalOrigField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string SerieFolioFiscalOrig
        {
            get
            {
                return this.serieFolioFiscalOrigField;
            }
            set
            {
                this.serieFolioFiscalOrigField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public System.DateTime FechaFolioFiscalOrig
        {
            get
            {
                return this.fechaFolioFiscalOrigField;
            }
            set
            {
                this.fechaFolioFiscalOrigField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [DataMember]
        public bool FechaFolioFiscalOrigSpecified
        {
            get
            {
                return this.fechaFolioFiscalOrigFieldSpecified;
            }
            set
            {
                this.fechaFolioFiscalOrigFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public decimal MontoFolioFiscalOrig
        {
            get
            {
                return this.montoFolioFiscalOrigField;
            }
            set
            {
                this.montoFolioFiscalOrigField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [DataMember]
        public bool MontoFolioFiscalOrigSpecified
        {
            get
            {
                return this.montoFolioFiscalOrigFieldSpecified;
            }
            set
            {
                this.montoFolioFiscalOrigFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public System.DateTime fecha
        {
            get
            {
                return this.fechaField;
            }
            set
            {
                this.fechaField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string sello
        {
            get
            {
                return this.selloField;
            }
            set
            {
                this.selloField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string formaDePago
        {
            get
            {
                return this.formaDePagoField;
            }
            set
            {
                this.formaDePagoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string noCertificado
        {
            get
            {
                return this.noCertificadoField;
            }
            set
            {
                this.noCertificadoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string certificado
        {
            get
            {
                return this.certificadoField;
            }
            set
            {
                this.certificadoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string condicionesDePago
        {
            get
            {
                return this.condicionesDePagoField;
            }
            set
            {
                this.condicionesDePagoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]        
        public decimal subTotal
        {
            get
            {
                return this.subTotalField;
            }
            set
            {
                this.subTotalField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public decimal descuento
        {
            get
            {
                return this.descuentoField;
            }
            set
            {
                this.descuentoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [DataMember]
        public bool descuentoSpecified
        {
            get
            {
                return this.descuentoFieldSpecified;
            }
            set
            {
                this.descuentoFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string motivoDescuento
        {
            get
            {
                return this.motivoDescuentoField;
            }
            set
            {
                this.motivoDescuentoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string TipoCambio
        {
            get
            {
                return this.tipoCambioField;
            }
            set
            {
                this.tipoCambioField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string Moneda
        {
            get
            {
                return this.monedaField;
            }
            set
            {
                this.monedaField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]        
        public decimal total
        {
            get
            {
                return this.totalField;
            }
            set
            {
                this.totalField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string metodoDePago
        {
            get
            {
                return this.metodoDePagoField;
            }
            set
            {
                this.metodoDePagoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]        
        public ComprobanteTipoDeComprobante tipoDeComprobante
        {
            get
            {
                return this.tipoDeComprobanteField;
            }
            set
            {
                this.tipoDeComprobanteField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteEmisor
    {

        private t_UbicacionFiscal domicilioFiscalField;

        private t_Ubicacion expedidoEnField;

        private ComprobanteEmisorRegimenFiscal[] regimenFiscalField;

        private string rfcField;

        private string nombreField;

        /// <comentarios/>
        [DataMember]
        public t_UbicacionFiscal DomicilioFiscal
        {
            get
            {
                return this.domicilioFiscalField;
            }
            set
            {
                this.domicilioFiscalField = value;
            }
        }

        /// <comentarios/>
        [DataMember]
        public t_Ubicacion ExpedidoEn
        {
            get
            {
                return this.expedidoEnField;
            }
            set
            {
                this.expedidoEnField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute("RegimenFiscal", IsNullable = false, Namespace = "http://www.sat.gob.mx/cfd/3")]
        [DataMember]
        public ComprobanteEmisorRegimenFiscal[] RegimenFiscal
        {
            get
            {
                return this.regimenFiscalField;
            }
            set
            {
                this.regimenFiscalField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string rfc
        {
            get
            {
                return this.rfcField;
            }
            set
            {
                this.rfcField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract(Name = "t_UbicacionFiscal", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class t_UbicacionFiscal
    {

        private string calleField;

        private string noExteriorField;

        private string noInteriorField;

        private string coloniaField;

        private string localidadField;

        private string referenciaField;

        private string municipioField;

        private string estadoField;

        private string paisField;

        private string codigoPostalField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string calle
        {
            get
            {
                return this.calleField;
            }
            set
            {
                this.calleField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string noExterior
        {
            get
            {
                return this.noExteriorField;
            }
            set
            {
                this.noExteriorField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string noInterior
        {
            get
            {
                return this.noInteriorField;
            }
            set
            {
                this.noInteriorField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string colonia
        {
            get
            {
                return this.coloniaField;
            }
            set
            {
                this.coloniaField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string localidad
        {
            get
            {
                return this.localidadField;
            }
            set
            {
                this.localidadField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string referencia
        {
            get
            {
                return this.referenciaField;
            }
            set
            {
                this.referenciaField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string municipio
        {
            get
            {
                return this.municipioField;
            }
            set
            {
                this.municipioField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string estado
        {
            get
            {
                return this.estadoField;
            }
            set
            {
                this.estadoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string pais
        {
            get
            {
                return this.paisField;
            }
            set
            {
                this.paisField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string codigoPostal
        {
            get
            {
                return this.codigoPostalField;
            }
            set
            {
                this.codigoPostalField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract(Name = "t_InformacionAduanera", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class t_InformacionAduanera
    {

        private string numeroField;

        private System.DateTime fechaField;

        private string aduanaField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string numero
        {
            get
            {
                return this.numeroField;
            }
            set
            {
                this.numeroField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        [DataMember]
        public System.DateTime fecha
        {
            get
            {
                return this.fechaField;
            }
            set
            {
                this.fechaField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string aduana
        {
            get
            {
                return this.aduanaField;
            }
            set
            {
                this.aduanaField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract(Name = "t_Ubicacion", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class t_Ubicacion
    {

        private string calleField;

        private string noExteriorField;

        private string noInteriorField;

        private string coloniaField;

        private string localidadField;

        private string referenciaField;

        private string municipioField;

        private string estadoField;

        private string paisField;

        private string codigoPostalField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string calle
        {
            get
            {
                return this.calleField;
            }
            set
            {
                this.calleField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string noExterior
        {
            get
            {
                return this.noExteriorField;
            }
            set
            {
                this.noExteriorField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string noInterior
        {
            get
            {
                return this.noInteriorField;
            }
            set
            {
                this.noInteriorField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string colonia
        {
            get
            {
                return this.coloniaField;
            }
            set
            {
                this.coloniaField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string localidad
        {
            get
            {
                return this.localidadField;
            }
            set
            {
                this.localidadField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string referencia
        {
            get
            {
                return this.referenciaField;
            }
            set
            {
                this.referenciaField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string municipio
        {
            get
            {
                return this.municipioField;
            }
            set
            {
                this.municipioField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string estado
        {
            get
            {
                return this.estadoField;
            }
            set
            {
                this.estadoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string pais
        {
            get
            {
                return this.paisField;
            }
            set
            {
                this.paisField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string codigoPostal
        {
            get
            {
                return this.codigoPostalField;
            }
            set
            {
                this.codigoPostalField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract]
    public partial class ComprobanteEmisorRegimenFiscal
    {

        private string regimenField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string Regimen
        {
            get
            {
                return this.regimenField;
            }
            set
            {
                this.regimenField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteReceptor
    {

        private t_Ubicacion domicilioField;

        private string rfcField;

        private string nombreField;

        /// <comentarios/>
        [DataMember]
        public t_Ubicacion Domicilio
        {
            get
            {
                return this.domicilioField;
            }
            set
            {
                this.domicilioField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string rfc
        {
            get
            {
                return this.rfcField;
            }
            set
            {
                this.rfcField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
    }


    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteConcepto
    {
        //private object[] itemsField;

        private decimal cantidadField;

        private string unidadField;

        private string noIdentificacionField;

        private string descripcionField;

        private decimal valorUnitarioField;

        private decimal importeField;

        private t_InformacionAduanera[] t_InformacionAduaneraField;

        private ComprobanteConceptoComplementoConcepto ComplementoConceptoField;

        private ComprobanteConceptoCuentaPredial CuentaPredialField;

        private ComprobanteConceptoParte[] ParteField;

        [System.Xml.Serialization.XmlElementAttribute()]
        [DataMember]
        public t_InformacionAduanera[] InformacionAduanera
        {
            get
            {
                return t_InformacionAduaneraField;
            }
            set
            {
                t_InformacionAduaneraField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute()]
        [DataMember]
        public ComprobanteConceptoComplementoConcepto ComplementoConcepto
        {
            get
            {
                return ComplementoConceptoField;
            }
            set
            {
                ComplementoConceptoField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute()]
        [DataMember]
        public ComprobanteConceptoCuentaPredial CuentaPredial
        {
            get
            {
                return CuentaPredialField;
            }
            set
            {
                CuentaPredialField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute()]
        [DataMember]
        public ComprobanteConceptoParte[] Parte
        {
            get
            {
                return ParteField;
            }
            set
            {
                ParteField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public decimal cantidad
        {
            get
            {
                return this.cantidadField;
            }
            set
            {
                this.cantidadField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string unidad
        {
            get
            {
                return this.unidadField;
            }
            set
            {
                this.unidadField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string noIdentificacion
        {
            get
            {
                return this.noIdentificacionField;
            }
            set
            {
                this.noIdentificacionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string descripcion
        {
            get
            {
                return this.descripcionField;
            }
            set
            {
                this.descripcionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public decimal valorUnitario
        {
            get
            {
                return this.valorUnitarioField;
            }
            set
            {
                this.valorUnitarioField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public decimal importe
        {
            get
            {
                return this.importeField;
            }
            set
            {
                this.importeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteConceptoComplementoConcepto
    {

        private System.Xml.XmlElement[] anyField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [DataMember]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteConceptoCuentaPredial
    {

        private string numeroField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string numero
        {
            get
            {
                return this.numeroField;
            }
            set
            {
                this.numeroField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteConceptoParte
    {

        private t_InformacionAduanera[] informacionAduaneraField;

        private decimal cantidadField;

        private string unidadField;

        private string noIdentificacionField;

        private string descripcionField;

        private decimal valorUnitarioField;

        private bool valorUnitarioFieldSpecified;

        private decimal importeField;

        private bool importeFieldSpecified;

        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute()]
        [DataMember]
        public t_InformacionAduanera[] InformacionAduanera
        {
            get
            {
                return this.informacionAduaneraField;
            }
            set
            {
                this.informacionAduaneraField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public decimal cantidad
        {
            get
            {
                return this.cantidadField;
            }
            set
            {
                this.cantidadField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string unidad
        {
            get
            {
                return this.unidadField;
            }
            set
            {
                this.unidadField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string noIdentificacion
        {
            get
            {
                return this.noIdentificacionField;
            }
            set
            {
                this.noIdentificacionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string descripcion
        {
            get
            {
                return this.descripcionField;
            }
            set
            {
                this.descripcionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public decimal valorUnitario
        {
            get
            {
                return this.valorUnitarioField;
            }
            set
            {
                this.valorUnitarioField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [DataMember]
        public bool valorUnitarioSpecified
        {
            get
            {
                return this.valorUnitarioFieldSpecified;
            }
            set
            {
                this.valorUnitarioFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public decimal importe
        {
            get
            {
                return this.importeField;
            }
            set
            {
                this.importeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [DataMember]
        public bool importeSpecified
        {
            get
            {
                return this.importeFieldSpecified;
            }
            set
            {
                this.importeFieldSpecified = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteImpuestos
    {

        private ComprobanteImpuestosRetencion[] retencionesField;

        private ComprobanteImpuestosTraslado[] trasladosField;

        private decimal totalImpuestosRetenidosField;

        private bool totalImpuestosRetenidosFieldSpecified;

        private decimal totalImpuestosTrasladadosField;

        private bool totalImpuestosTrasladadosFieldSpecified;

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Retencion", IsNullable = false)]
        [DataMember]
        public ComprobanteImpuestosRetencion[] Retenciones
        {
            get
            {
                return this.retencionesField;
            }
            set
            {
                this.retencionesField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Traslado", IsNullable = false)]
        [DataMember]
        public ComprobanteImpuestosTraslado[] Traslados
        {
            get
            {
                return this.trasladosField;
            }
            set
            {
                this.trasladosField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public decimal totalImpuestosRetenidos
        {
            get
            {
                return this.totalImpuestosRetenidosField;
            }
            set
            {
                this.totalImpuestosRetenidosField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [DataMember]
        public bool totalImpuestosRetenidosSpecified
        {
            get
            {
                return this.totalImpuestosRetenidosFieldSpecified;
            }
            set
            {
                this.totalImpuestosRetenidosFieldSpecified = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public decimal totalImpuestosTrasladados
        {
            get
            {
                return this.totalImpuestosTrasladadosField;
            }
            set
            {
                this.totalImpuestosTrasladadosField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        [DataMember]
        public bool totalImpuestosTrasladadosSpecified
        {
            get
            {
                return this.totalImpuestosTrasladadosFieldSpecified;
            }
            set
            {
                this.totalImpuestosTrasladadosFieldSpecified = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteImpuestosRetencion
    {

        private ComprobanteImpuestosRetencionImpuesto impuestoField;

        private decimal importeField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]        
        public ComprobanteImpuestosRetencionImpuesto impuesto
        {
            get
            {
                return this.impuestoField;
            }
            set
            {
                this.impuestoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public decimal importe
        {
            get
            {
                return this.importeField;
            }
            set
            {
                this.importeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public enum ComprobanteImpuestosRetencionImpuesto
    {

        /// <comentarios/>
        [EnumMember]
        ISR,

        /// <comentarios/>
        [EnumMember]
        IVA,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteImpuestosTraslado
    {

        private ComprobanteImpuestosTrasladoImpuesto impuestoField;

        private decimal tasaField;

        private decimal importeField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]        
        public ComprobanteImpuestosTrasladoImpuesto impuesto
        {
            get
            {
                return this.impuestoField;
            }
            set
            {
                this.impuestoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public decimal tasa
        {
            get
            {
                return this.tasaField;
            }
            set
            {
                this.tasaField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public decimal importe
        {
            get
            {
                return this.importeField;
            }
            set
            {
                this.importeField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public enum ComprobanteImpuestosTrasladoImpuesto
    {

        /// <comentarios/>
        [EnumMember]
        IVA,

        /// <comentarios/>
        [EnumMember]
        IEPS,
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract(Namespace = "http://www.sat.gob.mx/cfd/3")]    
    public partial class ComprobanteComplemento
    {

        private System.Xml.XmlElement[] anyField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [DataMember]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteAddenda
    {


        private System.Xml.XmlElement[] anyField;

        /// <comentarios/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [DataMember]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
    }

    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [DataContract(Namespace = "http://www.sat.gob.mx/cfd/3")]
    public enum ComprobanteTipoDeComprobante
    {

        /// <comentarios/>
        [EnumMember]
        ingreso,

        /// <comentarios/>
        [EnumMember]
        egreso,

        /// <comentarios/>
        [EnumMember]
        traslado,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital", IsNullable = false)]
    [DataContract(Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital", Name = "TimbreFiscalDigital")]
    public partial class TimbreFiscalDigital
    {

        private string versionField;

        private string uUIDField;

        private System.DateTime fechaTimbradoField;

        private string selloCFDField;

        private string noCertificadoSATField;

        private string selloSATField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string UUID
        {
            get
            {
                return this.uUIDField;
            }
            set
            {
                this.uUIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public System.DateTime FechaTimbrado
        {
            get
            {
                return this.fechaTimbradoField;
            }
            set
            {
                this.fechaTimbradoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string selloCFD
        {
            get
            {
                return this.selloCFDField;
            }
            set
            {
                this.selloCFDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string noCertificadoSAT
        {
            get
            {
                return this.noCertificadoSATField;
            }
            set
            {
                this.noCertificadoSATField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember]
        public string selloSAT
        {
            get
            {
                return this.selloSATField;
            }
            set
            {
                this.selloSATField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17626")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.cfdi.com.mx/cfd/3")]
    public partial class Licenciamiento
    {

        private string serialField;

        private string codigoActivacionField;

        private string codigoSitioField;

        private string versionTagField;

        private int serviceIdField;

        private string companyCodeField;

        /// <remarks/>
        public string Serial
        {
            get
            {
                return this.serialField;
            }
            set
            {
                this.serialField = value;
            }
        }

        /// <remarks/>
        public string CodigoActivacion
        {
            get
            {
                return this.codigoActivacionField;
            }
            set
            {
                this.codigoActivacionField = value;
            }
        }

        /// <remarks/>
        public string CodigoSitio
        {
            get
            {
                return this.codigoSitioField;
            }
            set
            {
                this.codigoSitioField = value;
            }
        }

        /// <remarks/>
        public string VersionTag
        {
            get
            {
                return this.versionTagField;
            }
            set
            {
                this.versionTagField = value;
            }
        }

        /// <remarks/>
        public int serviceId
        {
            get
            {
                return this.serviceIdField;
            }
            set
            {
                this.serviceIdField = value;
            }
        }

        /// <remarks/>
        public string CompanyCode
        {
            get
            {
                return this.companyCodeField;
            }
            set
            {
                this.companyCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17626")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.cfdi.com.mx/cfd/3")]
    public partial class TimeZone
    {

        private string standardNameField;

        private int offsetField;

        /// <remarks/>
        public string standardName
        {
            get
            {
                return this.standardNameField;
            }
            set
            {
                this.standardNameField = value;
            }
        }

        /// <remarks/>
        public int offset
        {
            get
            {
                return this.offsetField;
            }
            set
            {
                this.offsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17626")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.cfdi.com.mx/cfd/3")]
    public partial class ControlTag
    {

        private string versionField;

        private TimeZone timeZoneField;

        private Licenciamiento licenciamientoField;

        /// <remarks/>
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        public TimeZone timeZone
        {
            get
            {
                return this.timeZoneField;
            }
            set
            {
                this.timeZoneField = value;
            }
        }

        /// <remarks/>
        public Licenciamiento licenciamiento
        {
            get
            {
                return this.licenciamientoField;
            }
            set
            {
                this.licenciamientoField = value;
            }
        }
    }
}
