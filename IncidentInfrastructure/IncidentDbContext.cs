using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IncidentInfrastructure
{
    public class IncidentDbContext : DbContextBase<IncidentDomain.Entities.Incident>
    {
        
        public void InitializeDatabase()
        {
            try
            {
                Database.Delete();
                Database.Initialize(true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
