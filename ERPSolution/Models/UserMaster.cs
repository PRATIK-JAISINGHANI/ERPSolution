using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ERPSolution.Common.EnumMaster;

namespace ERPSolution.Models
{
    public class UserMaster : MastersBase
    {
        #region Properties

        public Guid Id { get; set; }

        public Guid IdentityId { get; set; }

        public Guid ContactId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string MobileNo { get; set; }

        public bool IsActive { get; set; }

        public override bool SaveAll()
        {
            var context = base.ERPContext;
            context.UserMaster.Add(this);
            return context.SaveChanges() > 0 ? true : false;
        }

        public override bool DeleteAll()
        {
            var context = base.ERPContext;
            context.UserMaster.Remove(this);
            return context.SaveChanges() > 0 ? true : false;
        }

        #endregion
    }
}