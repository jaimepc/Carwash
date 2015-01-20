using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carwash.Models;

namespace Carwash.Controllers
{
    public class PersonaController : Controller
    {
        private CarwashEntities db = new CarwashEntities();

        //
        // GET: /Persona/

        public ActionResult Index()
        {
            return View(db.Persona.ToList());
        }

        //
        // GET: /Persona/Details/5

        public ActionResult Details(int id = 0)
        {
            Persona persona = db.Persona.Single(p => p.Persona_id == id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        //
        // GET: /Persona/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Persona/Create

        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Persona.AddObject(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(persona);
        }

        //
        // GET: /Persona/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Persona persona = db.Persona.Single(p => p.Persona_id == id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        //
        // POST: /Persona/Edit/5

        [HttpPost]
        public ActionResult Edit(Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Persona.Attach(persona);
                db.ObjectStateManager.ChangeObjectState(persona, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        //
        // GET: /Persona/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Persona persona = db.Persona.Single(p => p.Persona_id == id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        //
        // POST: /Persona/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Persona.Single(p => p.Persona_id == id);
            db.Persona.DeleteObject(persona);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}