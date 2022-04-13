using MyDataBase;
using PersistentLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using System.Net;
using PagedList;
using Entities;

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


        // GET: Archive
        [Authorize(Roles = SetRoles.Donator)]
        public ActionResult Index()
        {
            //ViewBag.searchevTitle = searchevTitle;
            //ViewBag.searchevDescr = searchevDescr;
            //ViewBag.searchevDate = searchevDate;
            //ViewBag.CurrentSortOrder = sortOrder;

            dynamic dy = new ExpandoObject();
            dy.eventsList = eventService.GetAll();
            dy.causesList = causeService.GetAll();


            //switch (sortOrder?.ToUpper())
            //{
            //    case "evTitle_desc":
            //        dy.eventsList = eventService.GetAll().OrderByDescending(s => s.Title);
            //        break;
            //    case "evTitle_asc":
            //        dy.eventsList = eventService.GetAll().OrderBy(s => s.Title); 
            //        break;
            //    case "evDescr_desc":
            //        dy.eventsList = eventService.GetAll().OrderByDescending(s => s.Description);
            //        break;
            //    case "evDescr_asc":
            //        dy.eventsList = eventService.GetAll().OrderBy(s => s.Description);
            //        break;
            //    case "evDate_desc":
            //        dy.eventsList = eventService.GetAll().OrderByDescending(s => s.EventDate);
            //        break;
            //    case "evDate_asc":
            //        dy.eventsList = eventService.GetAll().OrderBy(s => s.EventDate);
            //        break;
            //    case "causeTitle_desc":
            //        dy.causesList = causeService.GetAll().OrderByDescending(s => s.Title);
            //        break;
            //    case "causeTitle_asc":
            //        dy.causesList = causeService.GetAll().OrderBy(s => s.Title);
            //        break;
            //    case "causeDescr_desc":
            //        dy.causesList = causeService.GetAll().OrderByDescending(s => s.Description);
            //        break;
            //    case "causeDescr_asc":
            //        dy.causesList = causeService.GetAll().OrderBy(s => s.Description);
            //        break;
            //    default:
            //        Console.WriteLine("Oops. Something went wrong");
            //        break;
            //}

            //int pageSize = pSize ?? 5;
            //int pageNumber = page ?? 1;

            return View(dy);
        }

    }
}