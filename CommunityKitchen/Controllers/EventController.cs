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

        // GET: Event/Create
        public ActionResult CreateEvent()
        {
            return View();
        }

        // POST: Event/Create
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

        public ActionResult DeleteEvent(Guid id)
        {
            es.Delete(id);
            es.Save();
            return RedirectToAction("OrganizeEvents");
        }

        // GET: Event/Edit
        public ActionResult EditEvent(Guid id)
        {
            Event ev = es.GetById(id);

            if (ev == null)
                return HttpNotFound();

            return View(ev);
        }
        // POST: Event/Edit
        [HttpPost]
        public ActionResult Edit(Event ev)
        {
            if (ModelState.IsValid)
            {
                es.Update(ev.Id);
                es.Save();
                TempData["message"] = "Edited!";
                return RedirectToAction("OrganizeEvents");
            }
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