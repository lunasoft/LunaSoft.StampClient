using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunaSoft.StampClient.Base
{
    public class BLBaseClass
    {
        StringBuilder errorStringBuilder = new StringBuilder();
        StringBuilder warningStringBuilder = new StringBuilder();

        public string CodError
        {
            get { return string.Empty != this.errorStringBuilder.ToString() ? this.errorStringBuilder.ToString().Split('|').Where(w => !string.IsNullOrEmpty(w)).FirstOrDefault<string>() : ""; }
        }

        public string WarningCodError
        {
            get { return string.Empty != this.warningStringBuilder.ToString() ? this.warningStringBuilder.ToString().Split('|').Where(w => !string.IsNullOrEmpty(w)).FirstOrDefault<string>() : ""; }
        }

        public string ErrorMessage
        {
            get
            {
                return this.errorStringBuilder.ToString();
            }
        }

        public string WarningMessage
        {
            get
            {
                return this.warningStringBuilder.ToString();
            }
        }

        public bool HasError
        {
            get
            {
                return string.Empty != this.errorStringBuilder.ToString();
            }
        }

        public bool HasWarning
        {
            get
            {
                return string.Empty != this.warningStringBuilder.ToString();
            }
        }

        /// <summary>
        /// Add a new error to the error buffer.
        /// </summary>
        /// <param name="errorString">The error message.</param>
        public void AddError(string errorString)
        {
            this.errorStringBuilder.Append('|' + errorString);
        }

        /// <summary>
        /// Add a new warning to the warning buffer.
        /// </summary>
        /// <param name="errorString">The warning message.</param>
        public void AddWarning(string warningString)
        {
            this.warningStringBuilder.Append('|' + warningString);
        }
    }

}
