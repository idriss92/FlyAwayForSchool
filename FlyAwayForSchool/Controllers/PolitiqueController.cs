using FlyAwayForSchool.CodeToUse;
using FlyAwayForSchool.Custom;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FlyAwayForSchool.Controllers
{
    [CustomAuthorize(Users = "idriss2004@hotmail.com")]
    public class PolitiqueController : Controller
    {
        private FlyAwayDataEntities db = new FlyAwayDataEntities();
        private UseJson calculate = new UseJson();
        // GET: Politique
        public ActionResult Index()
        {
            return View(db.Politique.ToList());
        }

        // GET: Politique/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Politique politique = db.Politique.Find(id);
            if (politique == null)
            {
                return HttpNotFound();
            }
            return View(politique);
        }

        // GET: Politique/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Politique/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Politique politique)
        {
            if (ModelState.IsValid)
            {
                db.Politique.Add(politique);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(politique);
        }





        // GET: Politique/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Politique politique = db.Politique.Find(id);
            if (politique == null)
            {
                return HttpNotFound();
            }
            return View(politique);
        }

        // POST: Politique/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Politique politique)
        {
            if (ModelState.IsValid)
            {
                db.Entry(politique).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(politique);
        }

        // GET: Politique/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Politique politique = db.Politique.Find(id);
            if (politique == null)
            {
                return HttpNotFound();
            }
            return View(politique);
        }

        // POST: Politique/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Politique politique = db.Politique.Find(id);
            db.Politique.Remove(politique);
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