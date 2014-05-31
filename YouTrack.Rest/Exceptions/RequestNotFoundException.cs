using System;
using RestSharp;

namespace YouTrack.Rest.Exceptions
{
    public class RequestNotFoundException : Exception
    {
        internal RequestNotFoundException(IRestResponse response) : base(String.Format("Request was not found: '{0}'", response.Content))
        {
        }
    }
}