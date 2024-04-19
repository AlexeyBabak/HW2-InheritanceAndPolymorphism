using BankApp;
using BankApp.Services;
using BankApp.Models;

IBank bank = new Bank();

// Create Client 1
IClient client1 = new Client("Alexey", "Babak");
client1.Verify();

await bank.AddClientAsync(client1);

IAccount account1 = await bank.OpenAccountAsync(client1);
IAccount account2 = await bank.OpenAccountAsync(client1);

account1.SetInterestRate(10);

account1.Deposit(new Money(1000, 50));
account2.Deposit(new Money(500, 25));

account1.Withdraw(new Money(200, 0));

client1.TransferMoney(account1, account2, new Money(300, 50));

// Create Client 2

IClient client2 = new Client("John", "Doe");
client2.Verify();

await bank.AddClientAsync(client2);

IAccount account3 = await bank.OpenAccountAsync(client2);
IAccount account4 = await bank.OpenAccountAsync(client2);

account4.SetInterestRate(15);

account3.Deposit(new Money(1000, 50));
account4.Deposit(new Money(500, 25));

account3.Withdraw(new Money(200, 0));

client2.TransferMoney(account3, account4, new Money(300, 50));

// Show the data:
BankDisplayService.ShowAllClients(bank);
BankDisplayService.ShowAllAccounts(bank);

// Client 1
BankDisplayService.ShowClientAccounts(client1);

BankDisplayService.ShowAccountStats(account1);
BankDisplayService.ShowAccountStats(account2);

// Client 2
BankDisplayService.ShowClientAccounts(client2);

BankDisplayService.ShowAccountStats(account3);
BankDisplayService.ShowAccountStats(account4);
