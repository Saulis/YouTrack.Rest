using System;
using RestSharp;

namespace YouTrack.Rest.Exceptions
{
    public class RequestFailedException : Exception
    {
        internal RequestFailedException(IRestResponse response) : base(String.Format("Request failed: {0}", response.Content))
        {
            
        }
    }
}