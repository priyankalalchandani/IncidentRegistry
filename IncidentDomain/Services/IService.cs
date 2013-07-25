using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentDomain.Services
{
    public interface IService<T>
    {
        T get(int id);
        IEnumerable<T> getAll();

        T insert(T data);
    }
}
