namespace BankApp.Models;

public enum TransactionType { Deposit, Withdrawal, Transfer }

public class Transaction : ITransaction
{
    public DateTime Date { get; }
    public Money Amount { get; }
    public TransactionType Type { get; }
    public Guid? RelatedAccountId { get; private set; }

    public Transaction(Money amount, TransactionType type, Guid? relatedAccountId = null)
    {
        Date = DateTime.Now;
        Amount = amount;
        Type = type;
        RelatedAccountId = relatedAccountId;
    }
}
