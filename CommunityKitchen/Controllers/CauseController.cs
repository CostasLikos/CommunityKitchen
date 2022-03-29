using Entities;
using MyDataBase;
using PersistentLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult CauseIndex()
        {
            var causes = causeService.GetAll();

            //View for organizer with all his events
            return View(causes);
        }
        // GET: Cause
        public ActionResult UpcomingCauses()
        {
            //All upcoming events
            return View();
        }
        public ActionResult CauseDetails(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var kati = db.Causes.Find(id);
            Cause cause = kati;
            if (cause == null)
            {
                return HttpNotFound();
            }
            return View(cause);
        }
       
        public ActionResult ArchivedCauses()
        {
            //Completed Causes
            return View();
        }

        // GET: Cause/Create
        public ActionResult CreateCause()
        {
            return View();
        }

        // POST: Cause/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCause([Bind(Include = "Id,Title,Description,Photo,Address,date,EventDate")] Cause cause)
        {
            if (ModelState.IsValid)
            {
                causeService.Add(cause);
                causeService.Save();
                return RedirectToAction("EventsIndex");
            }
            return View("EventsIndex");
        }

        public ActionResult DeleteCause(Guid id)
        {
            causeService.Delete(id);
            causeService.Save();
            return RedirectToAction("OrganizeEvents");
        }

        // GET: Cause/Edit
        public ActionResult EditCause(Guid id)
        {
            Cause cause = causeService.GetById(id);

            if (cause == null)
                return HttpNotFound();

            return View(cause);
        }
        // POST: Cause/Edit
        [HttpPost]
        public ActionResult EditCause(Cause ev)
        {
            if (ModelState.IsValid)
            {
                causeService.Update(ev.Id);
                causeService.Save();
                TempData["message"] = "Edited!";
                return RedirectToAction("OrganizeEvents");
            }
            return View(ev);
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