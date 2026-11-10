#if false
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqMethodApp
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }

    class Program
    {
        /*
        static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product { Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 15 },
                new Product { Name = "Mouse", Category = "Electronics", Price = 25, Stock = 100 },
                new Product { Name = "Desk", Category = "Furniture", Price = 350, Stock = 10 }
            };

            var cheap = products.Where(p => p.Price < 100);
            Console.WriteLine("Cheap products:");
            foreach (var p in cheap) Console.WriteLine($"  {p.Name}: ${p.Price}");

            var names = products.OrderBy(p => p.Price).Select(p => p.Name);
            Console.WriteLine("Products sorted by price: " + string.Join(", ", names));

            var grouped = products.GroupBy(p => p.Category);
            foreach (var g in grouped)
                Console.WriteLine($"{g.Key}: {g.Count()} products, avg ${g.Average(p => p.Price):F2}");
        }
        */
    }
}

#endif

