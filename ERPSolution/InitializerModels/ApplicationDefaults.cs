using ERPSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSolution.Common;

namespace ERPSolution.InitializerModels
{
    public class ApplicationDefaults : MastersBase
    {

        #region Constructor

        public ApplicationDefaults() 
            : base()
        { }

        public ApplicationDefaults(Guid Id) :
            base (Id)
        { }

        #endregion

        #region Properties

        public string PropertyName { get; set; }

        public string DataType { get; set; }

        public string Value { get; set; }

        public bool IsActive { get; set; }

        #endregion
    }
}