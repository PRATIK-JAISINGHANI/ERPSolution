using ERPSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace ERPSolution.Helper
{
    public class SessionHelper
    {
        #region Public Methods

        public static Session CreateSession (Guid identityId)
        {
            var session = new Session();
            session.Id = Guid.NewGuid();
            session.IdentityId = identityId;
            session.IPAddress = "-1";
            session.AuthenticationToken = Guid.NewGuid();
            session.AuthorizeTill = DateTime.Now.AddHours(3);
            return session;
        }

        #endregion
    }
}