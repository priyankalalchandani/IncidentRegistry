using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentRegistry.Models;

namespace IncidentRegistry
{
    public class IncidentRepository:IIncidentRepository,IDisposable
    {
        private IncidentDBContext context;

        public IncidentRepository(IncidentDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Incident> GetIncidents()
        {
            return context.incident.ToList();
        }

        public Incident GetIncidentByID(int incidentID)
        {
            return context.incident.Find(incidentID);
        }

        public void InsertIncident(Incident incident)
        {
            context.incident.Add(incident);
        }
    }
}