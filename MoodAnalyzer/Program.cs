using System;

namespace MoodAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer("I am in a sad mood");
            Console.WriteLine("Mood is: {0}", moodAnalyzer.AnalyzeMood());
        }
    }
}
