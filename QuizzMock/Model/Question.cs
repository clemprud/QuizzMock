namespace QuizzMock.Model
{
    public class Question
    {
        public string Libelle { get; set; }
        public int Points { get; set; }

        public Question(Level level)
        {
            Libelle = "To be or not to be ?";

            switch (level)
            {
                case Level.Easy:
                    Points = 1;
                    break;
                case Level.Medium:
                    Points = 2;
                    break;
                case Level.Hard:
                    Points = 3;
                    break;
                default:
                    Points = 1;
                    break;
            }
        }
    }
}
