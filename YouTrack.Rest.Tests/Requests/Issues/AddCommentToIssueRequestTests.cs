using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest.Tests.Requests.Issues
{
    class AddCommentToIssueRequestTests :  YouTrackRequestTests<AddCommentToIssueRequest, IYouTrackPostRequest>
    {
        protected override AddCommentToIssueRequest CreateSut()
        {
            return new AddCommentToIssueRequest("FOO-BAR", "foobar!");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/issue/FOO-BAR/execute?comment=foobar!"; }
        }

        class WithGroup  : YouTrackRequestTests<AddCommentToIssueRequest, IYouTrackPostRequest>
        {
            protected override AddCommentToIssueRequest CreateSut()
            {
                return new AddCommentToIssueRequest("FOO-BAR", "foobar!", "visibility");
            }

            protected override string ExpectedRestResource
            {
                get { return "/rest/issue/FOO-BAR/execute?comment=foobar!&group=visibility"; }
            }
        }
    }

   
}
