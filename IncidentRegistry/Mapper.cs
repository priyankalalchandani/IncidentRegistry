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
using IncidentDomain.Entities;
using System.Data.Entity;
using IncidentDomain;

namespace IncidentRegistry
{
    public class Mapper
    {
        public static void Initialize()
        {

            var container = MapServiceAndRepo();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public static IUnityContainer MapServiceAndRepo()
        {
            var container = new UnityContainer();

            container.RegisterType<IIncidentRepository, IncidentRepository>();
            container.RegisterType<IIncidentService, IncidentService>();

            container.RegisterType<IncidentInfrastructure.IncidentDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<DbContext, IncidentInfrastructure.IncidentDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommit, IncidentInfrastructure.IncidentDbContext>();
            return container;
        }
    }
}