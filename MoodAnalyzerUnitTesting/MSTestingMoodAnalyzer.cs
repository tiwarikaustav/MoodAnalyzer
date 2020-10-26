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
                string shouldBe = "Mood should not be null!";
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
                string shouldBe = "Mood should not be empty!";
                string actual = moodAnalyzer.AnalyzeMood();
                //Assert
                Assert.AreEqual(shouldBe, actual, true);
            }
        }
    }
}