using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IncidentRegistry.Models;

namespace IncidentRegistry.Controllers
{
    public class IncidentController : Controller
    {
        private IncidentDBContext db = new IncidentDBContext();
        int i = 100;
        //
        // GET: /Incident/

        public ActionResult Index()
        {
            var incident = db.incident.Include(i => i.Employee);
            return View(incident.ToList());
        }

        //
        // GET: /Incident/Details/5

        public ActionResult Details(int id = 0)
        {
            Incident incident = db.incident.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        public ActionResult EmployeeDetails(int id = 0)
        {
            Employee emp = db.Employees.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }


        //
        // GET: /Incident/Create

        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName");
            return View();
        }

        //
        // POST: /Incident/Create

        [HttpPost]
        public ActionResult Create(Incident incident)
        {
            if (ModelState.IsValid)
            {
                incident.IncidentID = i++;
                db.incident.Add(incident);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", incident.EmployeeID);
            return View(incident);
        }

        //
        // GET: /Incident/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Incident incident = db.incident.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", incident.EmployeeID);
            return View(incident);
        }

        //
        // POST: /Incident/Edit/5

        [HttpPost]
        public ActionResult Edit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incident).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", incident.EmployeeID);
            return View(incident);
        }

        //
        // GET: /Incident/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Incident incident = db.incident.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        //
        // POST: /Incident/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Incident incident = db.incident.Find(id);
            db.incident.Remove(incident);
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