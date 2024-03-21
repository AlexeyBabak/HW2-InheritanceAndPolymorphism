namespace PumpkinTale.Abstractions
{
    public interface IPlant
    {
        int Health { get; }

        void DecreaseHealth(int amount);
        bool IsPulledOut();
    }
}