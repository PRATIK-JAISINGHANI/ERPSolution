using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSolution.Common
{
    public enum EntityTypeName : Int64
    {
        ApplicationDefaults = 1,
        Identity = 2,
        SecureData = 3,
        UserMaster = 4,
        Session = 5
    }
}