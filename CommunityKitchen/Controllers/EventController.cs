using Entities;
using MyDataBase;
using PersistentLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext db;
        private EventRepository es;
        public EventController()
        {
            db = new ApplicationDbContext();
            es = new EventRepository(db);
        }

        public ActionResult EventsIndex()
        {
            var events = es.GetAll();

            //View for organizer with all his events
            return View(events);
        }
        // GET: Event
        public ActionResult UpcomingEvents()
        {
            //All upcoming events
            return View();
        }
        public ActionResult EventDetails()
        {
            //event Details
            return View();
        }
        public ActionResult ArchivedEvents()
        {
            //Completed Events
            return View();
        }
        public ActionResult CreateEvent()
        {
            //Organizers create event option
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent([Bind(Include = "Id,Title,Description,Photo,Address,date,EventDate")] Event eve)
        {
            if (ModelState.IsValid)
            {
                es.Add(eve);
                es.Save();
                return RedirectToAction("EventsIndex");
            }
            return View("EventsIndex");
        }
        public ActionResult OrganizeEvents()
        {
            //Organizers event dashboard option
            var events = es.GetAll();

            return View(events);
        }
    }
}