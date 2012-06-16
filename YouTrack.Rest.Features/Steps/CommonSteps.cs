using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.Steps
{
    [Binding]
    public class CommonSteps : Steps
    {
        [Given(@"I am authenticated")]
        public void GivenIAmAuthenticated()
        {
            StepHelper.InitializeYouTrackClient("http://youtrack.codebetter.com", "youtrackapi", "youtrackapi");
        }
    }
}