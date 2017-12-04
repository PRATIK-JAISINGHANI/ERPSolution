using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSolution.Common
{
    public class EnumMaster
    {
        public enum Gender : int
        {
            Male = 1,
            Female = 2,
            Other = 3
        }

        public enum ValidationStatus : int
        {
            NotValidated = 1,
            Validated = 2,
            Suspended = 3
        }

        public enum AuthenticationTypeValues : int
        {
            Web = 1,
            Mobile = 2
        }

        public enum SessionStatusValues : int
        {
            LoggedIn = 1,
            LoggedOff = 2,
            FoundOrphan = 3
        }
    }
}