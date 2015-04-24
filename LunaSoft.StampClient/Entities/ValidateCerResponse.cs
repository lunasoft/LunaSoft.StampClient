using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunaSoft.StampClient.Entities
{
    public class ValidateCerResponse : Base.BLBaseClass
    {
        public byte[] PFX { get; set; }
        public bool IsDemo { get; set; }
        public bool IsFiel { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? NotBefore { get; set; }
        public DateTime? NotAfter { get; set; }
        public string SubjectName { get; set; }
        public string IssuerName { get; set; }        
    }
}
