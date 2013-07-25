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
    public class IncidentRepository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        protected DbContext Context { get; set; }
        protected DbSet<TEntity> DbSet { get; set; }

        public IncidentRepository()
        {
            this.DbSet = Context.Set<TEntity>();
        }

        public TEntity get(int id)
        {
            return (TEntity)DbSet.Find(id);
        }

        public IEnumerable<TEntity> getAll()
        {

        }
    }
}
