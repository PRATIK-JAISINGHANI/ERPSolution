using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSolution.Models
{
    public class Session : MastersBase
    {
        #region Properties

        public Guid AuthenticationToken { get; set; }

        public Guid IdentityId { get; set; }

        public string IPAddress { get; set; }

        public DateTime AuthorizeTill { get; set; }

        #endregion
    }
}