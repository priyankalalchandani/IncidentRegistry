using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentDomain.Repository
{
    public interface IRepository<T>
    {
        T get(int id);
        IEnumerable<T> getAll();

        T insert(T data);
    }
}
