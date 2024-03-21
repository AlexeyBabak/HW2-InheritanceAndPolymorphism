using PumpkinTale.Abstractions;

namespace PumpkinTale.Factory
{
    public interface ICharacterFactory
    {
        ICharacter CreateAnimal(string type);
    }
}
