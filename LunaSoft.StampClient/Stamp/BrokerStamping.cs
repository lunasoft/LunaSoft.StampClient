using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaSoft.StampClient.Stamp
{
    internal class BrokerStamping
    {
        /// <summary>
        /// Factory Method Stamping
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        internal Entities.StampResult StampInvoice(Entities.Comprobante invoice)
        {
            try
            {
                //Creamos la instancia
                StampFactory factory = new StampFactory();
                IStamping stampService = factory.CreateStampBroker();
                return stampService.GetStamp(invoice);
            }
            catch (Exception ex)
            {
                throw new Exception("No es posible Timbrar la Factura en estos momentos. Favor de intentar de nuevo.", ex);
            }

        }
        /// <summary>
        /// Factory Method Cancel Stamp
        /// </summary>
        /// <param name="UUID"></param>
        /// <param name="rfc"></param>
        /// <param name="stampedBroker"></param>
        /// <param name="pfx"></param>
        /// <param name="passwordPFX"></param>
        /// <returns></returns>
        internal Entities.CancelResult CancelInvoice(string UUID, string rfc, byte[] pfx, string passwordPFX)
        {
            try
            {
                //Creamos la instancia
                StampFactory factory = new StampFactory();
                IStamping stampService = factory.CreateStampBroker();
                return stampService.CancelStamp(UUID, rfc, pfx, passwordPFX);
            }
            catch (Exception ex)
            {
                throw new Exception("No es posible Timbrar la Factura en estos momentos. Favor de intentar de nuevo.", ex);
            }
        }

    }


}
