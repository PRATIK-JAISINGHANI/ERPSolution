using ERPSolution.DataContracts;
using ERPSolution.Generic;
using ERPSolution.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ERPSolution.Common.EnumMaster;

namespace ERPSolution.Controllers
{
    public class AuthenticateController : Controller
    {
        // GET: Authenticate
        public ActionResult Index()
        {
            return View("HomePage2");
        }

        public ActionResult Login(LoginRequest loginRequest)
        {
            var loginResponse = new LoginResponse();
            LoginInternal(loginRequest.Username, loginRequest.Password, ref loginResponse);

            if (loginResponse.IsLoginSuccessful)
                return View("Index");
            else
                return RedirectToAction("Index");
        }

        public ActionResult LogOff(LogOffRequest request)
        {
            if (LogOffInternal(request))
                return RedirectToAction("Index");
            else
                return View("Index");
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

        private bool LogOffInternal(LogOffRequest request)
        {
            return SessionHelper.LogOffSession(request.SessionId, request.AuthenticationToken);
        }
        #endregion
    }
}