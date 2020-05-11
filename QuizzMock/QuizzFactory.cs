using QuizzMock.Model;
using System.Collections.Generic;
using System.Linq;
namespace QuizzMock
{
    public class QuizzFactory
    {
        public readonly ILevelProvider _levelProvider;

        public QuizzFactory()
        {

        }

        public QuizzFactory(ILevelProvider levelProvider)
        {
            _levelProvider = levelProvider;
        }

        public Quizz GenerateQuizz(int size)
        {
            var questions = new List<Question>();

            for (int i = 0; i < size; i++)
            {
                questions.Add(new Question(_levelProvider.GetLevel()));
            }

            var ratio = questions.Sum(o => o.Points) / questions.Count();
            var avgLevel = new Level();

            if (ratio > 0 && ratio <= 1)
            {
                avgLevel = Level.Easy;
            }
            else if (ratio > 1 && ratio <= 2)
            {
                avgLevel = Level.Medium;
            }
            else
            {
                avgLevel = Level.Hard;
            }

            return new Quizz()
            {
                Questions = questions,
                AverageLevel = avgLevel
            };
        }

        public List<BasicQuestion> GenerateBasicQuizz(int size)
        {
            var questions = new List<BasicQuestion>();

            for (int i = 0; i < size; i++)
            {
                questions.Add(new BasicQuestion());
            }

            return questions;
        }
    }
}
