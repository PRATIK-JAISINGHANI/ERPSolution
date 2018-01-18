using ERPSolution.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using ERPSolution.Helper;

namespace ERPSolution.Models
{
    public class SecureData : MastersBase
    {
        #region Constructor

        public SecureData()
            : base()
        { }

        public SecureData(Guid Id)
            : base(Id)
        { }

        #endregion
        #region Declarations 

        private string _Data;

        #endregion

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