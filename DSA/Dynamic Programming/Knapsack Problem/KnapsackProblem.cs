namespace Knapsack_Problem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KnapsackProblem
    {
        private static HashSet<Product> results;
        private static Product[] products;
        private static int n;
        private static int m;

        public static void FindSolution()
        {
            for (int i = 0; i < n; i++)
            {
                HashSet<Product> set = new HashSet<Product>(results);
                foreach (var prod in set)
                {
                    Product product;
                    if (prod.Name == string.Empty)
                    {
                        product = new Product(products[i].Name, products[i].Weight, products[i].Cost);
                    }
                    else
                    {
                        product = new Product(
                            prod.Name + "+" + products[i].Name,
                            prod.Weight + products[i].Weight,
                            prod.Cost + products[i].Cost);
                    }

                    if (product.Weight > m)
                    {
                        continue;
                    }

                    if (!results.Contains(product))
                    {
                        results.Add(product);
                    }
                }
            }
        }

        public static Product[] PopulateWithTestProducts()
        {
            Random rnd = new Random();
            Product[] array = new Product[500];
            for (int i = 0; i < 500; i++)
            {
                array[i] = new Product("Product" + i, rnd.Next(500), rnd.Next(500));
            }

            return array;
        }

        public static void Main(string[] args)
        {
            m = 10;
            results = new HashSet<Product>();
            results.Add(new Product(string.Empty, 0, 0));

            // products = new Product[] { 
            //     new Product("beer", 3, 2), 
            //     new Product("vodka", 8, 12), 
            //     new Product("cheese", 4, 5), 
            //     new Product("nuts", 1, 4), 
            //     new Product("ham", 2, 3), 
            //     new Product("whiskey", 8, 13) };

            // n = products.Length;
            // FindSolution();
            // Product optimum = results.OrderBy(x => -x.Cost).First();
            // Console.WriteLine(optimum);
            products = PopulateWithTestProducts();
            n = products.Length;
            FindSolution();
            Product optimum = results.OrderBy(x => -x.Cost).First();
            Console.WriteLine(optimum);
        }
    }
}
