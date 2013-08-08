using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IncidentRegistry.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public long EmployeePhone { get; set; }
        public string EmployeeEmail { get; set; }
        public string Designation { get; set; }
        public string Depatment { get; set; }

        public virtual ICollection<Incident> incident { get; set; }
    }
}