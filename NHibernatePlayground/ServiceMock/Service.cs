using NHibernatePlayground.Domains;
using NHibernatePlayground.Helpers.NHinnernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using NHibernate;

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

        public static IEnumerable<Product> SearchQueryLinq(string SearchText)
        {
            using (var session = Database.OpenSession())
            {
                var products = session.Query<Product>();

                var result = products.Where(x => x.Skus.Any(z => z.SKU.Contains(SearchText)) || x.Name.Contains(SearchText));

                return result.ToList();
            }
        }

        public static IEnumerable<Product> SearchArrayQueryLinq(string[] names)
        {
            using (var session = Database.OpenSession())
            {
                var products = session.Query<Product>();

                var result = products.Where(product => names.Any(name => product.Name.Contains(name)));

                return result.ToList();
            }
        }

        [Obsolete("looping through names will create Query with strict \"AND\" clause, which excludes all possible options, there should be used \"OR\" clause")]
        public static IEnumerable<Product> ProudctSkuInLikeLINQ(string[] names)
        {
            using (var session = Database.OpenSession())
            {
                var products = session.Query<Product>();

                foreach (var name in names)
                {
                    products = products.Where(x => x.Skus.Any(sku => sku.SKU.Contains(name)));
                }

                return products.ToList();
            }
        }

        public static IEnumerable<Product> ProductNameInLikeCriteria(string[] names)
        {
            using (var session = Database.OpenSession())
            {
                var products = session.CreateCriteria<Product>();

                if (names == null)
                {
                    return products.List<Product>();
                }

                var orClause = Expression.Disjunction();

                foreach (var name in names)
                {
                    orClause.Add(Expression.Like(nameof(Product.Name), name, MatchMode.Anywhere));
                }

                products.Add(orClause);

                return products.List<Product>();
            }
        }

        public static IEnumerable<Product> ProductSkuInLikeCriteria(string[] names)
        {
            using (var session = Database.OpenSession())
            {
                var products = session.CreateCriteria<Product>();

                var orClause = Expression.Disjunction();

                foreach (var name in names)
                {
                    //orClause.Add<ProductSku>(x => x.SKU.Contains(name));
                    orClause.Add(Expression.Like("skus.SKU", name, MatchMode.Anywhere));
                }

                products
                    .CreateAlias(nameof(Product.Skus), "skus")
                        .Add(orClause)
                    .SetFetchMode(nameof(Product.Skus), FetchMode.Lazy); // not excluded
                    

                return products.List<Product>();
            }
        }
    }
}
