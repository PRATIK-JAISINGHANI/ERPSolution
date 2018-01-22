using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ERPSolution.Helper
{
    public class FilterHelper
    {
        #region Properties

        public string PropertyName { get; set; }

        public string PropertyValue { get; set; }

        public string DataType { get; set; }

        public string Comparison { get; set; }

        #endregion

        #region Public Methods

        public static FilterHelper CreateFilter(string propertyName, string propertyValue, string dataType, string comparison)
        {
            return new FilterHelper() { PropertyName = propertyName, PropertyValue = propertyValue, DataType = dataType, Comparison = comparison };
        }

        #endregion
    }
}