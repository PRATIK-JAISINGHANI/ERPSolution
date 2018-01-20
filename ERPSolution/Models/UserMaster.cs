using ERPSolution.Generic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Reflection;
using System.Web;
using static ERPSolution.Common.EnumMaster;

namespace ERPSolution.Models
{
    public class UserMaster : MastersBase
    {
        #region Construstors

        public UserMaster()
            : base()
        { }

        public UserMaster(Guid Id)
            : base(Id)
        {  }

        #endregion

        #region Properties

        public Guid IdentityId { get; set; }

        public Guid ContactId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public string MobileNo { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

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