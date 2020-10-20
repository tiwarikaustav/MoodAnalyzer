using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    class MoodAnalyzer
    {
        string moodMessage;

        public MoodAnalyzer()
        {
            moodMessage = "";
        }

        public MoodAnalyzer(string message)
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
