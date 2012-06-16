namespace YouTrack.Rest.Requests
{
    abstract class YouTrackRequest : IYouTrackRequest
    {
        protected RestRequestResourceBuilder ResourceBuilder { get; private set; }

        protected YouTrackRequest(string baseResource)
        {
            ResourceBuilder = new RestRequestResourceBuilder(baseResource);
        }

        public string RestResource { get { return ResourceBuilder.ToString(); } }
    }
}