using System;

namespace _11_Version
{
    class Program
    {
        static void Main(string[] args)
        {
            Dummy dummy = new Dummy();
            Type type = typeof(Dummy);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute attr in allAttributes)
            {
                Console.WriteLine("{0}: {1}", attr, attr.Version);
            }
        }
    }
}
