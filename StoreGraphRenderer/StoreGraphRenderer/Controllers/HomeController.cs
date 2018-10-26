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
            List<string> clusterGroupToNameList = new List<string>();

            foreach (var item in Clusters.ClusterName)
            {
                if (item.Value.ToString() == ClusterGroupSelected) {
                    clusterGroupToNameList.Add(item.Key);
                }
            }

            ViewBag.ListOfClusterNames = clusterGroupToNameList;
            return View();
        }
    }
}