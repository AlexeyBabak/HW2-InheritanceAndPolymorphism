using BankApp.Models;

namespace BankApp
{
    public interface IMoney
    {
        int Hryvnias { get; }
        int Kopiykas { get; }

        bool Equals(Money other);
        bool Equals(object obj);
        int GetHashCode();
    }
}