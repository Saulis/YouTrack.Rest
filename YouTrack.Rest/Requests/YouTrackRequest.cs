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
    }
}