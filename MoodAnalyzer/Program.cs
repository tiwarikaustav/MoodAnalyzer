using System;

namespace MoodAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MoodAnalyzerClass moodAnalyzer = new MoodAnalyzerClass("");
                Console.WriteLine("Mood is: {0}", moodAnalyzer.AnalyzeMood());
            }
            catch(MoodAnalyzerException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
