using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernatePlayground.Helpers.Generators;
using NHibernatePlayground.ServiceMock;

namespace NhibernateTests
{
    [TestClass]
    public class MockTests
    {
        [TestMethod]
        public void Add500ProductsWithSKU()
        {
            for (int i = 0; i < 500; i++)
            {
                var product = Generator.ProudctWithSKU(20);

                Service.PersistProduct(product);
            }
        }

        [TestMethod]
        public void FindSomethingLinq()
        {
            Service.SearchQueryLinq("red");
        }
    }
}
