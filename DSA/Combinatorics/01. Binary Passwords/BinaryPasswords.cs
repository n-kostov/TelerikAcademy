namespace _01.Binary_Passwords
{
    using System;

    public class BinaryPasswords
    {
        public static void Main(string[] args)
        {
            string tempate = Console.ReadLine();
            int starCount = 0;
            for (int i = 0; i < tempate.Length; i++)
            {
                if (tempate[i] == '*')
                {
                    starCount++;
                }
            }

            long result = (long)Math.Pow(2, starCount);
            Console.WriteLine(result);
        }
    }
}
