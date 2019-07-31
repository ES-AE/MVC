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
    public class ClientesPasivosController : Controller
    {
        private MiprimeravezEntities db = new MiprimeravezEntities();

        // GET: ClientesPasivos
        public ActionResult Index()
        {
            return View(db.ClientesPasivos.ToList());
        }

        // GET: ClientesPasivos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientesPasivos clientesPasivos = db.ClientesPasivos.Find(id);
            if (clientesPasivos == null)
            {
                return HttpNotFound();
            }
            return View(clientesPasivos);
        }

        // GET: ClientesPasivos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesPasivos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre,Dirección,CUI,fecha,Saldo,Teléfono")] ClientesPasivos clientesPasivos)
        {
            if (ModelState.IsValid)
            {
                db.ClientesPasivos.Add(clientesPasivos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientesPasivos);
        }

        // GET: ClientesPasivos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientesPasivos clientesPasivos = db.ClientesPasivos.Find(id);
            if (clientesPasivos == null)
            {
                return HttpNotFound();
            }
            return View(clientesPasivos);
        }

        // POST: ClientesPasivos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre,Dirección,CUI,fecha,Saldo,Teléfono")] ClientesPasivos clientesPasivos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientesPasivos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientesPasivos);
        }

        // GET: ClientesPasivos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientesPasivos clientesPasivos = db.ClientesPasivos.Find(id);
            if (clientesPasivos == null)
            {
                return HttpNotFound();
            }
            return View(clientesPasivos);
        }

        // POST: ClientesPasivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientesPasivos clientesPasivos = db.ClientesPasivos.Find(id);
            db.ClientesPasivos.Remove(clientesPasivos);
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
