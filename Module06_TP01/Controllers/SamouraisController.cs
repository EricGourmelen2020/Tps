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
            return View(db.Samourais.Include(s => s.ArtMartials).ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // récupère le samourai correspondant avec son arme et ses arts martiaux maitrisés
            Samourai samourai = db.Samourais.Include(s => s.Arme).Include(s => s.ArtMartials).FirstOrDefault(s => s.Id == id);
            if (samourai == null)
            {
                return HttpNotFound();
            }

            // stock dans le viewbag le potentiel du samouraï
            ViewBag.Potentiel = Getpotentiel(samourai);
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SamouraisVM samVM = new SamouraisVM();

            //stock dans le SamouraiVM la liste des armes disponibles et la liste des arts martiaux
            samVM.Armes = db.Armes.Include(a => a.Samourai).Where(a => a.Samourai == null).Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();
            samVM.ArtMartials = db.ArtMartials.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();
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
                //IEnumerable<Samourai> listSam = db.Samourais.Include(s => s.Arme).Where(s => s.Arme.Id == samVM.ArmeId);
                //foreach (Samourai s in listSam)
                //{
                //    s.Arme = null;
                //}

                // Enregistre le nouveau propriétaire d'une arme si une arme à été seléctionnée
                if (samVM.ArmeId != null)
                {
                    Arme arme = db.Armes.FirstOrDefault(a => a.Id == samVM.ArmeId);
                    arme.Samourai = samourai;
                    samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == samVM.ArmeId);
                }
                //samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == samVM.ArmeId);
                if (samVM.ArtMartialsSelected != null)
                {
                    samourai.ArtMartials = db.ArtMartials.Where(a => samVM.ArtMartialsSelected.Contains(a.Id)).ToList();
                }
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
            Samourai samourai = db.Samourais.Include(s => s.ArtMartials).Include(s => s.Arme).FirstOrDefault( s => s.Id == id);
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

            // permet d'afficher la liste d'armes disponibles si le samourai veut en équiper une
            if (addWeapon == true)
            {
                samVM.AddWeapon = true;
            }

            // permet de déséquiper une arme
            if (disarm == true)
            {
                samVM.ArmeId = null;
                samVM.Disarm = true;
            }

            // construction de la liste d'armes à afficher
            List<Arme> armes = db.Armes.Include(a => a.Samourai).Where(a => a.Samourai == null).ToList();
            if (samourai.Arme != null)
                armes.Add(samourai.Arme);
            if (armes.Count() > 0)
            {
                samVM.Armes = armes.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();
            }
            else
            {
                TempData["NoWeapon"] = "Il n'y a aucune arme disponible";
            }

            samVM.ArtMartials = db.ArtMartials.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();
            samVM.ArtMartialsSelected = samourai.ArtMartials.Select(a => a.Id).ToList();

            return View(samVM);
        }

        // POST: Samourais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraisVM samVM)
        {
            if (ModelState.IsValid)
            {
                Samourai samourai = db.Samourais.Include(s => s.Arme).Include(s => s.ArtMartials).FirstOrDefault(s => s.Id == samVM.Id);
                samourai.Nom = samVM.Nom;
                samourai.Force = samVM.Force;
                if (samVM.ArmeId != null)
                {
                    Arme arme = db.Armes.FirstOrDefault(a => a.Id == samVM.ArmeId);
                    arme.Samourai = samourai;
                    samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == samVM.ArmeId);
                }
                else
                {
                    samourai.Arme = null;
                }
                if (samVM.ArtMartialsSelected != null)
                {
                    samourai.ArtMartials = db.ArtMartials.Where(a => samVM.ArtMartialsSelected.Contains(a.Id)).ToList();
                }
                else
                {
                    samourai.ArtMartials = null;
                }


                db.SaveChanges();
                return RedirectToAction("Index");
            }
            samVM.Armes = db.Armes.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();
            samVM.ArtMartials = db.ArtMartials.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();
            return View(samVM);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Include(s => s.Arme).Include(s => s.ArtMartials).FirstOrDefault(s => s.Id == id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            ViewBag.Potentiel = Getpotentiel(samourai);
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

        // Fonction permettant de calculer le potentiel d'un samouraï
        public int Getpotentiel(Samourai samourai)
        {
            int armeDegat = 0;
            int artMartial = 0;
            if (samourai.Arme != null)
            {
                armeDegat = samourai.Arme.Degats;
            }
            if (samourai.ArtMartials != null)
            {
                artMartial = samourai.ArtMartials.Count();
            }
            return (samourai.Force + armeDegat) * (artMartial + 1);
        }
    }
}
