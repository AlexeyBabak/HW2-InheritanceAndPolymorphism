namespace BankApp
{
    public class BankDisplayService
    {
        public static void ShowAllClients(IBank bank)
        {
            Console.WriteLine("Showing all clients in the bank:");
            foreach (var client in bank.GetAllClients())
            {
                Console.WriteLine($"Client: {client.FirstName} {client.LastName}, Verified: {client.IsVerified}");
            }
            Console.WriteLine();
        }

        public static void ShowAllAccounts(IBank bank)
        {
            Console.WriteLine("Showing all accounts in the bank:");
            foreach (var account in bank.GetAllAccounts())
            {
                Console.WriteLine($"AccountID: {account.AccountId} - Balance: {account.Balance.Hryvnias} Hryvnias and {account.Balance.Kopiykas} Kopiykas");
            }
            Console.WriteLine();
        }

        public static void ShowClientAccounts(IClient client)
        {
            Console.WriteLine($"Client: {client.FirstName} {client.LastName}, Verified: {client.IsVerified}");
            Console.WriteLine("Accounts:");
            foreach (var account in client.GetClientAccounts())
            {
                Console.WriteLine($"AccountID: {account.AccountId} Account Balance: {account.Balance.Hryvnias} Hryvnias and {account.Balance.Kopiykas} Kopiykas");
            }

            var totalBalance = client.GetAccountBalances().Aggregate(new Money(0, 0), (acc, money) => acc + money);
            Console.WriteLine($"Total Balance Across All Accounts: {totalBalance.Hryvnias} Hryvnias and {totalBalance.Kopiykas} Kopiykas\n");
        }

        public static void ShowAccountStats(IAccount account)
        {
            Console.WriteLine($"AccountID: {account.AccountId} Account Balance: {account.Balance.Hryvnias} Hryvnias and {account.Balance.Kopiykas} Kopiykas");
            Console.WriteLine("Transactions:");
            foreach (var transaction in account.GetTransactions())
            {
                Console.WriteLine($"- {transaction.Type}: {transaction.Amount.Hryvnias}.{transaction.Amount.Kopiykas}, Date: {transaction.Date}");
            }
            Console.WriteLine();
        }
    }
}
