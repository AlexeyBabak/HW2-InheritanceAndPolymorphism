using PumpkinTale.Abstractions;
using PumpkinTale.Models;

namespace PumpkinTale.Factory
{
    public class CharacterFactory : ICharacterFactory
    {
        public ICharacter CreateCharacter(string type)
        {
            return type.ToLower() switch
            {
                "grandfather" => new Grandfather(),
                "grandmother" => new Grandmother(),
                "granddaughter" => new Granddaughter(),
                "dog" => new Dog(),
                _ => throw new ArgumentException("Unknown type", nameof(type)),
            };
        }
    }
}
