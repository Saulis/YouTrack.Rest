using System;

namespace YouTrack.Rest.Requests
{
    abstract class YouTrackRequest : IYouTrackRequest
    {
        public event EventHandler Executed;

        protected void OnExecuted()
        {
            EventHandler handler = Executed;
            if (handler != null) handler(this, new EventArgs());
        }

        protected RestRequestResourceBuilder ResourceBuilder { get; private set; }

        protected YouTrackRequest(string baseResource)
        {
            ResourceBuilder = new RestRequestResourceBuilder(baseResource);
        }

        public string RestResource { get { return ResourceBuilder.ToString(); } }
    }
}