using System.Text;

namespace _6.PhoneBook
{
    public class Person
    {
        public Person(string firstName = null, string middleName = null, string lastName = null, string nickname = null)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.NickName = nickname;
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(this.FirstName))
            {
                result.Append(this.FirstName);
            }

            if (!string.IsNullOrWhiteSpace(this.MiddleName))
            {
                result.Append(" " + this.MiddleName);
            }

            if (!string.IsNullOrWhiteSpace(this.LastName))
            {
                result.Append(" " + this.LastName);
            }

            if (!string.IsNullOrWhiteSpace(this.NickName))
            {
                result.Append(" " + this.NickName);
            }

            return result.ToString();
        }
    }
}
