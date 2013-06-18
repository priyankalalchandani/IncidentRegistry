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
        //private IncidentDBContext db = new IncidentDBContext();
        private IIncidentRepository incidentRepository;
        private IEmployeeRepository employeeRepository;

        int i = 100;

        public IncidentController()
        {
            this.incidentRepository = new IncidentRepository(new IncidentDBContext());
            this.employeeRepository = new EmployeeRepository(new IncidentDBContext());
        }

        public IncidentController(IIncidentRepository incidentRepository)
        {
            this.incidentRepository = incidentRepository;
            
        }

        
        //
        // GET: /Incident/

        public ActionResult Index()
        {
            /*var incident = db.incident.Include(i => i.Employee);
            return View(incident.ToList());*/

            return View(incidentRepository.GetIncidents());
        }

        //
        // GET: /Incident/Details/5

        public ActionResult Details(int id = 0)
        {
            /*Incident incident = db.incident.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);*/

            Incident incident = incidentRepository.GetIncidentByID(id);
            return View(incident);
        }

        public ActionResult EmployeeDetails(int id = 0)
        {
            Employee emp = incidentRepository.GetEmployeeByID(id);
            return View(emp);
          
        }


        //
        // GET: /Incident/Create

        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(employeeRepository.GetEmployees(), "EmployeeID", "EmployeeID");
            return View();
        }

        //
        // POST: /Incident/Create

        [HttpPost]
        public ActionResult Create(Incident incident)
        {
            if (ModelState.IsValid)
            {
                incidentRepository.InsertIncident(incident);
                incidentRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(employeeRepository.GetEmployees(), "EmployeeID", "EmployeeID", incident.EmployeeID);
            return View(incident);
        }

        //
        // GET: /Incident/Edit/5

        /*public ActionResult Edit(int id = 0)
        {
            Incident incident = db.incident.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeName", incident.EmployeeID);
            return View(incident);
        }*/

        //
        // POST: /Incident/Edit/5

        /*[HttpPost]
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
        }*/

        //
        // GET: /Incident/Delete/5

        /*public ActionResult Delete(int id = 0)
        {
            Incident incident = db.incident.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }*/

        //
        // POST: /Incident/Delete/5

        /*[HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Incident incident = db.incident.Find(id);
            db.incident.Remove(incident);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

        protected override void Dispose(bool disposing)
        {
            incidentRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}