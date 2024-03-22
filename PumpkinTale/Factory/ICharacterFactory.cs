using PumpkinTale.Abstractions;

namespace PumpkinTale.Factory
{
    public interface ICharacterFactory
    {
        ICharacter CreateCharacter(string type);
    }
}
