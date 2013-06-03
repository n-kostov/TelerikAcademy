using System;

class CompanyInformation
{
    struct Manager
    {
        
        public string firstName;
        public string lastNAme;
        public int age;
        public string phoneNumber;
    };

    static void Main()
    {
        string name = Console.ReadLine();
        string address = Console.ReadLine();
        string phoneNumber = Console.ReadLine();
        string webSite = Console.ReadLine();
        Manager manager;
        manager.firstName = Console.ReadLine();
        manager.lastNAme = Console.ReadLine();
        manager.age = int.Parse(Console.ReadLine());
        manager.phoneNumber = Console.ReadLine();
        Console.WriteLine("{0} {1} {2} years old with Phone:{3}", manager.firstName, 
            manager.lastNAme, manager.age, manager.phoneNumber);
        Console.WriteLine(" is manager at {0}. The company has address:{1}", name, address);
        Console.WriteLine("Phone:{0}\nWebsite:{1}", phoneNumber, webSite);

    }
}

