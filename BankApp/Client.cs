namespace BankApp
{
    public class Client : IClient
    {
        public string FirstName { get; }
        public string LastName { get; }
        public bool IsVerified { get; private set; }

        private readonly List<IAccount> _accounts = new();

        public Client(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void Verify()
        {
            IsVerified = true;
        }

        public bool HasNegativeBalanceHistory()
        {
            return _accounts.Any(account => account.Balance.Hryvnias < 0 || (account.Balance.Hryvnias == 0 && account.Balance.Kopiykas < 0));
        }

        public bool TransferMoney(IAccount fromAccount, IAccount toAccount, Money amount)
        {
            if (!_accounts.Contains(fromAccount) || !_accounts.Contains(toAccount))
            {
                return false;
            }

            if (!fromAccount.Withdraw(amount)) return false;

            toAccount.Deposit(amount);

            fromAccount.AddTransaction(new Transaction(amount, TransactionType.Transfer, toAccount.AccountId));
            toAccount.AddTransaction(new Transaction(amount, TransactionType.Transfer, fromAccount.AccountId));

            return true;
        }

        public void AddAccount(IAccount account) => _accounts.Add(account);

        public IEnumerable<Money> GetAccountBalances() => _accounts.Select(account => account.Balance);

        public IEnumerable<IAccount> GetClientAccounts() => _accounts.AsReadOnly();
    }
}
