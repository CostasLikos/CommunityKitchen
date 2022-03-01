using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers
{
    public class SupportController : Controller
    {
        // GET: Support
        public ActionResult SupportCause()
        {
            //Fundraising
            return View();
        }
        public ActionResult CreateCause()
        {
            //Organizers create cause option
            return View();
        }
    }
}