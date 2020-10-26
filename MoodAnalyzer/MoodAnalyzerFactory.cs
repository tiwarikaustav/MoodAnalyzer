using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyzerFactory
    {
        // className will be in format of namespace.MyClass while constructor name will be MyClass
        public static object CreateMoodAnalyzerObject(string className, string constructorName, string message)
        {
            string pattern = @"." + constructorName + "$";
            bool isMatch = Regex.IsMatch(className, pattern);
            // isMatch will be true if constructorName and className are same
            if (isMatch)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    var typeMoodAnalyzer = assembly.GetType(className);
                    //If no arguments are specified then the default constructor is invoked.
                    //Here we are passing type in arguments and no constructor name, so default constructor will be invoked
                    if (message == null)
                        return Activator.CreateInstance(typeMoodAnalyzer);
                    else
                        return Activator.CreateInstance(typeMoodAnalyzer, message);

                }
                // Catch block will execute when className is not valid
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_CLASS, "No such class exist!");
                }
            }
            else
            {
                //This block will execute when constructorName don't match with className
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "No such constructor exist!");
            }
        }
    }
}
