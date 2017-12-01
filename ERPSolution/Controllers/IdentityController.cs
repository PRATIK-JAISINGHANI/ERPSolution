using ERPSolution.DataContracts;
using ERPSolution.Generic;
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

        public ActionResult CreateOrUpdateIdentity(Identity request)
        {
            return View("RetrieveIdentity", UpdateIdentityInternal(request));
        }

        public ActionResult RetrieveIdentity(Guid Id)
        {
            return View(GetIdentityById(Id));
        }

        public ActionResult UpdateIdentity(IdentityRequest request)
        {
            //UpdateIdentityInternal(request);
            return View("RetrieveIdentity", GetIdentityById(request.Id));
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
            return EntityBase.ERPContext.Identity.ToList();
        }

        private Identity GetIdentityById(Guid Id)
        {
            return EntityBase.ERPContext.Identity.Where(i => i.Id == Id).FirstOrDefault();
        }

        private Identity UpdateIdentityInternal(Identity request)
        {
            request.SaveAll();
            return request;
        }

        private void DeleteIdentityInternal(Guid Id)
        {
            var context = new ERPContext();
            EntityBase.ERPContext.Identity.Remove(context.Identity.Where(i => i.Id == Id).First());
            context.SaveChanges();
        }
        #endregion
    }
}