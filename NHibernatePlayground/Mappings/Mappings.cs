using FluentNHibernate.Mapping;
using NHibernatePlayground.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernatePlayground.Mappings
{
    public class ProductMapping : ClassMap<Product>
    {
        public ProductMapping()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            HasMany(x => x.Skus)
                .KeyColumn("ProductId")
                //.ExtraLazyLoad()
                .Inverse()
                .Cascade.SaveUpdate();            
        }
    }

    public class ProductSkusMapping : ClassMap<ProductSku>
    {
        public ProductSkusMapping()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.SKU);
            References(x => x.Product).Column("ProductId");
            Map(x => x.IsDefault);
        }
    }
}
