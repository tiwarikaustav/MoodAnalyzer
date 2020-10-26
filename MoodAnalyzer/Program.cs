using System;

namespace MoodAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            MoodAnalyzerClass moodAnalyzer = new MoodAnalyzerClass();
            Console.WriteLine("Mood is: {0}", moodAnalyzer.AnalyzeMood());
        }
    }
}
