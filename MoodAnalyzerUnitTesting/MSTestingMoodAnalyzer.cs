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
    }
}