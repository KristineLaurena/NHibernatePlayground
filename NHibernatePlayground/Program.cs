using NHibernatePlayground.Domains;
using NHibernatePlayground.Helpers.NHinnernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernatePlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = Database.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    var product = new Product { Name = "kkk" };
                    session.SaveOrUpdate(product);

                    tran.Commit();
                }
            }
        }
    }
}
