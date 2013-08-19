using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IncidentDomain;

namespace IncidentInfrastructure
{
    public class DbContextBase<T> : DbContext, ICommit
    {
        public DbSet<IncidentDomain.Entities.Incident> Incident { get; set; }
                
        public DbContextBase()
            : base("IncidentDatabase")
        {
        }

        public void Commit()
        {
            this.SaveChanges();
        }
    }
}
