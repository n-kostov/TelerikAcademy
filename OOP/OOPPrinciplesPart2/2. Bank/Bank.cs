using System;
using System.Collections.Generic;
using System.Linq;

public class Bank
{
    private List<Account> accounts = new List<Account>();

    public List<Account> Accounts
    {
        get
        {
            return this.accounts.AsReadOnly().ToList();
        }
    }

    public void AddAccount(Account accountToAdd)
    {
        accounts.Add(accountToAdd);
    }

    public void RemoveAccount(Account accountToDelete)
    {
        accounts.Remove(accountToDelete);
    }
}
