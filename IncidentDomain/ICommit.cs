﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentDomain
{
    public interface ICommit : IDisposable
    {
        void Commit();
    }
}

