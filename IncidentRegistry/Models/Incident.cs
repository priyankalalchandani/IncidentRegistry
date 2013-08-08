using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace IncidentRegistry.Models
{
    public class Incident
    {
        [Key]
        public int IncidentID { get; set; }
        public DateTime Date { get; set; }
        public string IncidentType { get; set; }
        public string Department { get; set; }
        
        public string Description { get; set; }
        public string UploadFile { get; set; }
        public string IncidentLocation { get; set; }
        public string ActionTaken { get; set; }
        public int EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }
     }

    public class IncidentDBContext : DbContext
    {
        public DbSet<Incident> incident { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}