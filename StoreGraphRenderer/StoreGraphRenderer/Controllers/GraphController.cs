using StoreGraphRenderer.Data;
using StoreGraphRenderer.Enums;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace StoreGraphRenderer.Controllers
{
    public class GraphController : Controller
    {
        // GET: Graph
        public ActionResult GetTotalSales(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor)
        {
            //convert cluster name to id
            int clusterID = 0;

            foreach (var item in Clusters.ClusterId)
            {
                if (item.Key.ToString() == ClusterNameSelected)
                {
                    clusterID = (int)item.Value;
                }
            }

            DataTable table = StoredProcedureHandler.Get(StoredProcedures.Procedure.sp_GetTotalSales,
                                       new Dictionary<string, string>()
                                       {
                                           { "@StoreID", StoreSelectedID.ToString() },
                                           { "@ClusterID", clusterID.ToString() },
                                           { "@FloorName", StoreSelectedFloor }
                                       });

            var newChart = GraphRender.RenderGraph(model);

            string imageBase64Data = Convert.ToBase64String(newChart);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            if (imageDataURL.Length > 0)
            {
                ViewBag.ImageUrl = imageDataURL;
            }

         

            return View("~/Views/Graph/RenderGraph.cshtml");
        }
    }
}