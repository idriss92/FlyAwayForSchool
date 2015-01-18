using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FlyAwayForSchool.Controllers
{
    public class VolController : Controller
    {
        private FlyAwayDataEntities db = new FlyAwayDataEntities();

        // GET: Vol
        public ActionResult Index()
        {
            return View(db.Vols.ToList());
        }

        // GET: Vol/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vols vol = db.Vols.Find(id);
            if (vol == null)
            {
                return HttpNotFound();
            }
            return View(vol);
        }

        // GET: Vol/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vol/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vols vol)
        {
            if (ModelState.IsValid)
            {
                db.Vols.Add(vol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vol);
        }

        // GET: Vol/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vols vol = db.Vols.Find(id);
            if (vol == null)
            {
                return HttpNotFound();
            }
            return View(vol);
        }

        // POST: Vol/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Depart,Arrivee,DepartHeure,ArriveeHeure,Distance,Prix,HeureDepart,HeureArrivee")] Vols vol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vol);
        }

        // GET: Vol/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vols vol = db.Vols.Find(id);
            if (vol == null)
            {
                return HttpNotFound();
            }
            return View(vol);
        }

        // POST: Vol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vols vol = db.Vols.Find(id);
            db.Vols.Remove(vol);
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