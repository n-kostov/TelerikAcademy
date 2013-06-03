using System;

public class LoanAccount : Account, IDepositable
{

    public LoanAccount(Customer owner, decimal balance, decimal interestRate)
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
            throw new ArgumentOutOfRangeException("Loan account cannot withdraw money");
        }
    }

    public override decimal CalculateInterest(int months)
    {
        if (Owner == Customer.Individual)
        {
            if (months - 3 <= 0)
            {
                return 0;
            }
            else
            {
                return base.CalculateInterest(months - 3);
            }
        }
        else
        {
            if (months - 2 <= 0)
            {
                return 0;
            }
            else
            {
                return base.CalculateInterest(months - 2);
            }
        }
    }
}
