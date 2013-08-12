using IncidentDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidentDomain.Entities;
using System.Web;
using System.IO;

namespace IncidentDomain.Services
{
    public class IncidentService:AbstractService<IncidentDomain.Entities.Incident>,IIncidentService
    {
        private IIncidentRepository Repository;
        public IncidentService(IIncidentRepository repo)
            :base(repo)
        {
            this.Repository = repo;

        }

        public void UploadFile(ref Incident incident)
        {
            string filename = "";
            foreach (string upload in HttpContext.Current.Request.Files)
            {
                filename = Path.GetFileName(HttpContext.Current.Request.Files[upload].FileName);
                string path = HttpContext.Current.Server.MapPath("~/");
                HttpContext.Current.Request.Files[upload].SaveAs(Path.Combine(path, filename));
                incident.UploadFile = filename;
            }
            //return filename;
        }
    }
}
