using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentRegistry.Models;

namespace IncidentRegistry
{
    public class IIncidentRepository:IDisposable
    {
        IEnumerable<Incident> GetIncidents();
        Incident GetIncidentByID(int incidentId);
        void InsertIncident(Incident incident);
    }
}