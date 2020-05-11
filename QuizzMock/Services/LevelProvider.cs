using System;

namespace QuizzMock
{

    public interface ILevelProvider
    {
        Level GetLevel();
    }

    public class LevelProvider : ILevelProvider
    {
        private readonly Random _random;

        public LevelProvider()
        {
            _random = new Random();
        }

        public Level GetLevel()
        {
            // Génère une valeur aléatoire dans un interval donné
            var tirage = _random.Next(1, 10);
            
            if (tirage < 5) // De 1 à 4 : 40%
                return Level.Easy;
            if (tirage < 9) // De 5 à 8 : 40%
                return Level.Medium;
            else // De 9 à 10 : 20%
                return Level.Hard;
        }       
    }

    public enum Level
    {
        Easy,
        Medium,
        Hard
    }
}
