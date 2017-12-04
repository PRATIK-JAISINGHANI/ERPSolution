﻿using ERPSolution.DataContracts;
using ERPSolution.Generic;
using ERPSolution.Helper;
using ERPSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ERPSolution.Common.EnumMaster;

namespace ERPSolution.Controllers
{
    public class AuthenticationController : ApiController
    {
        [HttpPost, ActionName("Login")]
        public HttpResponseMessage Login([FromUri]string userName, [FromUri] string password)
        {
            var loginResponse = new LoginResponse();
            LoginInternal(userName, password, ref loginResponse);
            return new HttpResponseMessage() { Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(loginResponse), System.Text.Encoding.UTF8, "application/json") }; ;
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
                        var session = SessionHelper.CreateSession(identity.Id, AuthenticationTypeValues.Web);
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
