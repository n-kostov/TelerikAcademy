using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Supermarket
{
    class Program
    {

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            ShoppingCenter center = new ShoppingCenter();

            StringBuilder answer = new StringBuilder();

            do
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string commandResult = center.ProcessCommand(command);
                answer.AppendLine(commandResult);
            }
            while (true);

            Console.Write(answer);
        }


        public class Product : IComparable<Product>
        {
            private string name;
            private decimal price;
            private string producer;

            public Product(string name, string price, string producer)
            {
                this.name = name;
                this.price = decimal.Parse(price);
                this.producer = producer;
            }

            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }

            public decimal Price
            {
                get
                {
                    return price;
                }
                set
                {
                    price = value;
                }
            }

            public string Producer
            {
                get
                {
                    return producer;
                }
                set
                {
                    producer = value;
                }
            }

            public string GetNameAndProducerKey()
            {
                string key = name + ";" + producer;
                return key;
            }

            public int CompareTo(Product other)
            {
                int resultOfCompare = name.CompareTo(other.name);
                if (resultOfCompare == 0)
                {
                    resultOfCompare = producer.CompareTo(other.producer);
                }
                if (resultOfCompare == 0)
                {
                    resultOfCompare = price.CompareTo(other.price);
                }
                return resultOfCompare;
            }

            public override string ToString()
            {
                string toString = "{" + name + ";" + producer + ";" + price.ToString("0.00") + "}";
                return toString;
            }

        }

        public class ShoppingCenter
        {
            private const string PRODUCT_ADDED = "OK";
            private const string INCORRECT_COMMAND = "Error";

            //private readonly MultiDictionary<string, Product> productsByName;
            //private readonly MultiDictionary<string, Product> nameAndProducer;
            //private readonly OrderedMultiDictionary<decimal, Product> productsByPrice;
            //private readonly MultiDictionary<string, Product> productsByProducer;

            private readonly BigList<string> queue;
            private readonly Bag<string> productByName;

            public ShoppingCenter()
            {
                //productsByName = new MultiDictionary<string, Product>(true);
                //nameAndProducer = new MultiDictionary<string, Product>(true);
                //productsByPrice = new OrderedMultiDictionary<decimal, Product>(true);
                //productsByProducer = new MultiDictionary<string, Product>(true);

                queue = new BigList<string>();
                productByName = new Bag<string>();
            }

            private string AppendPerson(string name)
            {
                queue.Add(name);
                productByName.Add(name);
                return PRODUCT_ADDED;
            }

            private string InsertPerson(int position, string name)
            {
                if (position < 0 || position > queue.Count)
                {
                    return INCORRECT_COMMAND;
                }

                queue.Insert(position, name);
                productByName.Add(name);
                return PRODUCT_ADDED;
            }

            private int FindProductsByName(string name)
            {
                if (!productByName.Contains(name))
                {
                    return 0;
                }
                else
                {
                    return productByName.Where(x => x == name).Count();
                    //return productByName.FindAll(x => x == name).Count();
                }
            }

            private string Serve(int count)
            {
                if (count > queue.Count)
                {
                    return INCORRECT_COMMAND;
                }

                var elements = queue.Range(0, count);
                string result = string.Join(" ", elements);
                productByName.RemoveMany(elements);
                queue.RemoveRange(0, count);

                return result;
            }

            public string ProcessCommand(string command)
            {
                int indexOfFirstSpace = command.IndexOf(' ');
                string method = command.Substring(0, indexOfFirstSpace);
                string parameterValues = command.Substring(indexOfFirstSpace + 1);
                string[] parameters = parameterValues.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string commandResult;
                switch (method)
                {
                    case "Append":
                        {
                            commandResult = AppendPerson(parameters[0]);
                            break;
                        }
                    case "Insert":
                        {
                            commandResult = InsertPerson(int.Parse(parameters[0]), parameters[1]);
                            break;
                        }
                    case "Find":
                        {
                            commandResult = FindProductsByName(parameters[0]).ToString();
                            break;
                        }
                    case "Serve":
                        {
                            commandResult = Serve(int.Parse(parameters[0]));
                            break;
                        }
                    default:
                        {
                            commandResult = INCORRECT_COMMAND;
                            break;
                        }
                }

                return commandResult;
            }
        }
    }
}