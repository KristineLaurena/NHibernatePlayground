using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernatePlayground.Helpers.Dictionaries
{
    public static class Dictionary
    {
        public static string[] Type = {"Shirt", "Jeans", "Sweater", "Jacket", "Coat", "Blazer", "Pants", "Socks", "Shoes", "Slippers", "Hoodie"};
        public static string[] Size = { "XXS", "XS", "S", "M", "L", "XL", "XXL", "XXXL", "XXXXL"};
        public static string[] Color;

        static Dictionary()
        {
            var colors = Enum.GetNames(typeof(ConsoleColor));
            Color = colors;
        }
    }
}
