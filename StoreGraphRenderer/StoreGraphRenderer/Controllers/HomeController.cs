using StoreGraphRenderer.Data;
using StoreGraphRenderer.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreGraphRenderer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //DataTable table = StoredProcedureHandler.Get(StoredProcedures.Procedure.sp_GetRegionLocationSize, 
            //                           new Dictionary<string, string>()
            //                           {
            //                               { "@SelectedRegion", "3" }
            //                           });
            int t = (int)Clusters.ClusterGroup.Location;
            return View();
        }
    }
}