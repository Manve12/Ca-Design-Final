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
            DataTable table = StoredProcedureHandler.Get(StoredProcedures.Procedure.sp_GetStoreIDs, new Dictionary<string, string>(){});

            ViewBag.StoreIDs = table.Select().Select(r => r.ItemArray[0].ToString()).ToList();

            return View();
        }

        public ActionResult SelectStore(string StoreSelectedID, string StoreSelectedFloor)
        {
            DataTable table = StoredProcedureHandler.Get(StoredProcedures.Procedure.sp_GetStoreFloors, 
                                                        new Dictionary<string, string>()
                                                        {
                                                            { "@StoreID", StoreSelectedID }
                                                        });
            ViewBag.StoreSelectedID = StoreSelectedID;
            ViewBag.StoreSelectedFloor = StoreSelectedFloor;
            ViewBag.StoreFloors = table.Select().Select(r => r.ItemArray[0].ToString()).ToList();

            return View();
        }

        public ActionResult SelectFloor(string StoreSelectedID, string StoreSelectedFloor, string ClusterGroupSelected)
        {
            ViewBag.StoreSelectedID = StoreSelectedID;
            ViewBag.StoreSelectedFloor = StoreSelectedFloor;
            ViewBag.ListOfClusterGroup = Enum.GetValues(typeof(Clusters.ClusterGroup))
                                         .Cast<Clusters.ClusterGroup>()
                                         .Select(enu => enu.ToString())
                                         .ToList();
            return View();
        }

        public ActionResult SelectCluster(string StoreSelectedID, string StoreSelectedFloor, string ClusterGroupSelected)
        {
            List<string> clusterGroupToNameList = new List<string>();

            foreach (var item in Clusters.ClusterName)
            {
                if (item.Value.ToString() == ClusterGroupSelected) {
                    clusterGroupToNameList.Add(item.Key);
                }
            }

            ViewBag.StoreSelectedID = StoreSelectedID;
            ViewBag.StoreSelectedFloor = StoreSelectedFloor;
            ViewBag.ListOfClusterNames = clusterGroupToNameList;
            return View();
        }

        public ActionResult RenderButtons(int StoreSelectedID, string StoreSelectedFloor, string ClusterGroupSelected, string ClusterNameSelected)
        {
            ViewBag.StoreSelectedID = StoreSelectedID;
            ViewBag.StoreSelectedFloor = StoreSelectedFloor;
            
            //convert cluster name to id
            int clusterID = 0;

            foreach (var item in Clusters.ClusterId)
            {
                if (item.Key.ToString() == ClusterNameSelected)
                {
                    clusterID = (int)item.Value;
                }
            }

            DataTable table = StoredProcedureHandler.Get(StoredProcedures.Procedure.sp_GetBay,
                                                       new Dictionary<string, string>()
                                                       {
                                                            { "@StoreID", StoreSelectedID.ToString() },
                                                            { "@FloorName", StoreSelectedFloor },
                                                            { "@ClusterID", clusterID.ToString() },
                                                       });
            
            ViewBag.StoreBay = table.Select().Select(r => r.ItemArray[0].ToString()).ToList();

            return View();
        }

        public ActionResult SelectBay(int StoreSelectedID, string StoreSelectedFloor, string ClusterGroupSelected, string ClusterNameSelected, string SelectedBay)
        {
            ViewBag.StoreSelectedID = StoreSelectedID;
            ViewBag.StoreSelectedFloor = StoreSelectedFloor;
            
            return View();
        }
    }
}