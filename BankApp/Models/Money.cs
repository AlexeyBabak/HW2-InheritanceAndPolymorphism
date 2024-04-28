namespace BankApp.Models;

public readonly struct Money : IMoney
{
    public int Hryvnias { get; }
    public int Kopiykas { get; }

    public Money(int hryvnias, int kopiykas)
    {
        if (hryvnias < 0)
            throw new ArgumentOutOfRangeException(nameof(hryvnias), "Hryvnias cannot be negative.");

        if (kopiykas < 0)
            throw new ArgumentOutOfRangeException(nameof(kopiykas), "Kopiykas cannot be negative.");

        Hryvnias = hryvnias + kopiykas / 100;
        Kopiykas = kopiykas % 100;
    }

    public static Money operator +(Money a, Money b) =>
        new(a.Hryvnias + b.Hryvnias, a.Kopiykas + b.Kopiykas);

    public static Money operator -(Money a, Money b)
    {
        try
        {
            var totalKopiykasA = a.Hryvnias * 100 + a.Kopiykas;
            var totalKopiykasB = b.Hryvnias * 100 + b.Kopiykas;
            var resultKopiykas = totalKopiykasA - totalKopiykasB;

            if (resultKopiykas < 0)
                throw new InvalidOperationException("Resulting money value cannot be negative.");

            return new Money(0, resultKopiykas);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error performing subtraction.", ex);
        }
    }

    public static bool operator ==(Money a, Money b) => a.Equals(b);

    public static bool operator !=(Money a, Money b) => !a.Equals(b);

    public static bool operator <(Money a, Money b) =>
    a.Hryvnias < b.Hryvnias || a.Hryvnias == b.Hryvnias && a.Kopiykas < b.Kopiykas;

    public static bool operator >(Money a, Money b) =>
        a.Hryvnias > b.Hryvnias || a.Hryvnias == b.Hryvnias && a.Kopiykas > b.Kopiykas;

    public static bool operator <=(Money a, Money b) => a < b || a == b;
    public static bool operator >=(Money a, Money b) => a > b || a == b;

    public override bool Equals(object obj) => obj is Money money && Equals(money);

    public bool Equals(Money other) => Hryvnias == other.Hryvnias && Kopiykas == other.Kopiykas;

    public override int GetHashCode() => HashCode.Combine(Hryvnias, Kopiykas);
}
