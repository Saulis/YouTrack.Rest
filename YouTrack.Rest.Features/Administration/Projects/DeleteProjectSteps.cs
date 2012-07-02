using NUnit.Framework;
using TechTalk.SpecFlow;
using YouTrack.Rest.Features.Steps;

namespace YouTrack.Rest.Features.Administration.Projects
{
    [Binding]
    [Scope(Feature = "Delete project")]
    public class DeleteProjectSteps : ProjectSteps
    {
        [Given(@"I have create a new project")]
        public void GivenIHaveCreateANewProject()
        {
            CreateProject("FOO", "bar", 1, TestSettings.Username, "desc");
        }

        [When(@"I delete the project")]
        public void WhenIDeleteTheProject()
        {
            DeleteProject("FOO");
        }

        [Then(@"the project does not exist anymore")]
        public void ThenTheProjectDoesNotExistAnymore()
        {
            Assert.IsFalse(ProjectExists("FOO"));
        }

    }
}
