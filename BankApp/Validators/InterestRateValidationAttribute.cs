namespace BankApp.Validators;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class InterestRateValidationAttribute : Attribute
{
    public int Min { get; }
    public int Max { get; }

    public InterestRateValidationAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }

    public bool IsValid(int value)
    {
        return value >= Min && value <= Max;
    }
}
