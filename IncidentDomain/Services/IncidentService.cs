using IncidentDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentDomain.Services
{
    public class IncidentService<T>:IService<T>
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

        public T insert(T data)
        {
            return repo.insert(data);
        }
    }
}
