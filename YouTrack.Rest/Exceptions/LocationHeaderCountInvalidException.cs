using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace YouTrack.Rest.Exceptions
{
    internal class LocationHeaderCountInvalidException : Exception
    {
        public LocationHeaderCountInvalidException(IEnumerable<Parameter> headers) : base(String.Format("Invalid Location Header Count: {0}", headers.Count()))
        {
        }
    }
}