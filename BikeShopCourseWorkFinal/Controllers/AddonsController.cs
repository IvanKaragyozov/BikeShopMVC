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
    public class AddonsController : Controller
    {
        private SystemDBContext db = new SystemDBContext();

        // GET: Addons
        public ActionResult Index()
        {
            return View(db.Addons.ToList());
        }

        // GET: Addons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addons addons = db.Addons.Find(id);
            if (addons == null)
            {
                return HttpNotFound();
            }
            return View(addons);
        }

        // GET: Addons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Addons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Price,AddonName,Weight,isToolKitIncluded,Warranty")] Addons addons)
        {
            if (ModelState.IsValid)
            {
                db.Addons.Add(addons);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addons);
        }

        // GET: Addons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addons addons = db.Addons.Find(id);
            if (addons == null)
            {
                return HttpNotFound();
            }
            return View(addons);
        }

        // POST: Addons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,AddonName,Weight,isToolKitIncluded,Warranty")] Addons addons)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addons).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addons);
        }

        // GET: Addons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addons addons = db.Addons.Find(id);
            if (addons == null)
            {
                return HttpNotFound();
            }
            return View(addons);
        }

        // POST: Addons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Addons addons = db.Addons.Find(id);
            db.Addons.Remove(addons);
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
