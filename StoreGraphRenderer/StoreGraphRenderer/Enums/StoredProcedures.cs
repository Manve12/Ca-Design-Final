using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreGraphRenderer.Enums
{
    public static class StoredProcedures
    {
        public enum Procedure
        {
            sp_GetRegionLocationSize,
            sp_GetTotalSales
        }

        public static Dictionary<Procedure, string> StoredProcedure = new Dictionary<Procedure, string>
        {
            { Procedure.sp_GetRegionLocationSize,"sp_GetRegionLocationSize" },
            { Procedure.sp_GetTotalSales,"sp_GetTotalSales" }
        };
    }
}