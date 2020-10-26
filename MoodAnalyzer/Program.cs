using System;

namespace MoodAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            MoodAnalyzerClass moodAnalyzer = new MoodAnalyzerClass("I am in a sad mood");
            Console.WriteLine("Mood is: {0}", moodAnalyzer.AnalyzeMood());
        }
    }
}
