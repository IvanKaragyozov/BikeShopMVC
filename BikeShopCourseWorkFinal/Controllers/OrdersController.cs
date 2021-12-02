using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeShopCourseWorkFinal.Models;

namespace BikeShopCourseWorkFinal.Controllers
{
    public class OrdersController : Controller
    {
        private SystemDBContext db = new SystemDBContext();

        // GET: Orders
        public ActionResult Index(string searchString)
        {
            var orders = db.Orders.Include(o => o.Addons).Include(u => u.Bikes);

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString));
            }

            return View(orders.ToList());

           
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.AddonsId = new SelectList(db.Addons, "Id", "AddonName");
            ViewBag.BikesId = new SelectList(db.Bikes, "Id", "BikeName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,TimeOfPurchase,isForCommercialUse,PhoneNumber,BikeId,AddonsId")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddonsId = new SelectList(db.Addons, "Id", "AddonName", orders.AddonsId);
            ViewBag.BikesId = new SelectList(db.Bikes, "Id", "BikeName", orders.BikeId);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddonsId = new SelectList(db.Addons, "Id", "AddonName", orders.AddonsId);
            ViewBag.BikesId = new SelectList(db.Bikes, "Id", "BikeName", orders.BikeId);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,TimeOfPurchase,isForCommercialUse,PhoneNumber,BikeId,AddonsId")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddonsId = new SelectList(db.Addons, "Id", "AddonName", orders.AddonsId);
            ViewBag.BikesId = new SelectList(db.Bikes, "Id", "BikeName", orders.BikeId);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
            db.SaveChanges();
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
