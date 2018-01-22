using ERPSolution.Common;
using ERPSolution.Generic;
using ERPSolution.MetadataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Web;

namespace ERPSolution.Helper
{
    public class EntityHelper
    {

        #region Public Methods

        public static Object GetEntity(EntityTypeName entityType, Guid Id)
        {
            return EntityBase.ERPContext.Set(Type.GetType(GetEntityNamespace(entityType))).Find(Id);
        }

        public static void GetEntity(EntityTypeName entityType, FilterHelper filterCondition)
        {
            EntityBase.ERPContext.Set(Type.GetType(GetEntityNamespace(entityType))).OfType<DataTable>();
        }

        #endregion

        #region Private Methods

        private static string GetEntityNamespace(EntityTypeName entityType)
        {
            return MetadataModels.Metadata.Entities.Where(em => em.EntityType == entityType).Select(em => em.NamespaceName).FirstOrDefault();
        }

        #endregion
    }
}