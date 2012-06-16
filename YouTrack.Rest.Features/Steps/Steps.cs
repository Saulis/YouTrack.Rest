using TechTalk.SpecFlow;

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
        }

    }
}