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
    public class VehículoController : Controller
    {
        private MiprimeravezEntities db = new MiprimeravezEntities();

        // GET: Vehículo
        public ActionResult Index()
        {
            return View(db.Vehículo.ToList());
        }

        // GET: Vehículo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehículo vehículo = db.Vehículo.Find(id);
            if (vehículo == null)
            {
                return HttpNotFound();
            }
            return View(vehículo);
        }

        // GET: Vehículo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehículo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,modelo,marca")] Vehículo vehículo)
        {
            if (ModelState.IsValid)
            {
                db.Vehículo.Add(vehículo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehículo);
        }

        // GET: Vehículo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehículo vehículo = db.Vehículo.Find(id);
            if (vehículo == null)
            {
                return HttpNotFound();
            }
            return View(vehículo);
        }

        // POST: Vehículo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,modelo,marca")] Vehículo vehículo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehículo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehículo);
        }

        // GET: Vehículo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehículo vehículo = db.Vehículo.Find(id);
            if (vehículo == null)
            {
                return HttpNotFound();
            }
            return View(vehículo);
        }

        // POST: Vehículo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehículo vehículo = db.Vehículo.Find(id);
            db.Vehículo.Remove(vehículo);
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
