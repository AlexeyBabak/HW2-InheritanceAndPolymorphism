namespace PumpkinTale.Abstractions
{
    public abstract class Plant : IPlant
    {
        public int Health { get; protected set; }

        protected Plant(int health)
        {
            Health = health;
        }

        public abstract bool IsPulledOut();

        public abstract void DecreaseHealth(int amount);
    }
}
