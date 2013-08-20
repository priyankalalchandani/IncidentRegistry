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
using Omu.ValueInjecter;

namespace IncidentRegistry.Controllers
{
    public class IncidentController : Controller
    {
        private IIncidentService incidentService;


        public IncidentController(IIncidentService incidentService)
        {
            this.incidentService = incidentService;
        }

        public ActionResult Index()
        {

            return View(incidentService.GetAllIncidents());
        }


        public ActionResult Details(int id = 0)
        {
            return View(incidentService.GetIncidentById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateIncident(Models.Incident.IncidentViewModel incident)
        {
            MapperClass mapper=new MapperClass();
            if (ModelState.IsValid)
            {
                //IncidentDomain.Entities.Incident incidententity= mapper.MapValues(incident);
                var incidententity = new IncidentDomain.Entities.Incident();
                incidententity.InjectFrom<FilterProp>(incident);
                //incidentService.UploadFile(ref incidententity);
                incidentService.AddIncident(incidententity);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Download(String filename)
        {
            if(filename!=null)
                return File("~/" + filename, System.Net.Mime.MediaTypeNames.Application.Octet,filename);

            return View("Index");
        }

        public ActionResult Edit(int id = 0)
        {
            return View(incidentService.GetIncidentById(id));
        }

        [HttpPost,ActionName("Edit")]
        public ActionResult EditData(IncidentDomain.Entities.Incident incident)
        {
            
            incidentService.UpdateIncident(incident);


            return RedirectToAction("Index");
        }

       
        public ActionResult Delete(int id = 0)
        {
            return View(incidentService.GetIncidentById(id));
        }

        

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            incidentService.DeleteIncident(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            
            base.Dispose(disposing);
        }
    }
}