using IncidentDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.ComponentModel;

namespace IncidentInfrastructure.Repositories
{
    public class IncidentRepository<T> : IRepository<T> where T:IncidentDomain.Entities.Incident
    {
        protected DbContext Context { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public IncidentRepository()
        {
            this.DbSet = Context.Set<T>();
        }

        public  T get(int id)
        {
            return (T)DbSet.Find(id);
        }

        public IEnumerable<T> getAll()
        {
            return DbSet.ToList();
        }
    }
}
