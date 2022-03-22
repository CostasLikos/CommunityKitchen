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
        public ActionResult EventDetails(Guid id)
        {
            Event ev = es.GetById(id);
            return View(ev);
        }
        public ActionResult ArchivedEvents()
        {
            //Completed Events
            return View();
        }
        public ActionResult CreateEvent(Event ev)
        {
            //if (ModelState.IsValid)
            //{
            //    es.Add(ev);
            //    es.Save();
            //    TempData["Message"] = "Event Created";
            //    return RedirectToAction("OrganizeEvents");
            //}
            return View();
        }
        public ActionResult DeleteEvent(Guid id)
        {
            es.Delete(id);
            es.Save();
            return RedirectToAction("OrganizeEvents");
        }

        public ActionResult EditEvent(Guid id)
        {
            Event ev = es.GetById(id);
            es.Update(id);
            return View(ev);
        }


        public ActionResult OrganizeEvents()
        {
            //Organizers event dashboard option
            var events = es.GetAll();

            return View(events);
        }
    }
}