using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyzerException:Exception
    {
        public enum ExceptionType
        {
            EMPTY,
            NULL,
            NO_SUCH_METHOD,
            NO_SUCH_CLASS
        }

        private ExceptionType type;
        public MoodAnalyzerException(ExceptionType type, string message):base(message)
        {
            this.type = type;
        }
    }
}
