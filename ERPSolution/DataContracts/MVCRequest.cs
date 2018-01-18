using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSolution.DataContracts
{
    public class MVCRequest
    {
        public Guid SessionId { get; set; }

        public Guid AuthenticationToken { get; set; }
    }
}