using System;
using RestSharp;

namespace YouTrack.Rest.Exceptions
{
    public class RequestFailedException : Exception
    {
        internal RequestFailedException(IRestResponse response) : base(String.Format("Request {0} [{1}] failed: {2}", response.Request.Method, response.Request.Resource, response.Content))
        {
            
        }
    }
}