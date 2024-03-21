using PumpkinTale.Abstractions;
using PumpkinTale.Models;

namespace PumpkinTale.Factory
{
    public class CharacterFactory : ICharacterFactory
    {
        public ICharacter CreateAnimal(string type)
        {
            switch (type.ToLower())
            {
                case "grandfather":
                    return new Grandfather();
                case "grandmother":
                    return new Grandmother();
                case "granddaughter":
                    return new Granddaughter();
                case "dog":
                    return new Dog();
                default:
                    throw new ArgumentException("Unknown type", nameof(type));
            }
        }
    }
}
