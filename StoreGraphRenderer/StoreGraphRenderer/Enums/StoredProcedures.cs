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
            sp_GetStoreIDs,
            sp_GetStoreFloors,
            sp_GetRegionLocationSize,
            sp_GetTotalSales,
            sp_GetTotalVolume,
        }

        public static Dictionary<Procedure, string> StoredProcedure = new Dictionary<Procedure, string>
        {
            { Procedure.sp_GetStoreIDs,"sp_GetStoreIDs" },
            { Procedure.sp_GetStoreFloors,"sp_GetStoreFloors" },
            { Procedure.sp_GetRegionLocationSize,"sp_GetRegionLocationSize" },
            { Procedure.sp_GetTotalSales,"sp_GetTotalSales" },
            { Procedure.sp_GetTotalVolume,"sp_GetTotalVolume" },
        };
    }
}