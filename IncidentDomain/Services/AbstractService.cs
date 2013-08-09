using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentDomain.Repository;

namespace IncidentDomain.Services
{
    public class AbstractService<T> : IService<T> where T: new()
    {
        private IRepository<T> repo;

        public AbstractService(IRepository<T> repo)
        {
            this.repo = repo;
        }

        public T GetIncidentById(int id)
        {
            return repo.Get(id);
        }

        public IEnumerable<T> GetAllIncidents()
        {
            return repo.GetAll();
        }

        public T AddIncident(T model)
        {
            repo.Insert(model);
            return model;
        }

        public T Create()
        {
            return new T();
        }

        public int DeleteIncident(int id)
        {
            repo.Delete(id);
            return id;
        }
        public T UpdateIncident(T data)
        {
            repo.Update(data);
            return data;
        }
    }
}
