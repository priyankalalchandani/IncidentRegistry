using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentRegistry.Models;

namespace IncidentRegistry
{
    interface IEmployeeRepository:IDisposable
    {
        Employee GetEmployeeByID(int employeeId);
        IEnumerable<Employee> GetEmployees();
    }
}
