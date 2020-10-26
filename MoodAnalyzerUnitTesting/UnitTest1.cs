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
            Assert.AreEqual(shouldBe, actual, false);
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
    }
}
