namespace BankApp
{
    public readonly struct Money : IMoney
    {
        public int Hryvnias { get; }
        public int Kopiykas { get; }

        public Money(int hryvnias, int kopiykas)
        {
            Hryvnias = hryvnias + kopiykas / 100;
            Kopiykas = kopiykas % 100;
        }

        public static Money operator +(Money a, Money b) =>
            new Money(a.Hryvnias + b.Hryvnias, a.Kopiykas + b.Kopiykas);

        public static Money operator -(Money a, Money b)
        {
            var totalKopiykasA = a.Hryvnias * 100 + a.Kopiykas;
            var totalKopiykasB = b.Hryvnias * 100 + b.Kopiykas;
            var resultKopiykas = totalKopiykasA - totalKopiykasB;

            return new Money(0, resultKopiykas);
        }

        public static bool operator ==(Money a, Money b) => a.Equals(b);

        public static bool operator !=(Money a, Money b) => !a.Equals(b);

        public static bool operator <(Money a, Money b) =>
        a.Hryvnias < b.Hryvnias || (a.Hryvnias == b.Hryvnias && a.Kopiykas < b.Kopiykas);

        public static bool operator >(Money a, Money b) =>
            a.Hryvnias > b.Hryvnias || (a.Hryvnias == b.Hryvnias && a.Kopiykas > b.Kopiykas);

        public static bool operator <=(Money a, Money b) => a < b || a == b;
        public static bool operator >=(Money a, Money b) => a > b || a == b;

        public override bool Equals(object obj) => obj is Money money && Equals(money);

        public bool Equals(Money other) => Hryvnias == other.Hryvnias && Kopiykas == other.Kopiykas;

        public override int GetHashCode() => HashCode.Combine(Hryvnias, Kopiykas);
    }
}
