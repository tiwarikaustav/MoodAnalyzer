using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    class MoodAnalyzerException:Exception
    {
        public enum ExceptionType
        {
            EMPTY,
            NULL
        }

        private ExceptionType type;
        public MoodAnalyzerException(ExceptionType type, string message):base(message)
        {
            this.type = type;
        }
    }
}
