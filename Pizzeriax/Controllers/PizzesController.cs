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
    [Authorize(Users = "admin")]
    public class PizzesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Pizzes
        public ActionResult Index()
        {
            return View(db.Pizze.ToList());
        }
        [AllowAnonymous]
        public ActionResult Menu()
        {
            return View(db.Pizze.ToList());
        }

        // GET: Pizzes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizze pizze = db.Pizze.Find(id);
            if (pizze == null)
            {
                return HttpNotFound();
            }
            return View(pizze);
        }

        // GET: Pizzes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pizzes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDpizza,NomePizza,imgURL,prezzo,Cottura,Ingredienti")] Pizze pizze, HttpPostedFileBase uploadfile)
        {
            if (ModelState.IsValid)
            {
                string filename = uploadfile.FileName;
                string path = Server.MapPath("/content/img/" + filename);
                uploadfile.SaveAs(path);
                pizze.imgURL = filename;
                db.Pizze.Add(pizze);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pizze);
        }

        // GET: Pizzes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizze pizze = db.Pizze.Find(id);
            if (pizze == null)
            {
                return HttpNotFound();
            }
            return View(pizze);
        }

        // POST: Pizzes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDpizza,NomePizza,imgURL,prezzo,Cottura,Ingredienti")] Pizze pizze)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pizze).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pizze);
        }

        // GET: Pizzes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizze pizze = db.Pizze.Find(id);
            if (pizze == null)
            {
                return HttpNotFound();
            }
            return View(pizze);
        }

        // POST: Pizzes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pizze pizze = db.Pizze.Find(id);
            db.Pizze.Remove(pizze);
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
