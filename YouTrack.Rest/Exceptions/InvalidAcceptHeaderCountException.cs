using System;
using RestSharp;

namespace YouTrack.Rest.Exceptions
{
    public class InvalidAcceptHeaderCountException : Exception
    {
        internal InvalidAcceptHeaderCountException(RestRequest restRequest)
        {
            throw new NotImplementedException();
        }
    }
}