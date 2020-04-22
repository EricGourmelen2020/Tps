using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BO;
using Module06_TP01.Data;
using Module06_TP01.Models;

namespace Module06_TP01.Controllers
{
    public class SamouraisController : Controller
    {
        private Module06_TP01Context db = new Module06_TP01Context();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SamouraisVM samVM = new SamouraisVM();
            samVM.Armes = db.Armes.Select(a => new SelectListItem { Text = a.Nom , Value= a.Id.ToString()}).ToList() ;
            return View(samVM);
        }

        // POST: Samourais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraisVM samVM)
        {
            if (ModelState.IsValid)
            {
                Samourai samourai = new Samourai();
                samourai.Nom = samVM.Nom;
                samourai.Force = samVM.Force;
                samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == samVM.ArmeId);
                db.Samourais.Add(samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            samVM.Armes = db.Armes.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();
            return View(samVM);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id, bool? addWeapon, bool? disarm)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }

            SamouraisVM samVM = new SamouraisVM();
            samVM.Id = samourai.Id;
            samVM.Nom = samourai.Nom;
            samVM.Arme = samourai.Arme;
            samVM.Force = samourai.Force;
            samVM.AddWeapon = false;
            samVM.Disarm = false;
            if (samourai.Arme != null)
            {
                samVM.ArmeId = samourai.Arme.Id;
            }
            if (addWeapon == true)
            {
                samVM.AddWeapon = true;
            }
            if (disarm == true)
            {
                samVM.ArmeId = null;
                samVM.Disarm = true;
            }
            samVM.Armes = db.Armes.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();
            return View(samVM);
        }

        // POST: Samourais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( SamouraisVM samVM)
        {
            if (ModelState.IsValid)
            {
                Samourai samourai = db.Samourais.Include(s => s.Arme).FirstOrDefault(s => s.Id == samVM.Id);
                samourai.Nom = samVM.Nom;
                samourai.Force = samVM.Force;
                if (samVM.ArmeId != null)
                {
                    samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == samVM.ArmeId);
                }
                else
                {
                    samourai.Arme = null;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            samVM.Armes = db.Armes.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();
            return View(samVM);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
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
