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
            return base.SaveAll();
        }

        public override bool DeleteAll()
        {
            return base.DeleteAll();
        }

        #endregion
    }
}