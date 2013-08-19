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
        ICommit commitdata;

        public AbstractService(IRepository<T> repo,ICommit commitdata)
        {
            this.repo = repo;
            this.commitdata = commitdata;
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
            commitdata.Commit();
            return model;
        }

        public T Create()
        {
            return new T();
        }

        public int DeleteIncident(int id)
        {
            repo.Delete(id);
            commitdata.Commit();
            return id;
        }
        public T UpdateIncident(T data)
        {
            repo.Update(data);
            commitdata.Commit();
            return data;
        }
    }
}
