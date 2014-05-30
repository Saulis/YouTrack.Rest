using System;

namespace YouTrack.Rest.Exceptions
{
    public class UnexpectedMultipleFieldValuesException : Exception
    {
        public UnexpectedMultipleFieldValuesException(string message) : base(message)
        {
            
        }
    }
}
