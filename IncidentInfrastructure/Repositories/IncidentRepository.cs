using IncidentDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.ComponentModel;
using IncidentDomain.Entities;

namespace IncidentInfrastructure.Repositories
{
    public class IncidentDBContext : DbContext
    {
        public DbSet<IncidentDomain.Entities.Incident> Incidents { get; set; }
    }

    public class IncidentRepository : AbstractRepository<Incident> , IRepository<Incident>
    {
        public IncidentRepository(IncidentDBContext context)
            : base(context)
        {
           
        }
    }
}
