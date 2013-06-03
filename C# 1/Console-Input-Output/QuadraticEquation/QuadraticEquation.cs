using System;

class QuadraticEquation
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        if (a == 0)
        {
            if (b == 0)
            {
                if (c == 0)
                {
                    Console.WriteLine("The root of {0}x^2 + {1}x + {2}=0 is every x",
                        a, b, c);
                }
                else
                {
                    Console.WriteLine("{0}x^2 + {1}x + {2}=0 has no root",
                        a, b, c);
                }
            }
            else
            {
                if (c == 0)
                {
                    Console.WriteLine("The root of {0}x^2 + {1}x + {2}=0 is x=0",
                        a, b, c);
                }
                else
                {
                    Console.WriteLine("The root of {0}x^2 + {1}x + {2}=0 is x={3}",
                        a, b, c, -(c / (float)b));
                }
            }
        }
        else
        {
            if (b == 0)
            {
                if (c == 0)
                {
                    Console.WriteLine("The root of {0}x^2 + {1}x + {2}=0 is x=0",

                        a, b, c);
                }
                else
                {
                    if (-(c / (float)a) < 0)
                    {
                        Console.WriteLine("{0}x^2 + {1}x + {2}=0 has no root",
                            a, b, c);
                    }
                    else
                    {
                        Console.Write("The roots of {0}x^2 + {1}x + {2}=0 are x1={3}",
                         a, b, c, -Math.Sqrt(-(c / (float)a)));
                        Console.WriteLine(" and x2={0}", Math.Sqrt(-(c / (float)a)));
                    }
                }
            }
            else
            {
                if (c == 0)
                {
                    Console.Write("The roots of {0}x^2 + {1}x + {2}=0 are x1=0",
                        a, b, c);
                    Console.WriteLine(" and x2={0}", Math.Sqrt(-(b / (float)a)));
                }
                else
                {
                    float discriminant = 0;
                    if (b % 2 == 0)
                    {
                        discriminant += (b/2f) * (b/2f) - a * c;
                        if (discriminant == 0)
                        {
                            Console.WriteLine("The root of {0}x^2 + {1}x + {2}=0 is x1={3}",
                                a, b, c, -(b/2f) / (float)a);
                        }
                        else
                        {
                            Console.Write("The roots of {0}x^2 + {1}x + {2}=0 are x1={3}",
                                a, b, c, (-(b/2f) - Math.Sqrt(discriminant)) / (float)a);
                            Console.WriteLine(" and x2={0}", (-(b/2f) + Math.Sqrt(discriminant)) / (float)a);
                        }
                    }
                    else
                    {
                        discriminant += b * b - 4 * a * c;
                        if (discriminant == 0)
                        {
                            Console.WriteLine("The root of {0}x^2 + {1}x + {2}=0 is x1={3}",
                                a, b, c, -b / (float)(a * 2));
                        }
                        else
                        {
                            Console.Write("The roots of {0}x^2 + {1}x + {2}=0 are x1={3}",
                                a, b, c, (-b - Math.Sqrt(discriminant)) / (float)(a * 2));
                            Console.WriteLine(" and x2={0}", (-b + Math.Sqrt(discriminant)) / (float)(a * 2));
                        }
                        //Console.Write("The roots of {0}x^2 + {1}x + {2}=0 are x1={3}",
                        //    a, b, c, (-b - Math.Sqrt (discriminant))/(float)a);
                        //Console.WriteLine(" and x2={0}", (-b + Math.Sqrt (discriminant))/(float)a);
                    }
                }
            }
        }
    }
}
