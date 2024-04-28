using BankApp.Models;

namespace BankApp.Services;

public class BankDisplayService
{
    public static void ShowAllClients(IBank bank)
    {
        try
        {
            Console.WriteLine("Showing all clients in the bank:");
            var clients = bank.GetAllClients();
            foreach (var client in clients)
            {
                Console.WriteLine($"Client: {client.FirstName} {client.LastName}, Verified: {client.IsVerified}");
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while displaying clients: {ex.Message}");
        }
    }

    public static void ShowAllAccounts(IBank bank)
    {
        try
        {
            Console.WriteLine("Showing all accounts in the bank:");
            var accounts = bank.GetAllAccounts();
            foreach (var account in accounts)
            {
                Console.WriteLine($"AccountID: {account.AccountId} - Balance: {account.Balance.Hryvnias} Hryvnias and {account.Balance.Kopiykas} Kopiykas");
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while displaying accounts: {ex.Message}");
        }
    }

    public static void ShowClientAccounts(IClient client)
    {
        try
        {
            Console.WriteLine($"Client: {client.FirstName} {client.LastName}, Verified: {client.IsVerified}");
            Console.WriteLine("Accounts:");
            var accounts = client.GetClientAccounts();
            foreach (var account in accounts)
            {
                Console.WriteLine($"AccountID: {account.AccountId} - Balance: {account.Balance.Hryvnias} Hryvnias and {account.Balance.Kopiykas} Kopiykas");
            }

            var totalBalance = client.GetAccountBalances().Aggregate(new Money(0, 0), (acc, money) => acc + money);
            Console.WriteLine($"Total Balance Across All Accounts: {totalBalance.Hryvnias} Hryvnias and {totalBalance.Kopiykas} Kopiykas\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while displaying client accounts: {ex.Message}");
        }
    }

    public static void ShowAccountStats(IAccount account)
    {
        try
        {
            Console.WriteLine($"AccountID: {account.AccountId} - Balance: {account.Balance.Hryvnias} Hryvnias and {account.Balance.Kopiykas} Kopiykas");
            Console.WriteLine("Transactions:");
            var transactions = account.GetTransactions();
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"- {transaction.Type}: {transaction.Amount.Hryvnias}.{transaction.Amount.Kopiykas}, Date: {transaction.Date}");
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while displaying account stats: {ex.Message}");
        }
    }
}
