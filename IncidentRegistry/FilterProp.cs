using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Omu.ValueInjecter;

namespace IncidentRegistry
{
    public class FilterProp : LoopValueInjection
    {
        int i;
        protected override bool UseSourceProp(string sourcePropName)
        {
            i = 1;

            if (i == 1)
                return sourcePropName != "IncidentName" && sourcePropName != "Description";
            else
                return sourcePropName != "IncidentLocation";
        }
    }
}