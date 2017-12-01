using ERPSolution.Generic;
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
          return base.SaveAll();
        }

        public override bool DeleteAll()
        {
            return base.DeleteAll();
        }

        #endregion
    }
}