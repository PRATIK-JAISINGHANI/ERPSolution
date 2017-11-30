using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ERPSolution.Common.EnumMaster;

namespace ERPSolution.DataContracts
{
    public class IdentityRequest
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string MobileNo { get; set; }

        public string EMailId { get; set; }

        public ValidationStatus ValidationStatus { get; set; }
    }
}