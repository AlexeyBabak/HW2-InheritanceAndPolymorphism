namespace PumpkinTale.Abstractions
{
    public interface ICharacter
    {
        string Name { get; }

        void CallForHelp();
        bool TryPullPlant(Plant plant);
    }
}