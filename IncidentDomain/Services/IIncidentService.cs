﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentDomain.Services
{
    public interface IIncidentService : IService<IncidentDomain.Entities.Incident>
    {
        void UploadFile(ref IncidentDomain.Entities.Incident incident);
    }
}
