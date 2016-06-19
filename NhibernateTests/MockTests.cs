using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernatePlayground.Helpers.Generators;
using NHibernatePlayground.ServiceMock;
using System.Collections.Generic;
using System.Diagnostics;

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

        [TestMethod]
        public void FindSomethingArayLinq()
        {
            var result = Service.SearchArrayQueryLinq(new string[] { "red", "black" });
        }

        [TestMethod]
        public void ProudctSkuInLikeLINQ()
        {
            var result = Service.ProudctSkuInLikeLINQ(new string[] { "red", "black" });
        }

        [TestMethod]
        public void ProudctNameInLikeCriteria()
        {
            var result = Service.ProductNameInLikeCriteria(new[] { "red", "black" });
        }

        [TestMethod]
        public void ProudctSkuInLikeCriteria()
        {
            var result = Service.ProductSkuInLikeCriteria(new string[] { "red", "black" });

            foreach (var product in result)
            {
                Debug.WriteLine(product.Name);
            }
            
        }
    }
}
