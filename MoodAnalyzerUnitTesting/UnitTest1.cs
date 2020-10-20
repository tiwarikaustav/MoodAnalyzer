using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzer;

namespace MoodAnalyzerUnitTesting
{
    [TestClass]
    public class MoodAnalyzerUnitTesting
    {
        private MoodAnalyzer moodAnalyzer = null;

        [TestInitialize]
        public void InitialSetup()
        {
            moodAnalyzer = new MoodAnalyzer("sad");
        }

        [TestMethod]
        [DataRow("I am in sad mood")]
        public void GivenSad_ReturnSad(string message)
        {

        }
    }
}
