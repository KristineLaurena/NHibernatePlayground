using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernatePlayground.Domains
{
    public class Product : DomainBase
    {
        public virtual string Name { get; set; }

        public virtual ICollection<ProductSku> Skus { get; set; }

        public Product()
        {
            if (this.Skus == null)
            {
                this.Skus = new List<ProductSku>();
            }
        }
    }
}
