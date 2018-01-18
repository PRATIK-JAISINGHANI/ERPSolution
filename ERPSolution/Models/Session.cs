using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ERPSolution.Common.EnumMaster;

namespace ERPSolution.Models
{
    public class Session : MastersBase
    {
        #region Constructor

        public Session()
            : base()
        { }

        public Session(Guid Id)
            : base(Id)
        { }

        #endregion

        #region Properties

        public Guid AuthenticationToken { get; set; }

        public Guid IdentityId { get; set; }

        public string IPAddress { get; set; }

        public DateTime AuthorizeTill { get; set; }

        public AuthenticationTypeValues AuthenticationType { get; set; }

        public SessionStatusValues SessionStatus { get; set; }

        #endregion
    }
}