using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IncidentRegistry.Models;
namespace IncidentRegistry
{
    public class EmployeeRepository:IEmployeeRepository,IDisposable
    {
        IncidentDBContext context;
        public EmployeeRepository(IncidentDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }

        public Employee GetEmployeeByID(int employeeID)
        {
            return context.Employees.Find(employeeID);
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}