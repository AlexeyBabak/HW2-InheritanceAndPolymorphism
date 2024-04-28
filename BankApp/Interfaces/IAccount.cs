using BankApp.Models;

namespace BankApp;

public interface IAccount
{
    Guid AccountId { get; }
    Money Balance { get; }
    int InterestRate { get; }

    void AddTransaction(ITransaction transaction);
    void Deposit(Money amount);
    IReadOnlyList<ITransaction> GetTransactions();
    void SetInterestRate(int newRate);
    void Withdraw(Money amount);
}