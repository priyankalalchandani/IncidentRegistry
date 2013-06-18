using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentRegistry.Models;

namespace IncidentRegistry
{
    public interface IIncidentRepository:IDisposable
    {
        IEnumerable<Incident> GetIncidents();
        Incident GetIncidentByID(int incidentId);
        void InsertIncident(Incident incident);
        void Save();
    }
}
