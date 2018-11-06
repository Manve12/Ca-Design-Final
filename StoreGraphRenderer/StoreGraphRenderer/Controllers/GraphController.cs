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

        private ActionResult DisplayGraph(
            int StoreSelectedID, 
            string ClusterGroupSelected, 
            string ClusterNameSelected, 
            string StoreSelectedFloor, 
            StoredProcedures.Procedure procedure,
            string modelTitle = "",
            string modelGraphType = "column",
            string modelXAxisTitle = "",
            string modelYAxisTitle = "",
            string modelSeriesTitle = "",
            string modelSeriesAdditionalTitle = ""
            )
        {
            DataTable table = StoredProcedureHandler.Get(procedure,
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
                if (item.ItemArray.Length >= 1)
                    xData.Add(item.ItemArray[0].ToString());
                if (item.ItemArray.Length >= 2)
                    yData.Add(item.ItemArray[1].ToString());
                if (item.ItemArray.Length >= 3)
                    xDataAdditional.Add(item.ItemArray[2].ToString());
                if (item.ItemArray.Length >= 4)
                    yDataAdditional.Add(item.ItemArray[3].ToString());
            }

            GraphModel model = new GraphModel();
            model.YAxisData = xData.ToArray();
            model.XAxisData = yData.ToArray();

            model.YAxisDataAdditional = xDataAdditional.ToArray();

            model.XAxisTitle = modelXAxisTitle;
            model.YAxisTitle = modelYAxisTitle;
            model.Title = modelTitle;
            model.GraphType = modelGraphType;
            model.GraphTemplate = GraphTemplate.graphTemplateInterval1000WithX50;
            model.SeriesTitleInitial = modelSeriesTitle;
            model.SeriesTitleAdditional = modelSeriesAdditionalTitle;
            var chart = GraphRenderer.RenderGraph(model);

            string imageData = ImageToBase64.Get(chart);
            if (imageData.Length > 0)
            {
                ViewBag.ImageUrl = imageData;
            }

            return View("~/Views/Graph/RenderGraph.cshtml");
        }

        // GET: Graph Total Sales - line 
        public ActionResult GetTotalSales(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor)
        {
            return DisplayGraph(
                StoreSelectedID, 
                ClusterGroupSelected, 
                ClusterNameSelected, 
                StoreSelectedFloor, 
                StoredProcedures.Procedure.sp_GetTotalSales,
                modelTitle: "Total Sales/Week counter",
                modelGraphType:"line",
                modelXAxisTitle:"Week counter",
                modelYAxisTitle:"Total Sales",
                modelSeriesTitle:"Weeks 13",
                modelSeriesAdditionalTitle:"Weeks 52"
                );
        }

        // GET: Graph Total Volume - line
        public ActionResult GetTotalVolume(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor)
        {
            return DisplayGraph(
                StoreSelectedID,
                ClusterGroupSelected,
                ClusterNameSelected,
                StoreSelectedFloor,
                StoredProcedures.Procedure.sp_GetTotalVolume,
                modelTitle: "Total Volunme/Week counter",
                modelGraphType: "line",
                modelXAxisTitle: "Week counter",
                modelYAxisTitle: "Total Volume",
                modelSeriesTitle: "Weeks 13",
                modelSeriesAdditionalTitle: "Weeks 52"
                );
        }

        // GET: Graph Total Volume - line
        public ActionResult GetAverageProfit(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor)
        {
            return DisplayGraph(
               StoreSelectedID,
               ClusterGroupSelected,
               ClusterNameSelected,
               StoreSelectedFloor,
               StoredProcedures.Procedure.sp_GetAverageProfit,
               modelTitle: "Average Profit/Week counter",
               modelGraphType: "line",
               modelXAxisTitle: "Week counter",
               modelYAxisTitle: "Average Profits",
               modelSeriesTitle: "Weeks 13",
               modelSeriesAdditionalTitle: "Weeks 52"
               );
        }

        // GET: Graph Average Profit Per Bay - column
        public ActionResult GetAverageProfitPerBay(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor)
        {
            return DisplayGraph(
               StoreSelectedID,
               ClusterGroupSelected,
               ClusterNameSelected,
               StoreSelectedFloor,
               StoredProcedures.Procedure.sp_GetAverageProfitPerBay,
               modelTitle: "",
               modelGraphType: "column",
               modelXAxisTitle: "",
               modelYAxisTitle: "",
               modelSeriesTitle: "Weeks 13",
               modelSeriesAdditionalTitle: "Weeks 52"
               );
        }

        // GET: Graph Total Sales Per Bay - column
        public ActionResult GetTotalSalesPerBay(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor)
        {
            return DisplayGraph(
               StoreSelectedID,
               ClusterGroupSelected,
               ClusterNameSelected,
               StoreSelectedFloor,
               StoredProcedures.Procedure.sp_GetTotalSalesPerBay,
               modelTitle: "",
               modelGraphType: "column",
               modelXAxisTitle: "",
               modelYAxisTitle: "",
               modelSeriesTitle: "Weeks 13",
               modelSeriesAdditionalTitle: "Weeks 52"
               );
        }

        // GET: Graph Total Volume Per Bay - column
        public ActionResult GetTotalVolumePerBay(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor)
        {
            return DisplayGraph(
               StoreSelectedID,
               ClusterGroupSelected,
               ClusterNameSelected,
               StoreSelectedFloor,
               StoredProcedures.Procedure.sp_GetTotalVolumePerBay,
               modelTitle: "",
               modelGraphType: "column",
               modelXAxisTitle: "",
               modelYAxisTitle: "",
               modelSeriesTitle: "Weeks 13",
               modelSeriesAdditionalTitle: "Weeks 52"
               );
        }

        // GET: Graph Bay Sales - line
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
   
        // GET: Graph Bay Volume - line
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

        // GET: Graph Bay Average Sales - line
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


        // GET: Graph Bay Total Sales / Volume - pie
        public ActionResult GetTotalVolumeSalesPerBay(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor, string SelectedBay)
        {
            DataTable table = StoredProcedureHandler.Get(StoredProcedures.Procedure.sp_GetTotalVolumeSalesPerBay,
                                      new Dictionary<string, string>()
                                      {
                                           { "@StoreID", StoreSelectedID.ToString() },
                                           { "@ClusterID", GetClusterID(ClusterNameSelected).ToString() },
                                           { "@FloorName", StoreSelectedFloor },
                                           { "@Bay", SelectedBay}
                                      });

            var tableEnumerable = table.AsEnumerable();

            var arr1 = tableEnumerable.Select(s => s.Field<string>("TotalSalesWeeks13")).ToList().ToArray();
            var arr2 = tableEnumerable.Select(s => s.Field<string>("TotalVolumeWeeks13")).ToList().ToArray();

            var arr = arr1.Concat(arr2).ToArray();

            GraphModel model = new GraphModel();
            model.XAxisData = new string[] { "Total Sales", "Total Volume" };
            model.YAxisData = arr;
            model.GraphType = "pie";
            
            
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

        // GET: Graph Bay Total Sales / Volume - pie
        public ActionResult GetTotalSalesProfitPerBay(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor, string SelectedBay)
        {
            DataTable table = StoredProcedureHandler.Get(StoredProcedures.Procedure.sp_GetTotalSalesProfitPerBay,
                                      new Dictionary<string, string>()
                                      {
                                           { "@StoreID", StoreSelectedID.ToString() },
                                           { "@ClusterID", GetClusterID(ClusterNameSelected).ToString() },
                                           { "@FloorName", StoreSelectedFloor },
                                           { "@Bay", SelectedBay}
                                      });

            var tableEnumerable = table.AsEnumerable();

            var arr1 = tableEnumerable.Select(s => s.Field<string>("TotalSalesWeeks13")).ToList().ToArray();
            var arr2 = tableEnumerable.Select(s => s.Field<string>("AverageProfitWeeks13")).ToList().ToArray();

            var arr = arr1.Concat(arr2).ToArray();

            GraphModel model = new GraphModel();
            model.XAxisData = new string[] { "Total Sales", "Average Profit" };
            model.YAxisData = arr;
            model.GraphType = "pie";


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

        // GET: Graph Bay Total Volume / Profit - pie
        public ActionResult GetTotalVolumeProfitPerBay(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor, string SelectedBay)
        {
            DataTable table = StoredProcedureHandler.Get(StoredProcedures.Procedure.sp_GetTotalVolumeProfitPerBay,
                                      new Dictionary<string, string>()
                                      {
                                           { "@StoreID", StoreSelectedID.ToString() },
                                           { "@ClusterID", GetClusterID(ClusterNameSelected).ToString() },
                                           { "@FloorName", StoreSelectedFloor },
                                           { "@Bay", SelectedBay}
                                      });

            var tableEnumerable = table.AsEnumerable();

            var arr1 = tableEnumerable.Select(s => s.Field<string>("TotalVolumeWeeks13")).ToList().ToArray();
            var arr2 = tableEnumerable.Select(s => s.Field<string>("AverageProfitWeeks13")).ToList().ToArray();

            var arr = arr1.Concat(arr2).ToArray();

            GraphModel model = new GraphModel();
            model.XAxisData = new string[] { "Total Volume", "Average Profit" };
            model.YAxisData = arr;
            model.GraphType = "pie";


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

        // GET: Graph Bay Total Sales / Volume / Profit - pie
        public ActionResult GetTotalSalesVolumeProfitPerBay(int StoreSelectedID, string ClusterGroupSelected, string ClusterNameSelected, string StoreSelectedFloor, string SelectedBay)
        {
            DataTable table = StoredProcedureHandler.Get(StoredProcedures.Procedure.sp_GetTotalSalesVolumeProfitPerBay,
                                      new Dictionary<string, string>()
                                      {
                                           { "@StoreID", StoreSelectedID.ToString() },
                                           { "@ClusterID", GetClusterID(ClusterNameSelected).ToString() },
                                           { "@FloorName", StoreSelectedFloor },
                                           { "@Bay", SelectedBay}
                                      });

            var tableEnumerable = table.AsEnumerable();

            var arr1 = tableEnumerable.Select(s => s.Field<string>("TotalSalesWeeks13")).ToList().ToArray();
            var arr2 = tableEnumerable.Select(s => s.Field<string>("TotalVolumeWeeks13")).ToList().ToArray();
            var arr3 = tableEnumerable.Select(s => s.Field<string>("AverageProfitWeeks13")).ToList().ToArray();

            var arr = arr1.Concat(arr2).ToArray();
            arr = arr.Concat(arr3).ToArray();

            GraphModel model = new GraphModel();
            model.XAxisData = new string[] { "Total Sales", "Total Volume", "Average Profit" };
            model.YAxisData = arr;
            model.GraphType = "pie";
            
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