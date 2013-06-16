using System.Text;
namespace _6.PhoneBook
{
    public class PhoneRecord
    {
        public PhoneRecord(Person person, string town, string phoneNumber)
        {
            this.Person = person;
            this.Town = town;
            this.PhoneNumber = phoneNumber;
        }   
     
        public Person Person { get; private set; }

        public string Town { get; private set; }

        public string PhoneNumber { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.Person.ToString());
            result.Append(" | ");
            result.Append(this.Town);
            result.Append(" | ");
            result.Append(this.PhoneNumber);

            return result.ToString();
        }
    }
}
