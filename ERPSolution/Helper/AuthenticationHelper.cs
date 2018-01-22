using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSolution.Helper
{
    public static class AuthenticationHelper
    {
        #region Public Methods

        public static bool Authenticate (string userName, string password)
        {
            EntityHelper.GetEntity(Common.EntityTypeName.Identity, FilterHelper.CreateFilter("Code", userName,"","" ));
            return true;
        }

        #endregion
    }
}