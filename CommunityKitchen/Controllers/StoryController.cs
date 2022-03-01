using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers
{
    public class StoryController : Controller
    {
        // GET: Story
        public ActionResult StoriesIndex()
        {
            //Stories
            return View();
        }
    }
}