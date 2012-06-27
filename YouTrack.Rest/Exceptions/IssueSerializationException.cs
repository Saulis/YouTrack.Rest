using System;

namespace YouTrack.Rest.Exceptions
{
    public class IssueSerializationException : Exception
    {
        public IssueSerializationException(string message) : base(message)
        {
        }
    }
}