using System;
using RestSharp;

namespace YouTrack.Rest.Exceptions
{
    internal class InvalidAcceptHeaderCountException : Exception
    {
        public InvalidAcceptHeaderCountException(RestRequest restRequest)
        {
            throw new NotImplementedException();
        }
    }
}