using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pizzeriax.Models;

namespace Pizzeriax.Controllers
{
    public class OrdiniController : Controller
    {
        private Model1 db = new Model1();

        // GET: Ordini
        public ActionResult Index()
        {
            var ordini = db.Ordini.Include(o => o.users);
            return View(ordini.ToList());
        }

        // GET: Ordini/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordini ordini = db.Ordini.Find(id);
            if (ordini == null)
            {
                return HttpNotFound();
            }
            return View(ordini);
        }

        // GET: Ordini/Create
        public ActionResult Create()
        {
            ViewBag.IDuser = new SelectList(db.users, "IDuser", "username");
            return View();
        }

        // POST: Ordini/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDordine,DaraOrdine,IDpizza,IDuser,Indirizzo,Nota,IsForLunch,evaso")] Ordini ordini)
        {
            if (ModelState.IsValid)
            {
                db.Ordini.Add(ordini);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDuser = new SelectList(db.users, "IDuser", "username", ordini.IDuser);
            return View(ordini);
        }

        // GET: Ordini/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordini ordini = db.Ordini.Find(id);
            if (ordini == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDuser = new SelectList(db.users, "IDuser", "username", ordini.IDuser);
            return View(ordini);
        }

        // POST: Ordini/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDordine,DaraOrdine,IDpizza,IDuser,Indirizzo,Nota,IsForLunch,evaso")] Ordini ordini)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordini).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDuser = new SelectList(db.users, "IDuser", "username", ordini.IDuser);
            return View(ordini);
        }

        // GET: Ordini/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordini ordini = db.Ordini.Find(id);
            if (ordini == null)
            {
                return HttpNotFound();
            }
            return View(ordini);
        }

        // POST: Ordini/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ordini ordini = db.Ordini.Find(id);
            db.Ordini.Remove(ordini);
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
