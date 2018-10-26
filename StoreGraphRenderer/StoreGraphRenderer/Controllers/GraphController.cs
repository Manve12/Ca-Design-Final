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
    public class GraphController : Controller
    {
        // GET: Graph
        public ActionResult RenderGraph(int StoreID, string ClusterGroupSelected, string ClusterNameSelected, string FloorName)
        {
            //convert cluster name to id
            int clusterID = 0;

            foreach (var item in Clusters.ClusterName)
            {
                if (item.Key.ToString() == ClusterNameSelected)
                {
                    clusterID = (int)item.Value;
                }
            }

            DataTable table = StoredProcedureHandler.Get(StoredProcedures.Procedure.sp_GetRegionLocationSize,
                                       new Dictionary<string, string>()
                                       {
                                           { "@StoreID", StoreID.ToString() },
                                           { "@ClusterID", clusterID.ToString() },
                                           { "@FloorName", FloorName }
                                       });
            return View();
        }
    }
}