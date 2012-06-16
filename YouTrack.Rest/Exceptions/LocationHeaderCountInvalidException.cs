using System;
using System.Collections.Generic;
using RestSharp;

namespace YouTrack.Rest.Exceptions
{
    internal class LocationHeaderCountInvalidException : Exception
    {
        public LocationHeaderCountInvalidException(IList<Parameter> headers)
        {
            throw new NotImplementedException();
        }
    }
}