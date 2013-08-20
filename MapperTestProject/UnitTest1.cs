using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IncidentDomain.Entities;
using IncidentRegistry.Models.Incident;
using IncidentRegistry.Controllers;
using System.Web.Mvc;
using IncidentDomain.Services;

namespace MapperTestProject
{
    [TestClass]
    public class UnitTest1 : AbstractTest<IIncidentService>
    {
        //IncidentDomain.Services.IIncidentService service;
        [TestMethod]
        public void TestMethod1()
        {
            IncidentViewModel model = new IncidentViewModel()
            {
                IncidentID=29,
                IncidentName = "newinc",
                IncidentLocation = "Makarpura",
                IncidentType="Incapacity"
            };
            IncidentController controller = new IncidentController(Service);
            
            controller.CreateIncident(model);
            Incident expected = Service.GetIncidentById(model.IncidentID);
            Assert.AreEqual<String>(expected.IncidentLocation, model.IncidentLocation);
            //ViewResult viewresult = actionresult as ViewResult;
        }
    }
}
