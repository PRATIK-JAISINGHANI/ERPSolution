using ERPSolution.Common;
using ERPSolution.InitializerModels;
using ERPSolution.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ERPSolution.Generic
{
    public class EntityBase
    {
        #region Constructor

        public EntityBase(EntityTypeName entityType)
        {
            EntityType = entityType;
        }

        #endregion

        #region Properties

        public static ERPContext ERPContext { get; set; }

        public static List<ApplicationDefaults> InstanceValues { get; set; }

        public EntityTypeName EntityType { get; set; }

        #endregion
    }
}