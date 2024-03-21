﻿namespace BankApp
{
    public interface IClient
    {
        string FirstName { get; }
        bool IsVerified { get; }
        string LastName { get; }

        void AddAccount(IAccount account);
        IEnumerable<Money> GetAccountBalances();
        IEnumerable<IAccount> GetClientAccounts();
        bool HasNegativeBalanceHistory();
        bool TransferMoney(IAccount fromAccount, IAccount toAccount, Money amount);
        void Verify();
    }
}