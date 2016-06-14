using NHibernatePlayground.Domains;
using NHibernatePlayground.Helpers.NHinnernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernatePlayground.ServiceMock
{
    public static class Service
    {
        public static Product PersistProduct(Product product)
        {
            using (var session = Database.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    session.SaveOrUpdate(product);

                    tran.Commit();

                    return product;
                }
            }          
        }
        
        public static void SearchQueryLinq(string SearchText)
        {
            using (var session = Database.OpenSession())
            {
                var products = session.Query<Product>();

                var result = products.Where(x => x.Skus.Any(z => z.SKU.Contains(SearchText)) || x.Name.Contains(SearchText));
            }
        } 
    }
}
