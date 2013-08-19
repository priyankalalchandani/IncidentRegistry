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
    public class IncidentRepository : AbstractRepository<Incident> ,IIncidentRepository
    {
        public IncidentRepository(DbContext context)
            : base(context)
        {
           
        }
    }
}
