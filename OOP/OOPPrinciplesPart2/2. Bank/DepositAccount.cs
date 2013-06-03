using System;
class DepositAccount : Account, IDepositable, IWithdrawable
{
    public DepositAccount(Customer owner, decimal balance, decimal interestRate)
        : base(owner, balance, interestRate)
    { }

    public void Deposit(decimal money)
    {
        Balance += money;
    }

    public void WithDraw(decimal money)
    {
        Balance -= money;
    }

    public override decimal CalculateInterest(int months)
    {
        if (Balance > 0 && Balance < 1000)
        {
            return 0;
        }
        else
        {
            return base.CalculateInterest(months);
        }
    }
}
