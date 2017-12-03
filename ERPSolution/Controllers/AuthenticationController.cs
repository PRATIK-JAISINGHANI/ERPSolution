using ERPSolution.DataContracts;
using ERPSolution.Generic;
using ERPSolution.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERPSolution.Controllers
{
    public class AuthenticationController : ApiController
    {
        [HttpPost, ActionName("Login")]
        public IHttpActionResult Login(string userName, string password)
        {
            var loginResponse = new LoginResponse();
            LoginInternal(userName, password, ref loginResponse);
            return Ok(loginResponse);
        }

        #region Private Methods

        private void LoginInternal(string userName, string password, ref LoginResponse loginResponse)
        {
            var identity = EntityBase.ERPContext.Identity.Where(i => i.Code == userName).FirstOrDefault();
            if (identity != null)
            {
                var secureData = EntityBase.ERPContext.SecureData.Where(sd => sd.IdentityId == identity.Id).FirstOrDefault();
                if (secureData != null)
                    if (secureData.Data == password)
                    {
                        var session = SessionHelper.CreateSession(identity.Id);
                        if (session == null)
                            throw new Exception("Session was not found");
                        //
                        loginResponse.SessionId = session.Id;
                        loginResponse.IsLoginSuccessful = true;
                        loginResponse.AuthenticationToken = session.AuthenticationToken;
                        loginResponse.AuthorizeTill = session.AuthorizeTill;
                    }
            }
        }

        #endregion
    }
}
