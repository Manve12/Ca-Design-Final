using StoreGraphRenderer.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreGraphRenderer.Controllers
{
    public class StoredProcedureController : Controller
    {
        public DataTable Get(StoredProcedures.Procedure procedure)
        {
            string procedureName = "";

            foreach(var name in StoredProcedures.StoredProcedure)
            {
                if (name.Key == procedure)
                {
                    procedureName = name.Value;
                    break;
                }
            }



            return new DataTable();
        }
    }
}