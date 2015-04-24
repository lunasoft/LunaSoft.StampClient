using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaSoft.StampClient.Stamp
{
    interface IStamping
    {
        Entities.StampResult GetStamp(Entities.Comprobante invoice);
        Entities.CancelResult CancelStamp(string UUID, string rfc, byte[] pfx, string passwordPFX);
    }
}
