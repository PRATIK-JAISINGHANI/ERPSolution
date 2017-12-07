using ERPSolution.Generic;
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

        public Guid IdentityId { get; set; }

        public Guid ContactId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public string MobileNo { get; set; }

        public bool IsActive { get; set; }

        public override bool SaveAll()
        {
          return base.SaveAll();
        }

        public override bool DeleteAll()
        {
            return base.DeleteAll();
        }

        #endregion
    }
}