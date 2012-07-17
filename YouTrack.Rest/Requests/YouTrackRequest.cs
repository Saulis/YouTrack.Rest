namespace YouTrack.Rest.Requests
{
    abstract class YouTrackRequest : IYouTrackRequest
    {
        protected RestRequestResourceBuilder ResourceBuilder { get; private set; }

        protected YouTrackRequest(string resourceBase)
        {
            ResourceBuilder = new RestRequestResourceBuilder(resourceBase);
        }

        public string RestResource { get { return ResourceBuilder.ToString(); } }

        public bool HasBody
        {
            get { return Body != null; }
        }

        public object Body { get; internal set; }
    }
}