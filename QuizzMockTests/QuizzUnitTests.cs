using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QuizzMock;
using QuizzMock.Model;

namespace QuizzMockTests
{
    [TestClass]
    public class QuizzUnitTests
    {
        [TestMethod]
        [DataRow(0)]
        [DataRow(15)]
        [DataRow(20)]
        public void QuizzFactory_GenerateBasicQuizz_RetourneListeDeQuestions(int nb)
        {            
            // Arrange
            var quizz = new QuizzFactory();

            // Act
            var questions = quizz.GenerateBasicQuizz(nb);

            // Assert
            Assert.AreEqual(nb, questions.Count());
        }

        [TestMethod]
        public void QuizzFactory_GenerateEasyQuizz_RetourneEasyLevel()
        {
            // Arrange            
            //1. Créer un objet de type ILevelProvider
            var levelProvider = Mock.Of<ILevelProvider>();            
            //2. Lui donner le comportement et retour souhaité
            Mock.Get(levelProvider).Setup(m => m.GetLevel()).Returns(Level.Easy);    

            var quizz = new QuizzFactory(levelProvider);

            // Act
            var newQuizz = quizz.GenerateQuizz(15);

            // Assert
            Assert.AreEqual(Level.Easy, newQuizz.AverageLevel);
        }

        [TestMethod]
        [DataRow(Level.Easy)]
        [DataRow(Level.Medium)]
        [DataRow(Level.Hard)]
        public void QuizzFactory_GenerateQuizz_RetourneRightLevelQuizz(Level lvl)
        {
            // Arrange
            var levelProvider = Mock.Of<ILevelProvider>();
            Mock.Get(levelProvider).Setup(m => m.GetLevel()).Returns(lvl);

            var quizz = new QuizzFactory(levelProvider);

            // Act
            var newQuizz = quizz.GenerateQuizz(15);

            // Assert
            Assert.AreEqual(lvl, newQuizz.AverageLevel);
        }

        [TestMethod]
        public void Subscription_CreateSuccess()
        {
            // Arrange
            var userService = Mock.Of<IUserService>();
            Mock.Get(userService).Setup(m => m.CreateUser(It.IsAny<User>())).Returns(new Guid());

            var subscription = new Subscription(userService);

            // Act
            var result = subscription.HasSubscribed("toto", "toto", "toto");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]        
        public void Subscription_CreateFail()
        {
            // Arrange
            var userService = Mock.Of<IUserService>();
            Mock.Get(userService).Setup(m => m.CreateUser(It.IsAny<User>())).Throws(new Exception());

            var subscription = new Subscription(userService);

            // Act
            var result = subscription.HasSubscribed(string.Empty, "toto", "toto");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        [ExpectedException(typeof(Exception))]
        public void UserService_CreateUserFail(string usrname)
        {
            // Arrange            
            var user = new User()
            {
                UserName = usrname,
                Firstname = "John",
                LastName = "Smith"
            };
            var usrService = new UserService();

            // Act
            usrService.CreateUser(user);                       
        }

        [TestMethod]            
        public void UserService_CreateUserSuccess()
        {
            // Arrange            
            var user = new User()
            {
                UserName = "j.smith",
                Firstname = "John",
                LastName = "Smith"
            };
            var usrService = new UserService();

            // Act
            var result = usrService.CreateUser(user);

            // Assert 
            Assert.IsInstanceOfType(result, typeof(Guid));            
        }
    }













}
