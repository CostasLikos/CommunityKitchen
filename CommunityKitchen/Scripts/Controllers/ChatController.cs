using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRSimpleChat.Controllers
{
    public class ChatController : Controller
    {
       
        public ActionResult ChatIndex()
        {
            ViewBag.Message = "Welcome to the Chat Room";

            return View();
        }
    }
}