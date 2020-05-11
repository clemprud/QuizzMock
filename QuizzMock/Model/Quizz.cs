using System.Collections.Generic;

namespace QuizzMock.Model
{
    public class Quizz
    {
        public List<Question> Questions { get; set; }
        public Level AverageLevel { get; set; }
    }
}
