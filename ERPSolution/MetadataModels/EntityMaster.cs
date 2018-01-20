using ERPSolution.Common;
using ERPSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSolution.MetadataModels
{
    public class EntityMaster : MastersBase
    {
        #region Properties

        public EntityTypeName EntityType { get; set; }

        public string EntityName { get; set; }

        public string ClassName { get; set; }

        public string AssemblyName { get; set; }

        public string NamespaceName { get; set; }

        public bool IsParent { get; set; }

        public bool IsChild { get; set; }

        #endregion
    }
}