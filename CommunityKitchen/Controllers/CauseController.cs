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
        [Authorize]
        // GET: Cause
        [Authorize(Roles =SetRoles.SAdminMember)]
        public ActionResult OrganizeCause()
        {
            //Organizers cause dashboard option
            var causes = causeService.GetAll();

            return View(causes);
        }
        [Authorize(Roles = SetRoles.Admin)]
        public ActionResult EditCauseJson(Guid id, string amount)
        {
            var cause = causeService.GetById(id);
            double convertedAmount = Convert.ToDouble(amount);

            cause.CurrentAmmount += convertedAmount;
            //causeService.Update(Guid.Parse(id));
            causeService.Save();
            return RedirectToAction("Cause","CauseIndex");
            //return View("CauseIndex");
        }
        
        public ActionResult CauseIndex(string sortOrder,string searchString)
        {
            ViewBag.CurrentSortOrder = sortOrder == "AS" ? "DE" : "AS";
            ViewBag.SearchString = searchString;

            var causes = causeService.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                causes = causes.Where(x => x.Title.ToUpper().Contains(searchString.ToUpper())).ToList();
            }
            
            switch (sortOrder?.ToUpper())
            {
                case "AS": causes = causes.OrderBy(x => x.CurrentAmmount).ToList();break;
                case "DE": causes =causes.OrderByDescending(x => x.CurrentAmmount).ToList(); break;
            }

            //View for organizer with all his events
            return View(causes.ToList());
        }
        // GET: Cause
        public ActionResult UpcomingCauses()   //na mpei filter by current date
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

        public ActionResult CauseDonate(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cause cause = causeService.GetById(id);
            if (cause == null)
            {
                return HttpNotFound();
            }
            return View(cause);
        }
        [Authorize(Roles = SetRoles.Donator)]
        public ActionResult ArchivedCauses()
        {
            //Completed Causes
            return View();
        }

        // GET: Causes/Create
        [Authorize(Roles = SetRoles.SAdmin)]
        public ActionResult CreateCause()
        {
            return View();
        }

        // POST: Causes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SetRoles.SAdmin)]
        public async Task<ActionResult> CreateCause([Bind(Include = "Id,Title,Description,Photo,TargetGoal,CurrentAmmount,ModeratorId")] Cause cause, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (!(photo == null))
                {
                    cause.Photo = photo.FileName;
                    photo.SaveAs(Server.MapPath("~/Assets/images/ImagesSaved/" + photo.FileName));
                }

                cause.Id = Guid.NewGuid();
                db.Causes.Add(cause);
                await db.SaveChangesAsync();
                return RedirectToAction("OrganizeCause");
            }

            return View(cause);
        }

        // GET: Causes/Delete
        [Authorize(Roles = SetRoles.SuperAdmin)]
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
        [Authorize(Roles = SetRoles.SuperAdmin)]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Cause cause = await db.Causes.FindAsync(id);
            db.Causes.Remove(cause);
            await db.SaveChangesAsync();
            return RedirectToAction("OrganizeCause");
        }

        // GET: Causes/Edit
        [Authorize(Roles = SetRoles.SAdmin)]
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
        [Authorize(Roles = SetRoles.SAdmin)]
        public async Task<ActionResult> EditCause([Bind(Include = "Id,Title,Description,Photo,TargetGoal,CurrentAmmount,ModeratorId")] Cause cause, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (!(photo == null))
                {
                    cause.Photo = photo.FileName;
                    photo.SaveAs(Server.MapPath("~/Assets/images/ImagesSaved/" + photo.FileName));
                }

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