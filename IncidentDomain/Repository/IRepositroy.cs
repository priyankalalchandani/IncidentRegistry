using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentDomain.Repository
{
    public interface IRepository<T>
    {
        T Delete(int id);
        T Update(T data);
        T Get(int id);
        IEnumerable<T> GetAll();
        T Insert(T data);
    }
}
