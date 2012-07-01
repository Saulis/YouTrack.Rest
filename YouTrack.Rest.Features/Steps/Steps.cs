using TechTalk.SpecFlow;
using System.Linq;

namespace YouTrack.Rest.Features.Steps
{
    public class Steps
    {
        protected StepHelper StepHelper
        {
            get { return ScenarioContext.Current.Get<StepHelper>(); }
        }

        [BeforeScenario]
        public virtual void Setup()
        {
            ScenarioContext.Current.Set(new StepHelper());

            if (!ScenarioContext.Current.ScenarioInfo.Tags.Contains("unauthenticated"))
            {
                StepHelper.InitializeYouTrackClient(TestSettings.BaseUrl, TestSettings.Username, TestSettings.Password);
            }
        }

    }
}