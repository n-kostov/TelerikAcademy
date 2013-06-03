using System;

public class MortgageAccount : Account, IDepositable
{

    public MortgageAccount(Customer owner, decimal balance, decimal interestRate)
        : base(owner, balance, interestRate)
    { }

    public void Deposit(decimal money)
    {
        if (money >= 0)
        {
            Balance += money;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Mortgage account cannot withdraw money");
        }
    }


    public override decimal CalculateInterest(int months)
    {
        if (Owner == Customer.Individual)
        {
            if (months - 6 <= 0)
            {
                return 0;
            }
            else
            {
                return base.CalculateInterest(months - 6);
            }
        }
        else
        {
            decimal interest = 0;
            if (months <= 12)
            {
                interest += base.CalculateInterest(months);
            }
            else
            {
                interest += base.CalculateInterest(12);
                interest /= 2;
                interest += base.CalculateInterest(months - 12);
            }
            return interest;
        }
    }
}
