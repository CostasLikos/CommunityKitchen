using Entities;
using MyDataBase;
using PersistentLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CommunityKitchen.Controllers
{
    public class CauseController : Controller
    {

        private ApplicationDbContext db;
        private CauseRepository causeService;
        public CauseController()
        {
            db = new ApplicationDbContext();
            causeService = new CauseRepository(db);
        }

        // GET: Cause
        public ActionResult OrganizeCause()
        {
            //Organizers cause dashboard option
            var causes = causeService.GetAll();

            return View(causes);
        }
    }
}