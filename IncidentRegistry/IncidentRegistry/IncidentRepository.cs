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

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}