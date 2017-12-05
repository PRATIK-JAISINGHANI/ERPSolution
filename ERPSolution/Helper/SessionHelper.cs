using ERPSolution.Generic;
using ERPSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using static ERPSolution.Common.EnumMaster;

namespace ERPSolution.Helper
{
    public class SessionHelper
    {
        #region Public Methods

        public static Session CreateSession (Guid identityId, AuthenticationTypeValues authenticationType)
        {
            var identity = EntityBase.ERPContext.Identity.Where(i => i.Id == identityId).FirstOrDefault();
            if (identity == null)
                throw new Exception("Identity was not found");
            //
            var session = new Session();
            session.Id = Guid.NewGuid();
            session.IdentityId = identityId;
            session.IPAddress = "-1";
            session.AuthenticationToken = Guid.NewGuid();
            session.AuthorizeTill = DateTime.Now.AddHours(3);
            session.AuthenticationType = authenticationType;
            session.CreatedBy = Guid.NewGuid();
            session.CreatedDateTime = DateTime.Now;
            SetIdentityPrincipal(identity, session.AuthenticationType);
            session.SessionStatus = SessionStatusValues.LoggedIn;
            session.SaveAll();
            return session;
        }

        public static bool LogOffSession(Guid sessionId, Guid authenticationToken)
        {
            var existingSession = EntityBase.ERPContext.Session.Where(s => s.Id == sessionId && s.AuthenticationToken == authenticationToken && s.SessionStatus == SessionStatusValues.LoggedIn).FirstOrDefault();
            if (existingSession == null)
                return true;
            //
            if(existingSession != null)
            {
                existingSession.SessionStatus = SessionStatusValues.LoggedOff;
                return EntityBase.ERPContext.SaveChanges() > 0 ? true : false;
            }
            return false;
        }
        #endregion

        #region Private Methods

        private static void SetIdentityPrincipal(Identity identity, AuthenticationTypeValues authenticationType)
        {
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(identity.Name, authenticationType.ToString()), null);
        }

        #endregion
    }
}