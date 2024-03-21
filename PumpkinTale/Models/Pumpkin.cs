using PumpkinTale.Abstractions;

namespace PumpkinTale.Models
{
    public class Pumpkin : Plant
    {
        public Pumpkin(int health) : base(health) { }

        public override bool IsPulledOut()
        {
            return Health <= 0;
        }

        public override void DecreaseHealth(int amount)
        {
            Health -= amount;
        }
    }
}
