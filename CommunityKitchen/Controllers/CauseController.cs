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
using Microsoft.AspNet.Identity;
using PagedList;

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
        [Authorize(Roles = SetRoles.SAdminMember)]
        public ActionResult OrganizeCause(string sortOrder, string currentFilter, string searchString, int? page)
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
            List<Cause> causesList = db.Causes.Where(x => x.ModeratorId == currentUserId).ToList();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return userIsSuperAdmin ? View(db.Causes.ToList().ToPagedList(pageNumber, pageSize)) : View(causesList.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = SetRoles.Admin)]
        public ActionResult EditCauseJson(Guid id, string amount)
        {
            var cause = causeService.GetById(id);
            double convertedAmount = Convert.ToDouble(amount);

            cause.CurrentAmmount += convertedAmount;

            causeService.Save();
            return RedirectToAction("Cause", "CauseIndex");
        }

        public ActionResult CauseIndex(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            ViewBag.CurrentSortOrder = sortOrder == "AS" ? "DE" : "AS";
            ViewBag.SearchString = searchString;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var causes = causeService.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                causes = causes.Where(x => x.Title.ToUpper().Contains(searchString.ToUpper())).ToList();
            }

            switch (sortOrder?.ToUpper())
            {
                case "AS": causes = causes.OrderBy(x => x.CurrentAmmount).ToList(); break;
                case "DE": causes = causes.OrderByDescending(x => x.CurrentAmmount).ToList(); break;
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(causes.ToList().ToPagedList(pageNumber, pageSize));

            //View for organizer with all his events
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
            string currentUserId = User.Identity.GetUserId();
            //var usersSubscribed = db.Users.Where(x => x.IsSubscribed == true).ToList();


            var user = db.Users.Where(x => x.Id == currentUserId).FirstOrDefault();

            if (ModelState.IsValid)
            {
                if (!(photo == null))
                {
                    cause.Photo = photo.FileName;
                    photo.SaveAs(Server.MapPath("~/Assets/images/ImagesSaved/" + photo.FileName));
                }

                cause.Moderator = user;

                cause.Id = Guid.NewGuid();
                db.Causes.Add(cause);
                await db.SaveChangesAsync();

                //foreach (var us in usersSubscribed)
                //{
                //    us.NewEventCreated(cause.date, eve.Title);
                //}

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
        public async Task<ActionResult> EditCause([Bind(Include = "Id,Title,Description,Photo,TargetGoal,CurrentAmmount,ModeratorId")] Cause cause, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (!(photo == null))
                {
                    cause.Photo = photo.FileName;
                    photo.SaveAs(Server.MapPath("~/Assets/images/ImagesSaved/" + photo.FileName));
                }
                else
                {
                    var existingCause = db.Causes.FirstOrDefault(x => x.Id == cause.Id);
                    db.Entry(existingCause).State = EntityState.Detached;
                    cause.Photo = existingCause.Photo;
                    db.Entry(cause).State = EntityState.Modified;
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