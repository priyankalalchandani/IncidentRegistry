using IncidentDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentDomain.Entities;
using IncidentInfrastructure.Repositories;

namespace IncidentDomain.Services
{
    public class IncidentService:AbstractService,IIncidentService
    {
        public IncidentService(IncidentRepository repo)
            
        {
            repo = new IncidentRepository(new IncidentDBContext());
        }
    }
}
