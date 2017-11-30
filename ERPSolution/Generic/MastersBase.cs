using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSolution.Models
{
    public abstract class MastersBase
    {
        #region Properties 

        public ERPContext ERPContext { get { return new ERPContext(); } }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

        #endregion

        #region Public Methods

        public abstract bool SaveAll();

        public abstract bool DeleteAll();

        #endregion
    }
}