using PumpkinTale.Abstractions;

namespace PumpkinTale
{
    public class PumpkinTale
    {
        private readonly Queue<ICharacter> _characters = new();
        private readonly Plant _plant;

        public PumpkinTale(Plant plant)
        {
            _plant = plant;
        }

        public void AddCharacter(ICharacter character)
        {
            _characters.Enqueue(character);
        }

        public void StartTale()
        {
            string plantName = _plant.GetType().Name;

            while (_characters.Count > 0)
            {
                var character = _characters.Dequeue();
                Console.WriteLine($"{character.Name} tries to pull the {plantName.ToLower()}.");
                if (character.TryPullPlant(_plant))
                {
                    Console.WriteLine($"{character.Name} has pulled the {plantName.ToLower()} out!");
                    return;
                }
                else
                {
                    character.CallForHelp();
                }
            }

            Console.WriteLine($"The {plantName.ToLower()} remains in the garden, undefeated >_<");
        }
    }
}
