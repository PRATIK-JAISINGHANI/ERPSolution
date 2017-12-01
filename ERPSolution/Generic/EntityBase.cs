using ERPSolution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ERPSolution.Generic
{
    public class EntityBase
    {
        #region Properties

        public static ERPContext ERPContext { get; set; }

        #endregion
    }
}