using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSolution.Generic
{
    public static class DbHelper
    {
        #region Public Methods

        public static bool SaveAll(Type type, object entityObject)
        {
            if(EntityBase.ERPContext.Entry(entityObject).State == System.Data.Entity.EntityState.Detached)
                EntityBase.ERPContext.Set(type).Add(entityObject);
            //
            return EntityBase.ERPContext.SaveChanges() > 0 ? true : false;
        }

        public static bool DeleteAll(Type type, object entityObject)
        {
            EntityBase.ERPContext.Set(type).Remove(entityObject);
            return EntityBase.ERPContext.SaveChanges() > 0 ? true : false;
        }

        #endregion
    }
}