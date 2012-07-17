using System;

namespace YouTrack.Rest.Exceptions
{
    public class LocationHeaderCountInvalidException : Exception
    {
        internal LocationHeaderCountInvalidException(int locationHeadersCount)
            : base(String.Format("Invalid Location Header Count: {0}", locationHeadersCount))
        {
        }
    }
}