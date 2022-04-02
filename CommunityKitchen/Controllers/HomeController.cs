using MyDataBase;
using PersistentLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommunityKitchen.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        private CauseRepository causeService;
        public HomeController()
        {
            db = new ApplicationDbContext();
            causeService = new CauseRepository(db);
        }
        public ActionResult Index()
        {

            var causes = causeService.GetAll();

            return View(causes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}