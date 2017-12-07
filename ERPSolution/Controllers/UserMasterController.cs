using ERPSolution.Generic;
using ERPSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPSolution.Controllers
{
    public class UserMasterController : Controller
    {
        // GET: UserMaster
        public ActionResult Index()
        {
            return View(GetUsers());
        }

        public ActionResult GetUserForm()
        {
            return View("UserForm");
        }

        public ActionResult CreateUser(UserMaster userMaster)
        {
            if(CreateUserInternal(userMaster))
                return View();
            //
            return View("Index", GetUsers());
        }

        public ActionResult RetrieveUser(Guid id)
        {
            return View(GetUserById(id));
        }

        public ActionResult UpdateUser()
        {
            return View();
        }

        public ActionResult DeleteUser(Guid id)
        {
            DeleteUserByIdInternal(id);
            return View("Index",GetUsers());
        }

        #region Private Methods

        private List<UserMaster> GetUsers()
        {
            return EntityBase.ERPContext.UserMaster.ToList();
        }

        private UserMaster GetUserById(Guid Id)
        {
            return EntityBase.ERPContext.UserMaster.Where(um => um.Id == Id).FirstOrDefault();
        }

        private bool CreateUserInternal(UserMaster userMaster)
        {
            EntityBase.ERPContext.UserMaster.Add(userMaster);
            return EntityBase.ERPContext.SaveChanges() > 0 ? true : false;
        }

        private bool DeleteUserByIdInternal(Guid Id)
        {
            EntityBase.ERPContext.UserMaster.Remove(EntityBase.ERPContext.UserMaster.Where(um => um.Id == Id).FirstOrDefault());
            return EntityBase.ERPContext.SaveChanges() > 0 ? true : false;
        }

        #endregion
    }
}