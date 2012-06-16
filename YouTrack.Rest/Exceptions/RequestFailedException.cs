using System;
using RestSharp;

namespace YouTrack.Rest.Exceptions
{
    internal class RequestFailedException : Exception
    {
        public RequestFailedException(IRestResponse response) : base(String.Format("Request failed: {0}", response.Content))
        {
            
        }
    }
}