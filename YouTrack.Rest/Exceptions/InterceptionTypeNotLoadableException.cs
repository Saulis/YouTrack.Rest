using System;

namespace YouTrack.Rest.Exceptions
{
    public class InterceptionTypeNotLoadableException : Exception
    {
        public InterceptionTypeNotLoadableException() : base("Type mismatch while intercepting, target was not ILoadable.")
        {
            
        }
    }
}