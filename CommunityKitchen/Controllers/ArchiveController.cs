using MyDataBase;
using PersistentLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;

namespace CommunityKitchen.Controllers
{
    public class ArchiveController : Controller
    {
        private ApplicationDbContext db;
        private CauseRepository causeService;
        private EventRepository eventService;
        //private StoryRepository storyService;

        public ArchiveController()
        {
            db = new ApplicationDbContext();
            causeService = new CauseRepository(db);
            eventService = new EventRepository(db);
            //storyService = new StoryRepository(db);
        }

        dynamic expando = new ExpandoObject();

        // GET: Archive
        public ActionResult Index()
        {
            dynamic dy = new ExpandoObject();
            dy.eventsList = eventService.GetAll();
            dy.causesList = causeService.GetAll();

            return View(dy);
        }

    }
}