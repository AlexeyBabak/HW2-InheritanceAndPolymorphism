namespace BankApp.Models;

public class Bank : IBank
{
    private readonly List<IClient> _clients = new();
    private readonly List<IAccount> _accounts = new();

    public async Task AddClientAsync(IClient client)
    {
        try
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "Client cannot be null.");
            }

            await Task.Run(() => _clients.Add(client));
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to add client.", ex);
        }
    }

    public async Task<IAccount> OpenAccountAsync(IClient client)
    {
        try
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "Client cannot be null.");
            }

            if (!CanHaveAccount(client))
            {
                throw new InvalidOperationException($"{client.FirstName} {client.LastName} is not eligible for an account.");
            }

            var account = new Account(0);
            await Task.Run(() =>
            {
                _accounts.Add(account);
                client.AddAccount(account);
            });

            return account;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while opening a new account.", ex);
        }
    }

    private static bool CanHaveAccount(IClient client)
    {
        return client.IsVerified && !client.HasNegativeBalanceHistory();
    }

    public IEnumerable<IAccount> GetAllAccounts() => _accounts.AsReadOnly();
    public IEnumerable<IClient> GetAllClients() => _clients.AsReadOnly();
}
