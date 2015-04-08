using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LazyCals.Models;

namespace LazyCals.Controllers
{
    public class CalorieEntriesController : Controller
    {
        private CalorieEntryDBContext db = new CalorieEntryDBContext();

        // GET: CalorieEntries
        public ActionResult Index()
        {
            return View(db.CalorieEntries.ToList());
        }

        // GET: CalorieEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalorieEntry calorieEntry = db.CalorieEntries.Find(id);
            if (calorieEntry == null)
            {
                return HttpNotFound();
            }
            return View(calorieEntry);
        }

        // GET: CalorieEntries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalorieEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Calories,DateAdded,Quality")] CalorieEntry calorieEntry)
        {
            if (ModelState.IsValid)
            {
                calorieEntry.DateAdded = DateTime.UtcNow;
                db.CalorieEntries.Add(calorieEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calorieEntry);
        }

        // GET: CalorieEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalorieEntry calorieEntry = db.CalorieEntries.Find(id);
            if (calorieEntry == null)
            {
                return HttpNotFound();
            }
            return View(calorieEntry);
        }

        // POST: CalorieEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Calories,DateAdded,Quality")] CalorieEntry calorieEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calorieEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calorieEntry);
        }

        // GET: CalorieEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalorieEntry calorieEntry = db.CalorieEntries.Find(id);
            if (calorieEntry == null)
            {
                return HttpNotFound();
            }
            return View(calorieEntry);
        }

        // POST: CalorieEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CalorieEntry calorieEntry = db.CalorieEntries.Find(id);
            db.CalorieEntries.Remove(calorieEntry);
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
