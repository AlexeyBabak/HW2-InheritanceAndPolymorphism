using BankApp.Validators;
using System.ComponentModel.DataAnnotations;

namespace BankApp.Models
{
    public class Account : IAccount
    {
        public Guid AccountId { get; } = Guid.NewGuid();
        public Money Balance { get; private set; }

        private int interestRate;

        [InterestRateValidation(0, 20)]
        public int InterestRate
        {
            get => interestRate;
            private set
            {
                var property = GetType()
                    .GetProperty(nameof(InterestRate));
                var attribute = property
                    .GetCustomAttributes(typeof(InterestRateValidationAttribute), false)
                    .FirstOrDefault() as InterestRateValidationAttribute;
                if (attribute != null && !attribute.IsValid(value))
                {
                    throw new ValidationException($"Interest rate must be between {attribute.Min} and {attribute.Max}.");
                }
                interestRate = value;
            }
        }

        private readonly List<ITransaction> _transactions = new();

        public Account(int initialRate)
        {
            try
            {
                Balance = new Money(0, 0);
                SetInterestRate(initialRate);
            }
            catch (ValidationException ex)
            {
                throw new InvalidOperationException("Failed to create account due to invalid interest rate.", ex);
            }
        }

        public void Deposit(Money amount)
        {
            try
            {
                Balance += amount;
                AddTransaction(new Transaction(amount, TransactionType.Deposit, AccountId));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Deposit operation failed.", ex);
            }
        }

        public void Withdraw(Money amount)
        {
            if (Balance - amount < new Money(0, 0))
            {
                throw new InvalidOperationException("Balance can not be negative.");
            }

            try
            {
                Balance -= amount;
                AddTransaction(new Transaction(amount, TransactionType.Withdrawal, AccountId));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Withdrawal operation failed.", ex);
            }
        }

        public void AddTransaction(ITransaction transaction)
        {
            try
            {
                _transactions.Add(transaction);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to add transaction.", ex);
            }
        }

        public void SetInterestRate(int newRate)
        {
            try
            {
                InterestRate = newRate;
            }
            catch (ValidationException ex)
            {
                throw new InvalidOperationException("Failed to set interest rate due to validation error.", ex);
            }
        }

        public IReadOnlyList<ITransaction> GetTransactions() => _transactions.AsReadOnly();
    }
}
