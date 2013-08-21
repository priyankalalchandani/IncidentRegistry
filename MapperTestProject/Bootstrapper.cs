using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using IncidentDomain.Services;
using Microsoft.Practices.ServiceLocation;
using IncidentInfrastructure.Repositories;
using IncidentDomain.Repository;
using IncidentRegistry;
using System.Data.Entity;
using IncidentDomain;

namespace MapperTestProject
{
    public static class Bootstrapper
    {
        private static IUnityContainer Container { get; set; }

        static Bootstrapper()
        {
            Initialize();
        }

        private static void Initialize()
        {
            Container = BuildUnityContainer();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(Container));
        }

        public static void Reset()
        {
            if (Container != null)
            {
                Container.Dispose();
            }

            Initialize();
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IIncidentService, IncidentService>();
            container.RegisterType<IIncidentRepository, IncidentRepository>();

            container.RegisterType<IncidentInfrastructure.IncidentDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<DbContext, IncidentInfrastructure.IncidentDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommit, IncidentInfrastructure.IncidentDbContext>();

            return container;
        }
    }
}
