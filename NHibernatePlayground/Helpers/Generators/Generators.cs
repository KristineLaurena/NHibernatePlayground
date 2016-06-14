using NHibernatePlayground.Domains;
using NHibernatePlayground.Helpers.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernatePlayground.Helpers.Generators
{
    public static class Generator
    {
        private static Random _rnd;

        static Generator()
        {
            _rnd = new Random();
        }

        public static string ProductName()
        {
            var color = _rnd.Next(0, Dictionary.Color.Length - 1);
            var size = _rnd.Next(0, Dictionary.Size.Length - 1);
            var type = _rnd.Next(0, Dictionary.Type.Length - 1);

            var a = Dictionary.Color[color];
            var b = Dictionary.Type[type];
            var c = Dictionary.Size[size];

            return $"{ Dictionary.Color[color] } { Dictionary.Type[type] } { Dictionary.Size[size] }";
        }

        public static string SKU()
        {
            var color = _rnd.Next(0, Dictionary.Color.Length - 1);
            var size = _rnd.Next(0, Dictionary.Size.Length - 1);
            var type = _rnd.Next(0, Dictionary.Type.Length - 1);

            return $"{ Dictionary.Color[color].Substring(0,3) }-{ Dictionary.Type[type].Substring(0,3) }-{ Dictionary.Size[size] }";
        }

        public static Product ProudctWithSKU(UInt32 skuCount)
        {
            var product = new Product();
            product.Name = Generator.ProductName();

            for (int i = 0; i < skuCount; i++)
            {
                product.Skus.Add(new ProductSku
                {
                    Product = product,
                    SKU = Generator.SKU()
                });
            }

            var defaultSKU = _rnd.Next(0, (int)skuCount - 1);

            // mark as default SKU
            product.Skus.ElementAt(defaultSKU).IsDefault = true;

            return product;
        }


    } 
}
