using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSolution.DataContracts
{
    public class LoginResponse
    {
        public bool IsLoginSuccessful { get; set; }

        public Guid SessionId { get; set; }

        public Guid AuthenticationToken { get; set; }

        public DateTime AuthorizeTill { get; set; }
    }
}