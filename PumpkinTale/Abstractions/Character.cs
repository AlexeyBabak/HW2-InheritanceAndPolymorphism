namespace PumpkinTale.Abstractions
{
    public abstract class Character : ICharacter
    {
        public string Name { get; private set; }
        private readonly int _minDamage;
        private readonly int _maxDamage;

        protected Character(string name, int minDamage, int maxDamage)
        {
            Name = name;
            _minDamage = minDamage;
            _maxDamage = maxDamage;
        }

        public virtual bool TryPullPlant(Plant plant)
        {
            int damage = Helper.RandomDamage(_minDamage, _maxDamage);
            plant.DecreaseHealth(damage);
            return plant.IsPulledOut();
        }

        public virtual void CallForHelp()
        {
            Console.WriteLine($"{Name} is calling for help!");
        }
    }
}
