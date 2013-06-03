using System;

class BankAccount
{
    static void Main()
    {
        string firstNme = "Johny";
        string middleName = "Likes";
        string lastName = "Depp";
        decimal balance = 120.243534m;
        string bankName = "Obedinena bulgarska banka";
        string IBAN = "BG 3423 3534523 23";
        string BIC = "OBB";
        ulong firstCreditCardNumber = 213124353463563;
        ulong secondcreditCardNumber = 32546357364353;
        ulong thirdcreditCardNumber = 2342324637547467634;
        Console.WriteLine("Account:");
        Console.WriteLine("BIC:{0}  IBAN:{1}", BIC , IBAN);
        Console.WriteLine(bankName);
        Console.WriteLine("Holder:{0} {1} {2}", firstNme , middleName , lastName);
        Console.WriteLine("Has 3 Credit cards:\n{0}\n{1}\n{2}",
            firstCreditCardNumber , secondcreditCardNumber , thirdcreditCardNumber);
        Console.WriteLine("With overall balance:{0}", balance);
        
    }
}

