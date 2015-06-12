using System.Linq;

namespace YouTrack.Rest.Requests.Issues
{
    class SearchRequest : YouTrackRequest, IYouTrackGetRequest
    {
        public SearchRequest(string query, string[] withFields = null, int max = -1, int from = -1)
            : base("/rest/issue")
        {
            if (!string.IsNullOrWhiteSpace(query))
                ResourceBuilder.AddParameter("filter", query);

            if (null != withFields)
            {
                withFields = withFields.Where(f => !string.IsNullOrWhiteSpace(f))
                                       .Select(f => f.Trim())
                                       .ToArray();

                if (withFields.Length > 0)
                    ResourceBuilder.AddMultiValueParameter("with", withFields);
            }

            if (max > 0)
                ResourceBuilder.AddParameter("max", max.ToString());
            if (from >= 0)
                ResourceBuilder.AddParameter("from", from.ToString());
        }
    }
}