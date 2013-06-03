using System;

class IntDoubleOrString
{
    static void Main()
    {
        int choice = int.Parse(Console.ReadLine());
        object value = null;
        switch (choice)
        {
            case 1:
                int a = int.Parse(Console.ReadLine());
                value = a+1;
                break;
            case 2:
                double b = double.Parse(Console.ReadLine());
                value = b+1;
                break;
            case 3:
                string str = Console.ReadLine();
                value = str+"*";
                break;
            default:
                Console.WriteLine("Wrong choice");
                break;
        }
        if (value is int || value is double || value is string)
        {
            Console.WriteLine(value);
        }

    }
}

