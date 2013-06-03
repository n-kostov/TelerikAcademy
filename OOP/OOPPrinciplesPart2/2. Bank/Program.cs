using System;

//  2.A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. 
//  Customers could be individuals or companies. All accounts have customer, balance and interest rate (monthly based). 
//  Deposit accounts are allowed to deposit and with draw money. Loan and mortgage accounts can only deposit money. 
//  All accounts can calculate their interest amount for a given period (in months). In the common case its is calculated 
//  as follows: number_of_months * interest_rate. Loan accounts have no interest for the first 3 months if are held by individuals
//  and for the first 2 months if are held by a company. Deposit accounts have no interest if their balance is positive and 
//  less than 1000. Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the 
//  first 6 months for individuals. Your task is to write a program to model the bank system by classes and interfaces. 
//  You should identify the classes, interfaces, base classes and abstract actions and 
//  implement the calculation of the interest functionality through overridden methods.



class Program
{
    static void Main(string[] args)
    {
        Bank myBank = new Bank();
        myBank.AddAccount(new DepositAccount(Customer.Company, 200m, 1.5m));
        myBank.AddAccount(new LoanAccount(Customer.Individual, -20, 2m));
        myBank.AddAccount(new MortgageAccount(Customer.Individual, -100m, 3m));

        Account acc = new DepositAccount(Customer.Individual, 200m, 4m);
        myBank.AddAccount(acc);

        foreach (var account in myBank.Accounts)
        {
            Console.WriteLine("{0}(Money = {1})'s interest => {2}", account.GetType(), account.Balance, account.CalculateInterest(14));
        }

        myBank.RemoveAccount(acc);

        if (acc is DepositAccount)
        {
            DepositAccount changeAcc = acc as DepositAccount;
            changeAcc.Deposit(1000);
            changeAcc.WithDraw(100);
            myBank.AddAccount(changeAcc);
        }

        Console.WriteLine();
        foreach (var account in myBank.Accounts)
        {
            Console.WriteLine("{0}(Money = {1})'s interest => {2}", account.GetType(), account.Balance, account.CalculateInterest(14));
        }
    }
}
