using Entities;
using Microsoft.AspNet.Identity;
using MyDataBase;
using PersistentLayer.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Entities.IEntities;
using System.Data.Entity;

namespace Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext db;
        private EventRepository eventService;

        public EventController()
        {
            db = new ApplicationDbContext();
            eventService = new EventRepository(db);
        }

        public ActionResult EventsIndex(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            List<Event> eventslist = db.Events.Where(x => x.EventDate >= DateTime.Now).OrderBy(x => x.EventDate).ToList();
            
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(eventslist.ToPagedList(pageNumber, pageSize));
        }
        // GET: Event
        public ActionResult UpcomingEvents()
        {
            //All upcoming events
            return View();
        }
        public ActionResult EventDetails(Guid id)
        {
            Event ev = eventService.GetById(id);
            return View(ev);
        }
        [Authorize(Roles = SetRoles.Donator)]
        public ActionResult ArchivedEvents()
        {
            //Completed Events
            return View();
        }

        // GET: Event/Create
        [Authorize(Roles = SetRoles.SAdmin)]
        public ActionResult CreateEvent()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SetRoles.SAdmin)]
        public ActionResult CreateEvent([Bind(Include = "Id,Title,Description,Photo,Address,date,EventDate")] Event eve, HttpPostedFileBase photo)
        {
            string currentUserId = User.Identity.GetUserId();
            var usersSubscribed = db.Users.Where(x => x.IsSubscribed == true).ToList();

            var user = db.Users.Where(x => x.Id == currentUserId).FirstOrDefault();

            if (ModelState.IsValid)
            {
                if (!(photo == null))
                {
                    eve.Photo = photo.FileName;
                    photo.SaveAs(Server.MapPath("~/Assets/images/ImagesSaved/" + photo.FileName));
                }

                eve.Moderator = user;

                eventService.Add(eve);
                eventService.Save();


                foreach (var us in usersSubscribed)
                {
                    us.NewEventCreated(eve.EventDate,eve.Title);
                }

                return RedirectToAction("EventsIndex");

            }
            return View("EventsIndex");
        }

        // GET: Event/Delete
        public ActionResult DeleteEvent(Guid id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event ev = eventService.GetById(id);
            if (ev == null)
            {
                return HttpNotFound();
            }
            return View(ev);

        }

        // POST: Edit/Delete/5
        [HttpPost, ActionName("DeleteEvent")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            eventService.Delete(id);
            eventService.Save();
            return RedirectToAction("OrganizeEvents");
        }




        // GET: Event/Edit
        [Authorize(Roles = SetRoles.SAdmin)]
        public ActionResult EditEvent(Guid id)
        {
            Event ev = eventService.GetById(id);

            //var fullPath = Path.GetFullPath(ev.Photo);

            if (ev == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View(ev);
        }
        // POST: Event/Edit


        [HttpPost, ActionName("EditEvent")]
        public async Task<ActionResult> EditEvent([Bind(Include = "Id,Title,Description,Photo,Address,EventDate,ModeratorId")] Event eve, HttpPostedFileBase photo)
        {
            
            if (ModelState.IsValid)
            {
                //var existingEvent = db.Events.Find(eve.Id);


                if (photo != null)
                {
                    eve.Photo = photo.FileName;
                    photo.SaveAs(Server.MapPath("~/Assets/images/ImagesSaved/" + photo.FileName));
                    db.Entry(eve).State = EntityState.Modified;
                }
                else
                {
                    var existingEvent = db.Events.FirstOrDefault(x=>x.Id==eve.Id);
                    db.Entry(existingEvent).State = EntityState.Detached;
                    eve.Photo = existingEvent.Photo;
                    db.Entry(eve).State = EntityState.Modified;
                }

                await db.SaveChangesAsync();
                return RedirectToAction("OrganizeEvents");
            }
            return View(eve);
        }

        [Authorize(Roles = SetRoles.SAdmin)]
        public ActionResult OrganizeEvents(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            string currentUserId = User.Identity.GetUserId();
            var userIsSuperAdmin = User.IsInRole("SuperAdmin");

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            List<Event> eventslist = db.Events.Where(x => x.ModeratorId == currentUserId).ToList();
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return userIsSuperAdmin ? View(db.Events.ToList().ToPagedList(pageNumber, pageSize)) : View(eventslist.ToPagedList(pageNumber, pageSize));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}