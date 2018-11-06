using StoreGraphRenderer.Data;
using StoreGraphRenderer.Enums;
using StoreGraphRenderer.Models;
using StoreGraphRenderer.Other;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            var chart = GraphRenderer.RenderGraph(model);

            string imageData = ImageToBase64.Get(chart);
            if (imageData.Length > 0)
            {
                ViewBag.ImageUrl = imageData;
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
            var chart = GraphRenderer.RenderGraph(model);

            string imageData = ImageToBase64.Get(chart);
            if (imageData.Length > 0)
            {
                ViewBag.ImageUrl = imageData;
            }

            return View("~/Views/Graph/RenderGraph.cshtml");
        }

        // GET: Graph Total Volume
        public ActionResult GetAverageProfit(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor)
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
            model.YAxisTitle = "Average Profit";
            model.Title = "Average profit";
            model.GraphType = "line";
            model.GraphTemplate = GraphTemplate.graphTemplateInterval1000WithX50;
            model.Width = 1200;
            model.Height = 1200;
            model.SeriesTitleInitial = "Weeks 13";
            model.SeriesTitleAdditional = "Weeks 52";
            var chart = GraphRenderer.RenderGraph(model);

            string imageData = ImageToBase64.Get(chart);
            if (imageData.Length > 0)
            {
                ViewBag.ImageUrl = imageData;
            }

            return View("~/Views/Graph/RenderGraph.cshtml");
        }


        // GET: Graph Bay Sales
        public ActionResult GetBaySales(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor, string SelectedBay)
        {
            DataTable table = StoredProcedureHandler.Get(StoredProcedures.Procedure.sp_BayGetSales,
                                      new Dictionary<string, string>()
                                      {
                                           { "@StoreID", StoreSelectedID.ToString() },
                                           { "@ClusterID", GetClusterID(ClusterNameSelected).ToString() },
                                           { "@FloorName", StoreSelectedFloor },
                                           { "@Bay", SelectedBay}
                                      });

            var tableEnumerable = table.AsEnumerable();

            GraphModel model = new GraphModel();
            model.XAxisData = tableEnumerable.Select(s => s.Field<string>("TotalSalesWeeks13")).ToList().ToArray();
            
            model.YAxisData = tableEnumerable.Select(s => s.Field<string>("TotalSalesWeeks13")).ToList().ToArray(); // retrieves point for weeks 13 
            model.YAxisDataAdditional = tableEnumerable.Select(s => s.Field<string>("TotalSalesWeeks52")).ToList().ToArray(); // retrieves point for weeks 52 

            model.XAxisTitle = "";
            model.YAxisTitle = "Total Sales";
            model.Title = "Total Sales Weeks 13/52";
            model.GraphType = "point";
            model.GraphTemplate = GraphTemplate.graphTemplateInterval100;
            
            model.SeriesTitleInitial = "Weeks 13";
            model.SeriesTitleAdditional = "Weeks 52";
            var chart = GraphRenderer.RenderGraph(model);

            string imageData = ImageToBase64.Get(chart);
            if (imageData.Length > 0)
            {
                ViewBag.ImageUrl = imageData;
            }

            return View("~/Views/Graph/RenderGraph.cshtml");
        }
   
        // GET: Graph Bay Volume
        public ActionResult GetBayVolume(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor, string SelectedBay)
        {
            DataTable table = StoredProcedureHandler.Get(StoredProcedures.Procedure.sp_BayGetVolume,
                                      new Dictionary<string, string>()
                                      {
                                           { "@StoreID", StoreSelectedID.ToString() },
                                           { "@ClusterID", GetClusterID(ClusterNameSelected).ToString() },
                                           { "@FloorName", StoreSelectedFloor },
                                           { "@Bay", SelectedBay}
                                      });

            var tableEnumerable = table.AsEnumerable();

            GraphModel model = new GraphModel();
            model.XAxisData = tableEnumerable.Select(s => s.Field<string>("TotalVolumeWeeks13")).ToList().ToArray();

            model.YAxisData = tableEnumerable.Select(s => s.Field<string>("TotalVolumeWeeks13")).ToList().ToArray(); // retrieves point for weeks 13 
            model.YAxisDataAdditional = tableEnumerable.Select(s => s.Field<string>("TotalVolumeWeeks52")).ToList().ToArray(); // retrieves point for weeks 52 

            model.XAxisTitle = "";
            model.YAxisTitle = "Total Volume";
            model.Title = "Total Volume Weeks 13/52";
            model.GraphType = "point";
            model.GraphTemplate = GraphTemplate.graphTemplateInterval100;

            model.SeriesTitleInitial = "Weeks 13";
            model.SeriesTitleAdditional = "Weeks 52";
            var chart = GraphRenderer.RenderGraph(model);

            string imageData = ImageToBase64.Get(chart);
            if (imageData.Length > 0)
            {
                ViewBag.ImageUrl = imageData;
            }

            return View("~/Views/Graph/RenderGraph.cshtml");
        }

        // GET: Graph Bay Average Sales
        public ActionResult GetBayAverageProfit(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor, string SelectedBay)
        {
            DataTable table = StoredProcedureHandler.Get(StoredProcedures.Procedure.sp_BayGetProfits,
                                      new Dictionary<string, string>()
                                      {
                                           { "@StoreID", StoreSelectedID.ToString() },
                                           { "@ClusterID", GetClusterID(ClusterNameSelected).ToString() },
                                           { "@FloorName", StoreSelectedFloor },
                                           { "@Bay", SelectedBay}
                                      });

            var tableEnumerable = table.AsEnumerable();

            GraphModel model = new GraphModel();
            model.XAxisData = tableEnumerable.Select(s => s.Field<string>("AverageProfitWeeks13")).ToList().ToArray();

            model.YAxisData = tableEnumerable.Select(s => s.Field<string>("AverageProfitWeeks13")).ToList().ToArray(); // retrieves point for weeks 13 
            model.YAxisDataAdditional = tableEnumerable.Select(s => s.Field<string>("AverageProfitWeeks52")).ToList().ToArray(); // retrieves point for weeks 52 

            model.YAxisTitle = "Average Profit";
            model.Title = "Average Profit Weeks 13/52";
            model.GraphType = "point";
            model.GraphTemplate = GraphTemplate.graphTemplateInterval10;

            model.SeriesTitleInitial = "Weeks 13";
            model.SeriesTitleAdditional = "Weeks 52";
            var chart = GraphRenderer.RenderGraph(model);

            string imageData = ImageToBase64.Get(chart);
            if (imageData.Length > 0)
            {
                ViewBag.ImageUrl = imageData;
            }

            return View("~/Views/Graph/RenderGraph.cshtml");
        }
    }
}