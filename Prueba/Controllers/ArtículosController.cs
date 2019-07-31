using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prueba.Models;

namespace Prueba.Controllers
{
    public class ArtículosController : Controller
    {
        private MiprimeravezEntities db = new MiprimeravezEntities();

        // GET: Artículos
        public ActionResult Index()
        {
            return View(db.Artículos.ToList());
        }

        // GET: Artículos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artículos artículos = db.Artículos.Find(id);
            if (artículos == null)
            {
                return HttpNotFound();
            }
            return View(artículos);
        }

        // GET: Artículos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artículos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripción,marca,precio,stock")] Artículos artículos)
        {
            if (ModelState.IsValid)
            {
                db.Artículos.Add(artículos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artículos);
        }

        // GET: Artículos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artículos artículos = db.Artículos.Find(id);
            if (artículos == null)
            {
                return HttpNotFound();
            }
            return View(artículos);
        }

        // POST: Artículos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripción,marca,precio,stock")] Artículos artículos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artículos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artículos);
        }

        // GET: Artículos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artículos artículos = db.Artículos.Find(id);
            if (artículos == null)
            {
                return HttpNotFound();
            }
            return View(artículos);
        }

        // POST: Artículos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artículos artículos = db.Artículos.Find(id);
            db.Artículos.Remove(artículos);
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
