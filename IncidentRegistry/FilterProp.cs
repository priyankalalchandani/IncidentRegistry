using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Omu.ValueInjecter;

namespace IncidentRegistry
{
    public class FilterProp : LoopValueInjection
    {
        protected override bool UseSourceProp(string sourcePropName)
        {
            return sourcePropName != "IncidentName" && sourcePropName != "Description";
        }
    }
}