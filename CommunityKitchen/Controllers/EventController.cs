using Entities;
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

        public ActionResult EventsIndex()
        {
            var events = eventService.GetAll();

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
            if (ModelState.IsValid)
            {
                if (!(photo == null))
                {
                    eve.Photo = photo.FileName;
                    photo.SaveAs(Server.MapPath("~/Assets/images/ImagesSaved/" + photo.FileName));
                }

                eventService.Add(eve);
                eventService.Save();
                return RedirectToAction("EventsIndex");
            }
            return View("EventsIndex");
        }

        // GET: Event/Delete
        [Authorize(Roles = SetRoles.SuperAdmin)]
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
        [Authorize(Roles = SetRoles.SuperAdmin)]
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
        [Authorize(Roles = SetRoles.SAdmin)] //tODO: edwpera den fernei to photo
        public ActionResult EditEvent([Bind(Include = "Id,Title,Description,Photo,Address,date,EventDate")] Event eve, HttpPostedFileBase photo)
        {
            var tempPhoto = eve.Photo;

            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    eve.Photo = photo.FileName;
                    photo.SaveAs(Server.MapPath("~/Assets/images/ImagesSaved/" + photo.FileName));
                    db.Entry(eve).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    eve.Photo = eve.Photo;
                    db.Entry(eve).State = System.Data.Entity.EntityState.Modified;
                }  
                
                db.SaveChangesAsync();
                return RedirectToAction("OrganizeEvents");
            }
            return View(eve);
        }

        [Authorize(Roles = SetRoles.SAdmin)]
        public ActionResult OrganizeEvents()
        {
            //Organizers event dashboard option
            var events = eventService.GetAll();

            return View(events);
        }
    }
}