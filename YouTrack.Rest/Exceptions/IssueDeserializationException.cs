using System;

namespace YouTrack.Rest.Exceptions
{
    public class IssueDeserializationException : Exception
    {
        public IssueDeserializationException(string message) : base(message)
        {
        }
    }
}