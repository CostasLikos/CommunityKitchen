using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities;
using MyDataBase;
using PersistentLayer.IRepository;
using PersistentLayer.Repository;
using Microsoft.AspNet.Identity;

namespace CommunityKitchen.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        private ApplicationDbContext db;
        private ItemRepository itemService;

        public ItemController()
        {
            db = new ApplicationDbContext();
            itemService = new ItemRepository(db);
        }

        // GET: Item
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.Items.ToListAsync());
        //}
        [Authorize(Roles = SetRoles.SAdmin)]
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            string currentUserId = User.Identity.GetUserId();
            var userIsSuperAdmin = User.IsInRole("SuperAdmin");
            var items = db.Items.AsQueryable();

            if (!userIsSuperAdmin)
            {
                items = items.Where(x => x.ModeratorId == currentUserId);
            }
            switch (sortOrder)
            {
                case "name_desc":
                    items = items.OrderByDescending(s => s.ItemName);
                    break;
                case "Price":
                    items = items.OrderBy(s => s.ItemName);
                    break;
                case "price_desc":
                    items = items.OrderByDescending(s => s.Price);
                    break;
                default:
                    items = items.OrderBy(s => s.ItemName);
                    break;
            }

            return  View(items);
        }

        [Authorize(Roles = SetRoles.SAdmin)]
        public ActionResult EditItemJson(Guid id, string name, string price)
        {
            var item = itemService.GetById(id);
            decimal convertedAmount = Convert.ToDecimal(price);
            item.ItemName = name;
            item.Price = convertedAmount;
            itemService.Save();
            return RedirectToAction("Item", "Index");
        }


        [Authorize(Roles = SetRoles.SAdmin)]
        public ActionResult AddQuantity(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = itemService.GetById(id);
            item.Quantity += 1;
            itemService.Save();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = SetRoles.SAdmin)]
        public ActionResult RemoveQuantity(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = itemService.GetById(id);

            if (item.Quantity > 0)
            {
                item.Quantity -= 1;
                itemService.Save();
            }
            else
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Item/Details/5
        [Authorize(Roles = SetRoles.SAdmin)]
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Item/Create
        [Authorize(Roles = SetRoles.SAdmin)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SetRoles.SAdmin)]
        public async Task<ActionResult> Create([Bind(Include = "Id,ItemName,Quantity,Price")] Item item)
        {

            string currentUserId = User.Identity.GetUserId();
            var user = db.Users.Where(x => x.Id == currentUserId).FirstOrDefault();

            if (ModelState.IsValid)
            {
                item.Id = Guid.NewGuid();
                item.Moderator = user;
                db.Items.Add(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Item/Edit/5
        [Authorize(Roles = SetRoles.SAdmin)]
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Item/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SetRoles.SAdmin)]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ItemName,Quantity,Price")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Item/Delete/5
        [Authorize(Roles = SetRoles.SAdmin)]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = SetRoles.SAdmin)]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Item item = await db.Items.FindAsync(id);
            db.Items.Remove(item);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
