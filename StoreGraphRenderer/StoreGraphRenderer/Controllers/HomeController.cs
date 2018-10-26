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

            ViewBag.ListOfClusterGroup = Enum.GetValues(typeof(Clusters.ClusterGroup))
                                         .Cast<Clusters.ClusterGroup>()
                                         .Select(enu => enu.ToString())
                                         .ToList();

            //ViewBag.ListOfClusterNames = Clusters.ClusterName.Select(name => name.Value).ToList();
            return View();
        }

        public ActionResult SelectCluster(string ClusterGroupSelected)
        {

            return View();
        }
    }
}