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
        // GET: Causes/Details
        public async Task<ActionResult> CauseDetails(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cause cause = await db.Causes.FindAsync(id);
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

        // GET: Causes/Create
        public ActionResult CreateCause()
        {
            return View();
        }

        // POST: Causes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCause([Bind(Include = "Id,Title,Description,Photo,TargetGoal,CurrentAmmount,ModeratorId")] Cause cause)
        {
            if (ModelState.IsValid)
            {
                cause.Id = Guid.NewGuid();
                db.Causes.Add(cause);
                await db.SaveChangesAsync();
                return RedirectToAction("OrganizeCause");
            }

            return View(cause);
        }

        // GET: Causes/Delete
        public async Task<ActionResult> DeleteCause(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cause cause = await db.Causes.FindAsync(id);
            if (cause == null)
            {
                return HttpNotFound();
            }
            return View(cause);
        }

        // POST: Causes/Delete
        [HttpPost, ActionName("DeleteCause")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Cause cause = await db.Causes.FindAsync(id);
            db.Causes.Remove(cause);
            await db.SaveChangesAsync();
            return RedirectToAction("OrganizeCause");
        }

        // GET: Causes/Edit
        public async Task<ActionResult> EditCause(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cause cause = await db.Causes.FindAsync(id);
            if (cause == null)
            {
                return HttpNotFound();
            }
            return View(cause);
        }

        // POST: Causes/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditCause([Bind(Include = "Id,Title,Description,Photo,TargetGoal,CurrentAmmount,ModeratorId")] Cause cause)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cause).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("OrganizeCause");
            }
            return View(cause);
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