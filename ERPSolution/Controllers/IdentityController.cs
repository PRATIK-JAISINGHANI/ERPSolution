using ERPSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPSolution.Controllers
{
    public class IdentityController : Controller
    {
        #region Public Methods

        // GET: Identity
        public ActionResult Index()
        {
            return View(GetIdentities());
        }

        public ActionResult CreateIdentity()
        {
            return View();
        }

        public ActionResult RetrieveIdentity(Guid Id)
        {
            return View();
        }

        public ActionResult UpdateIdentity()
        {
            return View();
        }

        public ActionResult DeleteIdentity()
        {
            return View();
        }

        #endregion

        #region Private Methods

        private List<Identity> GetIdentities()
        {
            var context = new ERPContext();
            return context.Identity.ToList();
        }

        #endregion
    }
}