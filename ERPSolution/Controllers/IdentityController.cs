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
            return View(GetIdentityById(Id));
        }

        public ActionResult UpdateIdentity()
        {
            return View();
        }

        public ActionResult DeleteIdentity(Guid Id)
        {
            DeleteIdentityInternal(Id);
            return View(Index());
        }

        #endregion

        #region Private Methods

        private List<Identity> GetIdentities()
        {
            var context = new ERPContext();
            return context.Identity.ToList();
        }

        private Identity GetIdentityById(Guid Id)
        {
            var context = new ERPContext();
            return context.Identity.Where(i => i.Id == Id).FirstOrDefault();
        }

        private void DeleteIdentityInternal(Guid Id)
        {
            var context = new ERPContext();
            context.Identity.Remove(context.Identity.Where(i => i.Id == Id).First());
            context.SaveChanges();
        }
        #endregion
    }
}