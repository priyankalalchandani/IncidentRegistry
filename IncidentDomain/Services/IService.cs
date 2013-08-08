using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentDomain.Services
{
    public interface IService<T>
    {
        T GetIncidentById(int id);
        IEnumerable<T> GetAllIncidents();
        T AddIncident(T model);
        T Create();
    }
}
