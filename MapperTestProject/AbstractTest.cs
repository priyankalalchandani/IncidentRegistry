using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Security.Principal;

namespace MapperTestProject
{
    [TestClass]
    public class AbstractTest<T> where T:class
    {
        protected T Service { get; set; }

        public AbstractTest()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            Service = Bootstrapper.Resolve<T>();    
        }

        protected virtual void Reset()
        {
            Bootstrapper.Reset();
            Initialize();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Thread.CurrentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
        }
    }
}
