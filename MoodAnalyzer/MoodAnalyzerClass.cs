using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyzerClass
    {
        string moodMessage;

        public MoodAnalyzerClass()
        {
            moodMessage = "";
        }

        public MoodAnalyzerClass(string message)
        {
            this.moodMessage = message;
        }
        public string AnalyzeMood()
        {
            if (this.moodMessage.ToLower().Contains("sad"))
            {
                return "SAD";
            }
            else return "HAPPY";
        }
    }
}
