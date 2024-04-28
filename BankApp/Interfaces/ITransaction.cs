using BankApp.Models;

namespace BankApp;

public interface ITransaction
{
    Money Amount { get; }
    DateTime Date { get; }
    Guid? RelatedAccountId { get; }
    TransactionType Type { get; }
}