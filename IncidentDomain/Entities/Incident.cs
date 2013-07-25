using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace IncidentRegistry.Models
{
    public class Incident
    {
        public int IncidentID { get; set; }
        public DateTime Date { get; set; }
        public string IncidentType { get; set; }
        public string Department { get; set; }
        
        public string Description { get; set; }
        public string UploadFile { get; set; }
        public string IncidentLocation { get; set; }
        public string ActionTaken { get; set; }
        public int EmployeeID { get; set; }
     }
}