namespace YouTrack.Rest.Requests
{
    abstract class YouTrackRequest : IYouTrackRequest
    {
        protected RestRequestResourceBuilder ResourceBuilder { get; private set; }

        protected YouTrackRequest(string projectId)
        {
            ResourceBuilder = new RestRequestResourceBuilder(projectId);
        }

        public string RestResource { get { return ResourceBuilder.ToString(); } }
    }
}