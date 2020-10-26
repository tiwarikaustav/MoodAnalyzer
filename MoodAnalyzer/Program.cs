using System;

namespace MoodAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ///using Reflection to create instance of MoodAnalyzer
                MoodAnalyzerClass moodAnalyzer = (MoodAnalyzerClass)MoodAnalyzerFactory.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzerClass", "MoodAnalyzerClass", "sad");
                Console.WriteLine("Mood is: {0}", moodAnalyzer.AnalyzeMood());
            }
            catch(MoodAnalyzerException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
