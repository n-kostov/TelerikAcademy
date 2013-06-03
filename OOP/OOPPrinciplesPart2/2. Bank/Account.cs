using System;

public abstract class Account : IInterest
{
    private Customer owner;
    private decimal balance;
    private decimal interestRate;

    public decimal InterestRate
    {
        get
        {
            return this.interestRate;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The interest rate cannot be less than 0!");
            }
            this.interestRate = value;
        }
    }

    public decimal Balance
    {
        get
        {
            return this.balance;
        }
        set
        {
            this.balance = value;
        }
    }

    public Customer Owner
    {
        get
        {
            return this.owner;
        }
        set
        {
            this.owner = value;
        }
    }

    protected Account(Customer owner, decimal balance, decimal interestRate)
    {
        this.owner = owner;
        this.balance = balance;
        this.interestRate = interestRate;
    }

    public virtual decimal CalculateInterest(int months)
    {
        return interestRate * months;
    }
}
