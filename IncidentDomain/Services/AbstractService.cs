using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentDomain.Repository;
using IncidentInfrastructure.Repositories;

namespace IncidentDomain.Services
{
    public class AbstractService : IService<IncidentDomain.Entities.Incident>
    {
        private IncidentRepository repo;

        public AbstractService()
        {
            this.repo = new IncidentRepository(new IncidentDBContext());
        }

        public IncidentDomain.Entities.Incident GetIncidentById(int id)
        {
            return repo.Get(id);
        }

        public IEnumerable<IncidentDomain.Entities.Incident> GetAllIncidents()
        {
            return repo.GetAll();
        }

        public IncidentDomain.Entities.Incident AddIncident(IncidentDomain.Entities.Incident model)
        {
            repo.Insert(model);
            return model;
        }

        public IncidentDomain.Entities.Incident Create()
        {
            return new IncidentDomain.Entities.Incident();
        }
    }
}
