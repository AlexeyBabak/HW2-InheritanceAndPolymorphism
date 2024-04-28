namespace BankApp;

public interface IBank
{
    Task AddClientAsync(IClient client);
    Task<IAccount> OpenAccountAsync(IClient client);
    IEnumerable<IAccount> GetAllAccounts();
    IEnumerable<IClient> GetAllClients();
}