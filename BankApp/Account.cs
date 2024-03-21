namespace BankApp
{
    public class Account : IAccount
    {
        public Guid AccountId { get; } = Guid.NewGuid();
        public Money Balance { get; private set; }
        public decimal InterestRate { get; private set; }

        private readonly List<ITransaction> _transactions = new();

        public Account(decimal initialRate)
        {
            Balance = new Money(0, 0);
            InterestRate = initialRate;
        }

        public void Deposit(Money amount)
        {
            Balance += amount;
            AddTransaction(new Transaction(amount, TransactionType.Deposit, this.AccountId));
        }

        public bool Withdraw(Money amount)
        {
            if (Balance - amount < new Money(0, 0)) return false;

            Balance -= amount;
            AddTransaction(new Transaction(amount, TransactionType.Withdrawal, this.AccountId));
            return true;
        }

        public void AddTransaction(ITransaction transaction)
        {
            _transactions.Add(transaction);
        }

        public void SetInterestRate(decimal newRate) => InterestRate = newRate;

        public IReadOnlyList<ITransaction> GetTransactions() => _transactions.AsReadOnly();
    }

}
