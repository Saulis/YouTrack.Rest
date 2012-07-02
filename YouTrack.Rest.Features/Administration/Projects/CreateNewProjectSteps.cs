using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;
using YouTrack.Rest.Features.Steps;

namespace YouTrack.Rest.Features.Administration.Projects
{
    [Binding]
    [Scope(Feature = "Create new project")]
    public class CreateNewProjectSteps : ProjectSteps
    {
        [When(@"I create a new project")]
        public void WhenICreateANewProject()
        {
            CreateProject("foo", "projectName", 1, TestSettings.Username, "description");
        }


        [Then(@"the project is created")]
        public void ThenTheProjectIsCreated()
        {
            Assert.That(ProjectExists("foo"));
        }

    }
}
