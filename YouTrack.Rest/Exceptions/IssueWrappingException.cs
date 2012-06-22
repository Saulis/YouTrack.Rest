using System;

namespace YouTrack.Rest.Exceptions
{
    public class IssueWrappingException : Exception
    {
        public IssueWrappingException(string message) : base(message)
        {
        }
    }
}