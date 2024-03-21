namespace PumpkinTale
{
    public class Helper
    {
        private static readonly Random rnd = new();

        public static int RandomDamage(int min, int max)
        {
            return rnd.Next(min, max + 1);
        }
    }
}
