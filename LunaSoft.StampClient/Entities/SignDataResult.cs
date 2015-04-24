using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunaSoft.StampClient.Entities
{
    public class SignDataResult
    {
        private string _certificate;

        public string Certificate
        {
            get { return _certificate; }
            set { _certificate = value; }
        }

        private string _digitalSeal;

        public string DigitalSeal
        {
            get { return _digitalSeal; }
            set { _digitalSeal = value; }
        }

        private string _certificateNumber;

        public string CertificateNumber
        {
            get { return _certificateNumber; }
            set { _certificateNumber = value; }
        }

        private string _version;

        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }
    }
}
