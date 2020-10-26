using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzer;

namespace MoodAnalyzerUnitTesting
{
    [TestClass]
    public class MoodAnalyzerUnitTesting
    {
        private MoodAnalyzerClass moodAnalyzer = null;

        [TestInitialize]
        public void initialSetup()
        {
            moodAnalyzer = new MoodAnalyzerClass("sad");
        }

        [TestMethod]
        [DataRow("I am in sad mood")]
        public void GivenSadReturnSad(string message)
        {
            //Arrange
            moodAnalyzer = new MoodAnalyzerClass(message);
            //Act
            string shouldBe = "sad";
            string actual = moodAnalyzer.AnalyzeMood();
            //Assert
            Assert.AreEqual(shouldBe, actual, true);
        }

        [TestMethod]
        [DataRow("I am in any mood")]
        public void GivenAnyMoodReturnHappy(string message)
        {
            //Arrange
            moodAnalyzer = new MoodAnalyzerClass(message);
            //Act
            string shouldBe = "happy";
            string actual = moodAnalyzer.AnalyzeMood();
            //Assert
            Assert.AreEqual(shouldBe, actual, true);
        }

        [TestMethod]
        [DataRow(null)]
        public void GivenNullString(string message)
        {
            try
            {
                //Arrange
                moodAnalyzer = new MoodAnalyzerClass(message);
            }
            catch(MoodAnalyzerException e)
            {
                //Act
                string shouldBe = e.Message;
                string actual = moodAnalyzer.AnalyzeMood();
                //Assert
                Assert.AreEqual(shouldBe, actual, true);
            }
        }

        [TestMethod]
        [DataRow("")]
        public void GivenEmptyString(string message)
        {
            try
            {
                //Arrange
                moodAnalyzer = new MoodAnalyzerClass(message);
            }
            catch (MoodAnalyzerException e)
            {
                //Act
                string shouldBe = e.Message;
                string actual = moodAnalyzer.AnalyzeMood();
                //Assert
                Assert.AreEqual(shouldBe, actual, true);
            }
        }

        [TestMethod]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer")]
        public void GivenClassNameCreateDefaultObjectUsingReflection(string className, string constructorName)
        {
            //Arrange
            //Act
            object expected = new MoodAnalyzerClass();
            object actual = MoodAnalyzerFactory.CreateMoodAnalyzerObject(className, constructorName);
            //Assert
            Assert.AreEqual(expected.GetType(), actual.GetType()); 
        }

        [TestMethod]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer1")]
        public void GivenImproperClassNameThrowNoSuchClassException(string className, string constructorName)
        {
            try
            {
                //Arrange
                object actual = MoodAnalyzerFactory.CreateMoodAnalyzerObject(className, constructorName);
            }
            catch (MoodAnalyzerException e)
            {
                //Act
                string actual = e.Message;
                string expected = "No such class exist!";
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer1")]
        public void GivenConstructorNameImproper_ThrowNoSuchMethodException(string className, string constructorName)
        {
            try
            {
                //Arrange
                object actual = MoodAnalyzerFactory.CreateMoodAnalyzerObject(className, constructorName);
            }
            catch (MoodAnalyzerException e)
            {
                //Act
                string actual = e.Message;
                string expected = "No such constructor exist!";
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", "I am in Sad Mood", "sad")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", "I am in Happy Mood", "happy")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", "", "Mood Should not be empty!")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", null, "Mood Should not be null!")]
        public void GivenClassName_CreateParamterizedObjectUsingReflection(string className, string constructorName, string message, string expected)
        {
            try
            {
                //Arrange
                moodAnalyzer = (MoodAnalyzerClass)MoodAnalyzerFactory.CreateMoodAnalyzerObject(className, constructorName, message);
                //Act
                string actual = moodAnalyzer.AnalyseMood();
                //Assert
                Assert.AreEqual(expected, actual);
            }
            catch (MoodAnalyzerException ex)
            {
                //Act
                string actual = ex.Message;
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer1", "I am in Sad Mood")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer1", "I am in Happy Mood")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer1", "")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer1", null)]
        public void GivenClassNameImproper_ParameterizedConstructorThrowNoSuchClassException(string className, string constructorName, string message)
        {
            try
            {
                //Arrange
                object actual = MoodAnalyzerFactory.CreateMoodAnalyzerObject(className, constructorName, message);
            }
            catch (MoodAnalyzerException e)
            {
                //Act
                string actual = e.Message;
                string expected = "No such class exist!";
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer", "I am in Sad Mood")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer", "I am in Happy Mood")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer", "")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer", null)]
        public void GivenConstructorNameImproper_ParameterizedConstructorThrowNoSuchMethodException(string className, string constructorName, string message)
        {
            try
            {
                //Arrange
                object actual = MoodAnalyzerFactory.CreateMoodAnalyzerObject(className, constructorName, message);
            }
            catch (MoodAnalyzerException ex)
            {
                //Act
                string actual = ex.Message;
                string expected = "No such constructor exist!";
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }
    }
}