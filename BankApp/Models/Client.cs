using System.ComponentModel.DataAnnotations;

namespace BankApp.Models
{
    public class Client : IClient
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; }
        public bool IsVerified { get; private set; }

        private readonly List<IAccount> _accounts = new();

        public Client(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name must not be null or whitespace.", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name must not be null or whitespace.", nameof(lastName));


            FirstName = firstName;
            LastName = lastName;
        }

        public void Verify()
        {
            IsVerified = true;
        }

        public bool HasNegativeBalanceHistory()
        {
            return _accounts.Any(account => account.Balance.Hryvnias < 0 || account.Balance.Hryvnias == 0 && account.Balance.Kopiykas < 0);
        }

        public void TransferMoney(IAccount fromAccount, IAccount toAccount, Money amount)
        {
            ValidateTransferParameters(fromAccount, toAccount, amount);
            EnsureAccountsBelongToClient(fromAccount, toAccount);

            ExecuteTransfer(fromAccount, toAccount, amount);
        }

        public void AddAccount(IAccount account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account), "Account cannot be null.");

            _accounts.Add(account);
        }

        private static void ValidateTransferParameters(IAccount fromAccount, IAccount toAccount, Money amount)
        {
            if (fromAccount == null) throw new ArgumentNullException(nameof(fromAccount), "Source account cannot be null.");
            if (toAccount == null) throw new ArgumentNullException(nameof(toAccount), "Destination account cannot be null.");
            if (amount.Hryvnias < 0 || amount.Hryvnias == 0 && amount.Kopiykas < 0)
                throw new ArgumentException("Amount to transfer cannot be negative.", nameof(amount));
        }

        private void EnsureAccountsBelongToClient(IAccount fromAccount, IAccount toAccount)
        {
            if (!_accounts.Contains(fromAccount))
                throw new InvalidOperationException("Source account does not belong to this client.");
            if (!_accounts.Contains(toAccount))
                throw new InvalidOperationException("Destination account does not belong to this client.");
        }

        private static void ExecuteTransfer(IAccount fromAccount, IAccount toAccount, Money amount)
        {
            try
            {
                fromAccount.Withdraw(amount);
                toAccount.Deposit(amount);

                fromAccount.AddTransaction(new Transaction(amount, TransactionType.Transfer, toAccount.AccountId));
                toAccount.AddTransaction(new Transaction(amount, TransactionType.Transfer, fromAccount.AccountId));
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Transfer failed: " + ex.Message, ex);
            }
        }

        public IEnumerable<Money> GetAccountBalances() => _accounts.Select(account => account.Balance);

        public IEnumerable<IAccount> GetClientAccounts() => _accounts.AsReadOnly();
    }
}
