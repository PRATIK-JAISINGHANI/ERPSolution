using ERPSolution.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSolution.Models
{
    public class SecureData : MastersBase
    {
        #region Properties

        public Guid IdentityId { get; set; }

        public string Data { get; set; }

        public override bool SaveAll()
        {
            var context = EntityBase.ERPContext;
            context.SecureData.Add(this);
            return context.SaveChanges() > 0 ? true : false;
        }

        public override bool DeleteAll()
        {
            var context = EntityBase.ERPContext;
            context.SecureData.Remove(this);
            return context.SaveChanges() > 0 ? true : false;
        }

        #endregion
    }
}