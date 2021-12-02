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
    public class BikesController : Controller
    {
        private SystemDBContext db = new SystemDBContext();

        // GET: Bikes
        public ActionResult Index()
        {
            var bikes = db.Bikes.Include(b => b.Sizes);
            return View(bikes.ToList());
        }

        // GET: Bikes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bikes bikes = db.Bikes.Find(id);
            if (bikes == null)
            {
                return HttpNotFound();
            }
            return View(bikes);
        }

        // GET: Bikes/Create
        public ActionResult Create()
        {
            ViewBag.SizesId = new SelectList(db.Sizes, "Id", "Size");
            return View();
        }

        // POST: Bikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BikeName,IsCarbon,Price,Size,Weight,Warranty,SizesId")] Bikes bikes)
        {
            if (ModelState.IsValid)
            {
                db.Bikes.Add(bikes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SizesId = new SelectList(db.Sizes, "Id", "Size", bikes.SizesId);
            return View(bikes);
        }

        // GET: Bikes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bikes bikes = db.Bikes.Find(id);
            if (bikes == null)
            {
                return HttpNotFound();
            }
            ViewBag.SizesId = new SelectList(db.Sizes, "Id", "Size", bikes.SizesId);
            return View(bikes);
        }

        // POST: Bikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BikeName,IsCarbon,Price,Size,Weight,Warranty,SizesId")] Bikes bikes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bikes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SizesId = new SelectList(db.Sizes, "Id", "Size", bikes.SizesId);
            return View(bikes);
        }

        // GET: Bikes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bikes bikes = db.Bikes.Find(id);
            if (bikes == null)
            {
                return HttpNotFound();
            }
            return View(bikes);
        }

        // POST: Bikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bikes bikes = db.Bikes.Find(id);
            db.Bikes.Remove(bikes);
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
