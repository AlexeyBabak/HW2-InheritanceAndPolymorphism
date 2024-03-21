namespace BankApp
{
    public interface IBank
    {
        void AddClient(IClient client);
        IEnumerable<IAccount> GetAllAccounts();
        IEnumerable<IClient> GetAllClients();
        IAccount OpenAccount(IClient client);
    }
}