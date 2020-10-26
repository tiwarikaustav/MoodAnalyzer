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
            try
            {
                if(this.moodMessage == "")
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.EMPTY, "Mood should not be empty!");
                }
                else if (this.moodMessage.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                return "HAPPY";
            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NULL, "Mood should not be null!");
            }
        }
    }
}
