namespace QuizzMock.Model
{
    public class BasicQuestion
    {
        public string Libelle { get; set; }
        public int Points { get; set; }

        public BasicQuestion()
        {
            Libelle = "To be or not to be ?";
            Points = 1;
        }
    }
}
