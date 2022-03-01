using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult InventoryIndex()
        {
            //Organizers Inventory
            return View();
        }


    }
}
