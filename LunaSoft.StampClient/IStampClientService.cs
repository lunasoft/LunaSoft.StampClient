using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunaSoft.StampClient
{
    public interface IStampClientService
    {
        Entities.SignResult SignInvoice(byte[] bCer, byte[] bKey, string password, Entities.Comprobante invoice);
        Entities.SignResult SignInvoice(byte[] bCer, byte[] bKey, string password, string xmlInvoice, string rfcEmisor);
        Entities.StampResult Stamp(Entities.Comprobante invoice);
        Entities.StampResult Stamp(string xmlInvoice);
        Entities.CancelResult Cancel(string UUID, string rfc, byte[] bCer, byte[] bKey, string password);
    }
}
