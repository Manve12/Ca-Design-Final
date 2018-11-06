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
            sp_GetBay,
            sp_BayGetSales,
            sp_BayGetVolume,
            sp_BayGetProfits,
            sp_GetAverageProfit,
            sp_GetAverageProfitPerBay,
            sp_GetTotalSalesPerBay,
            sp_GetTotalVolumePerBay,
        }

        public static Dictionary<Procedure, string> StoredProcedure = new Dictionary<Procedure, string>
        {
            { Procedure.sp_GetStoreIDs,"sp_GetStoreIDs" },
            { Procedure.sp_GetStoreFloors,"sp_GetStoreFloors" },
            { Procedure.sp_GetRegionLocationSize,"sp_GetRegionLocationSize" },
            { Procedure.sp_GetTotalSales,"sp_GetTotalSales" },
            { Procedure.sp_GetTotalVolume,"sp_GetTotalVolume" },
            { Procedure.sp_GetBay,"sp_GetBay" },
            { Procedure.sp_BayGetSales,"sp_BayGetSales" },
            { Procedure.sp_BayGetVolume,"sp_BayGetVolume" },
            { Procedure.sp_BayGetProfits,"sp_BayGetProfits" },
            { Procedure.sp_GetAverageProfit,"sp_GetAverageProfit" },
            { Procedure.sp_GetAverageProfitPerBay,"sp_GetAverageProfitPerBay" },
            { Procedure.sp_GetTotalSalesPerBay,"sp_GetTotalSalesPerBay" },
            { Procedure.sp_GetTotalVolumePerBay,"sp_GetTotalVolumePerBay" },
        };
    }
}