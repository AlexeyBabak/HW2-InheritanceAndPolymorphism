namespace BankApp
{
    public interface IAccount
    {
        Guid AccountId { get; }
        Money Balance { get; }
        decimal InterestRate { get; }

        void AddTransaction(ITransaction transaction);
        void Deposit(Money amount);
        IReadOnlyList<ITransaction> GetTransactions();
        void SetInterestRate(decimal newRate);
        bool Withdraw(Money amount);
    }
}