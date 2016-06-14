using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Data;
using FluentNHibernate.Cfg.Db;
using NHibernatePlayground.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace NHibernatePlayground.Helpers.NHinnernate
{
    public static class Database
    {
        private static NHibernate.ISessionFactory _factory = null;

        static Database()
        {
            _factory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(x => x.FromConnectionStringWithKey("Hibernate")))
                .Mappings(m =>
                     m.FluentMappings
                        .AddFromAssemblyOf<ProductSku>())
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return _factory.OpenSession();
        }
    }
}
