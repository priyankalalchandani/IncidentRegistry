using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Mvc3;
using Microsoft.Practices;
using Microsoft.Practices.Unity;
using IncidentDomain.Services;
using IncidentDomain.Repository;
using IncidentInfrastructure.Repositories;

namespace IncidentRegistry
{
    public class Mapper
    {
        public static IUnityContainer Container;

        public static void Initialize()
        {
            Container = MapServiceAndRepo();
        }

        public static IUnityContainer MapServiceAndRepo()
        {
            var container = new UnityContainer();

            container.RegisterType<IRepository<IncidentDomain.Entities.Incident>, IncidentRepository>();
            container.RegisterType<IService<IncidentDomain.Entities.Incident>, IncidentService>();
            return container;
        }
    }
}