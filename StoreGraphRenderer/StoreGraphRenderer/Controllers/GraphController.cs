using StoreGraphRenderer.Data;
using StoreGraphRenderer.Enums;
using StoreGraphRenderer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace StoreGraphRenderer.Controllers
{
    public class GraphController : Controller
    {
        private int GetClusterID(string ClusterNameSelected)
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
            return clusterID;
        }

        // GET: Graph Total Sales
        public ActionResult GetTotalSales(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor)
        {
            DataTable table = StoredProcedureHandler.Get(StoredProcedures.Procedure.sp_GetTotalSales,
                                       new Dictionary<string, string>()
                                       {
                                           { "@StoreID", StoreSelectedID.ToString() },
                                           { "@ClusterID", GetClusterID(ClusterNameSelected).ToString() },
                                           { "@FloorName", StoreSelectedFloor }
                                       });

            List<string> xData = new List<string>();
            List<string> yData = new List<string>();

            List<string> xDataAdditional = new List<string>();
            List<string> yDataAdditional = new List<string>();

            foreach (DataRow item in table.Rows)
            {
                xData.Add(item.ItemArray[0].ToString());
                yData.Add(item.ItemArray[1].ToString());
                xDataAdditional.Add(item.ItemArray[2].ToString());
                yDataAdditional.Add(item.ItemArray[3].ToString());
            }

            GraphModel model = new GraphModel();
            model.YAxisData = xData.ToArray();
            model.XAxisData = yData.ToArray();

            model.YAxisDataAdditional = xDataAdditional.ToArray();
            
            model.XAxisTitle = "Week counter";
            model.YAxisTitle = "Total Sales";
            model.Title = "Total Sales/Week counter";
            model.GraphType = "line";
            model.GraphTemplate = GraphTemplate.graphTemplateInterval1000WithX50;
            model.Width = 1200;
            model.Height = 1200;
            model.SeriesTitleInitial = "Weeks 13";
            model.SeriesTitleAdditional = "Weeks 52";
            var weeks13Chart = GraphRenderer.RenderGraph(model);

            string imageBase64Data = Convert.ToBase64String(weeks13Chart);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            if (imageDataURL.Length > 0)
            {
                ViewBag.ImageUrl = imageDataURL;
            }
            
            return View("~/Views/Graph/RenderGraph.cshtml");
        }

        // GET: Graph Total Volume
        public ActionResult GetTotalVolume(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor)
        {
            DataTable table = StoredProcedureHandler.Get(StoredProcedures.Procedure.sp_GetTotalVolume,
                                       new Dictionary<string, string>()
                                       {
                                           { "@StoreID", StoreSelectedID.ToString() },
                                           { "@ClusterID", GetClusterID(ClusterNameSelected).ToString() },
                                           { "@FloorName", StoreSelectedFloor }
                                       });

            List<string> xData = new List<string>();
            List<string> yData = new List<string>();

            List<string> xDataAdditional = new List<string>();
            List<string> yDataAdditional = new List<string>();

            foreach (DataRow item in table.Rows)
            {
                xData.Add(item.ItemArray[0].ToString());
                yData.Add(item.ItemArray[1].ToString());
                xDataAdditional.Add(item.ItemArray[2].ToString());
                yDataAdditional.Add(item.ItemArray[3].ToString());
            }

            GraphModel model = new GraphModel();
            model.YAxisData = xData.ToArray();
            model.XAxisData = yData.ToArray();

            model.YAxisDataAdditional = xDataAdditional.ToArray();

            model.XAxisTitle = "Week counter";
            model.YAxisTitle = "Total Volume";
            model.Title = "Total Volume/Week counter";
            model.GraphType = "line";
            model.GraphTemplate = GraphTemplate.graphTemplateInterval1000WithX50;
            model.Width = 1200;
            model.Height = 1200;
            model.SeriesTitleInitial = "Weeks 13";
            model.SeriesTitleAdditional = "Weeks 52";
            var weeks13Chart = GraphRenderer.RenderGraph(model);

            string imageBase64Data = Convert.ToBase64String(weeks13Chart);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            if (imageDataURL.Length > 0)
            {
                ViewBag.ImageUrl = imageDataURL;
            }

            return View("~/Views/Graph/RenderGraph.cshtml");
        }

        // GET: Graph Bay Sales
        public ActionResult GetBaySales(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor, string SelectedBay)
        {

            return View("~/Views/Graph/RenderGraph.cshtml");
        }

        // GET: Graph Bay Volume
        public ActionResult GetBayVolume(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor, string SelectedBay)
        {
            return View("~/Views/Graph/RenderGraph.cshtml");
        }

        // GET: Graph Bay Average Sales
        public ActionResult GetBayAverageSales(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor, string SelectedBay)
        {
            return View("~/Views/Graph/RenderGraph.cshtml");
        }
    }
}