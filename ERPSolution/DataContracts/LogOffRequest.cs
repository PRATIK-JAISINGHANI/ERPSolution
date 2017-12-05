using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSolution.DataContracts
{
    public class LogOffRequest
    {
        public Guid AuthenticationToken { get; set; }

        public Guid SessionId { get; set; }
    }
}