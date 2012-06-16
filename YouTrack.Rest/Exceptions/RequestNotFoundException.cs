using System;
using RestSharp;

namespace YouTrack.Rest.Exceptions
{
    internal class RequestNotFoundException : Exception
    {
        public RequestNotFoundException(IRestResponse response) : base(String.Format("Request was not found: {0}", response.Content))
        {
        }
    }
}