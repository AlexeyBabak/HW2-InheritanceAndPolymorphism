namespace BankApp
{
    public class Bank : IBank
    {
        private readonly List<IClient> _clients = new();
        private readonly List<IAccount> _accounts = new();

        public void AddClient(IClient client) => _clients.Add(client);

        public IAccount OpenAccount(IClient client)
        {
            if (!CanHaveAccount(client))
            {
                throw new InvalidOperationException($"{client.FirstName} {client.LastName} is not eligible for an account.");
            }

            var account = new Account(0.01m);
            _accounts.Add(account);
            client.AddAccount(account);
            return account;
        }

        private static bool CanHaveAccount(IClient client)
        {
            return client.IsVerified && !client.HasNegativeBalanceHistory();
        }

        public IEnumerable<IAccount> GetAllAccounts() => _accounts.AsReadOnly();
        public IEnumerable<IClient> GetAllClients() => _clients.AsReadOnly();
    }
}
