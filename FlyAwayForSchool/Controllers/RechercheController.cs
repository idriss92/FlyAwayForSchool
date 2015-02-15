using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FlyAwayForSchool.Controllers
{
    public class RechercheController : Controller
    {
        CodeToUse.UseJson ap = new CodeToUse.UseJson();
        int av;
        FlyAwayDataEntities db = new FlyAwayDataEntities();
        // GET: Recherche

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Resultat(string searchString, string search, string datedepart, string datearrivee, string heuredepart)
        {
            av = ap.CalculDistance(searchString, search);

            var vol = db.Vols.ToList().AsEnumerable<Vols>();
            // vol = (IEnumerable)vol;
            if (!string.IsNullOrEmpty(searchString) && vol != null)
            {
                vol = vol.Where(s => s.Depart == searchString);
            }

            if (!string.IsNullOrEmpty(search) && vol != null)
            {
                vol = vol.Where(s => s.Arrivee == search);
            }

            if (!string.IsNullOrEmpty(datedepart) && vol != null)
            {
                string a = "00:00:00";
                datedepart = datedepart + " " + a;
                vol = vol.Where(s => s.Depart == datedepart);
            }

            if (!string.IsNullOrEmpty(datearrivee) && vol != null)
            {
                string a = "00:00:00";
                datearrivee = datearrivee + " " + a;
                vol = vol.Where(s => s.Arrivee == datearrivee);
            }

            if (!string.IsNullOrEmpty(heuredepart) && vol != null)
            {

                vol = vol.Where(s => s.Arrivee.Contains(heuredepart));
            }

            //var p = vol;
            ViewData["recherche"] = vol;
            //ViewBag.Recherche = vol;
            var p = ViewData["recherche"];

            //var po = ViewBag.Recherche;
            return View();

        }

        // Get: Recherche/Details/5
        public ActionResult DetailsResultat(int? id)
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


        // Post : RechercheVol/Reserver/5
        public ActionResult ReserverVol(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Vols reserver = db.Vols.Find(id);
            Reservations official = new Reservations();
            if (reserver == null)
            {
                return HttpNotFound();
            }

            official.DateReservation = DateTime.Now;
            official.IdVol = reserver.Id;
            official.TarifReservation = reserver.Prix;
            official.Vols = reserver;

            db.Reservations.Add(official);
            db.SaveChanges();
            //return RedirectToRoute("Reservation");

            return View("Index");

            
        }
    }
}