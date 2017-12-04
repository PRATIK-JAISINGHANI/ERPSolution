using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSolution.DataContracts
{
    public class LoginRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}