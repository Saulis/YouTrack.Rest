using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;
using YouTrack.Rest.Features.Steps;

namespace YouTrack.Rest.Features.Administration.Projects
{
    [Binding]
    [Scope(Feature = "Get project")]
    public class GetProjectSteps : ProjectSteps
    {
        [Given(@"I have created a new project")]
        public void GivenIHaveCreatedANewProject()
        {
            CreateProject("FOO", "foobar", 1, TestSettings.Username, "Desc");
        }

        [When(@"I fetch the project")]
        public void WhenIFetchTheProject()
        {
            //Proxy will perform the fetch when properties are used.
            string description = GetSavedProject().Description;
        }

        [Then(@"the project is fetched")]
        public void ThenTheProjectIsFetched()
        {
            IProject project = GetSavedProject();

            Assert.That(project.Name, Is.EqualTo("foobar"));
            Assert.That(project.ProjectLeadLogin, Is.EqualTo(TestSettings.Username));
            Assert.That(project.Description, Is.EqualTo("Desc"));
        }

    }
}
