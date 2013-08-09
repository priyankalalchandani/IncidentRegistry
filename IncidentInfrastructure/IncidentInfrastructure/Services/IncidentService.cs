using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentDomain.Repository;
using IncidentDomain.Services;

namespace IncidentInfrastructure.Services
{
    public class IncidentService<T> : IService<T> where T: IncidentDomain.Entities.Incident
    {
        private IRepository<T> repo;

        public IncidentService(IRepository<T> repo)
        {
            this.repo = repo;
        }

        public T get(int id)
        {
            return repo.get(id);
        }

        public IEnumerable<T> getAll()
        {
            return repo.getAll();
        }
    }
}
