using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using IncidentDomain.Services;
using IncidentInfrastructure.Repositories;

namespace IncidentRegistry.Controllers
{
    public class IncidentController : Controller
    {
        //private IncidentDBContext db = new IncidentDBContext();
        private IIncidentService incidentService;
        private IncidentRepository incidentRepo;

        int i = 100;

        public IncidentController()
        {
            this.incidentService = new IncidentService(incidentRepo);
        }

        //
        // GET: /Incident/

        public ActionResult Index()
        {

            return View(incidentService.GetAllIncidents());
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

            return View(incidentService.GetIncidentById(id));
        }

        /*public ActionResult EmployeeDetails(int id = 0)
        {
            Employee emp = incidentRepository.GetEmployeeByID(id);
            return View(emp);
          
        }*/


        //
        // GET: /Incident/Create

        public ActionResult Create()
        {
            //ViewBag.EmployeeID = new SelectList(employeeRepository.GetEmployees(), "EmployeeID", "EmployeeID");
            return View();
        }

        //
        // POST: /Incident/Create

        [HttpPost]
        public ActionResult Create(IncidentDomain.Entities.Incident incident)
        {
            string filename = "";
            foreach (string upload in Request.Files)
            {
                filename = Path.GetFileName(Request.Files[upload].FileName);
                string path = Server.MapPath("~/");
                Request.Files[upload].SaveAs(Path.Combine(path, filename));
                
            }
                
            if (ModelState.IsValid)
            {
                incidentService.AddIncident(incident).UploadFile=filename;
                return RedirectToAction("Index");
            }

            //ViewBag.EmployeeID = new SelectList(employeeRepository.GetEmployees(), "EmployeeID", "EmployeeID", incident.EmployeeID);
            return RedirectToAction("Index");
        }

        public ActionResult Download(String filename)
        {
            if(filename!=null)
                return File("~/" + filename, System.Net.Mime.MediaTypeNames.Application.Octet,filename);

            return View("Index");
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
            //incidentRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}