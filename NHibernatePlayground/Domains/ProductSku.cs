using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernatePlayground.Domains
{
    public class ProductSku : DomainBase
    {
        public virtual string SKU { get; set; }
        public virtual bool IsDefault { get; set; }
        public virtual Product Product { get; set; }

        public ProductSku()
        {
            this.IsDefault = false;
        }
    }
}
