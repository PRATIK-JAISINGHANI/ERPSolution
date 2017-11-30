using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static ERPSolution.Common.EnumMaster;

namespace ERPSolution.Models
{
    public class Identity : MastersBase
    {
        #region Constructor

        public Identity()
        {
            Init();
        }

        #endregion

        #region Properties

        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string MobileNo { get; set; }

        public string EMailId { get; set; }

        public ValidationStatus ValidationStatus { get; set; }

        #endregion

        #region Private Methods

        private void Init()
        {
        }

        #endregion

        #region Public Methods

        public override bool SaveAll()
        {
            var context = base.ERPContext;
            context.Identity.Add(this);
            return context.SaveChanges() > 0 ? true : false;
        }

        public override bool DeleteAll()
        {
            var context = base.ERPContext;
            context.Identity.Remove(this);
            return context.SaveChanges() > 0 ? true : false;
        }

        #endregion
    }
}