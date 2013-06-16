using System;
using System.IO;
using System.Linq;
using Wintellect.PowerCollections;

namespace _6.PhoneBook
{
    public class PhoneBook
    {
        private static MultiDictionary<Person, PhoneRecord> phoneRecordsByNames = new MultiDictionary<Person, PhoneRecord>(true);

        public static void Main(string[] args)
        {
            string filename = "phones.txt";
            ParsePhoneBook(filename);

            // executing commands from file is not done because I don't find it necessary to parse once again file
            // Find is tested internally in Main
            Find("Kireto");
            Find("Gancho");
            Find("Bla-Bla");
            Find("Kireto", "Sofia");
            Find("Petrova", "Karnobat");
        }

        public static void Find(string name)
        {
            var records = phoneRecordsByNames.Where(x =>
                x.Key.FirstName == name || x.Key.MiddleName == name || x.Key.LastName == name || x.Key.NickName == name);

            Console.WriteLine("Records for {0}:", name);
            foreach (var record in records)
            {
                Console.WriteLine(record.Value);
            }

            Console.WriteLine();
        }

        public static void Find(string name, string town)
        {
            var records = phoneRecordsByNames.Values.Where(x =>
                (x.Person.FirstName == name || x.Person.MiddleName == name || x.Person.LastName == name || x.Person.NickName == name) &&
                x.Town == town);

            Console.WriteLine("Records of {0} living in {1}: ", name, town);
            foreach (var record in records)
            {
                Console.WriteLine(record);
            }

            Console.WriteLine();
        }

        private static void ParsePhoneBook(string filename)
        {
            using (var sr = new StreamReader(filename))
            {
                string line;
                char[] delim = { ' ' };
                do
                {
                    line = sr.ReadLine();
                    string[] parameters = line.Split('|');
                    string[] names = parameters[0].Split(delim, StringSplitOptions.RemoveEmptyEntries);
                    Person person = new Person();
                    for (int i = 0; i < names.Length; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                person.FirstName = names[i];
                                break;
                            case 1:
                                person.MiddleName = names[i];
                                break;
                            case 2:
                                person.LastName = names[i];
                                break;
                            case 3:
                                person.NickName = names[i];
                                break;
                            default:
                                break;
                        }
                    }

                    PhoneRecord phoneRecord = new PhoneRecord(person, parameters[1].Trim(), parameters[2].Trim());
                    phoneRecordsByNames.Add(person, phoneRecord);
                }
                while (!sr.EndOfStream);
            }
        }
    }
}
