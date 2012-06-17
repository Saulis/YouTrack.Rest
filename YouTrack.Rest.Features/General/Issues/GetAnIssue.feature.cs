﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.8.1.0
//      SpecFlow Generator Version:1.8.0.0
//      Runtime Version:4.0.30319.269
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace YouTrack.Rest.Features.General.Issues
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.8.1.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Get an Issue")]
    public partial class GetAnIssueFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetAnIssue.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Get an Issue", "", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
#line 4
 testRunner.Given("I am authenticated");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Getting a single issue")]
        public virtual void GettingASingleIssue()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting a single issue", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 7
 testRunner.Given("I have created an issue");
#line 8
 testRunner.When("I request the issue");
#line 9
 testRunner.Then("the issue is returned");
#line 10
  testRunner.And("it has the default fields set");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Getting a single issue with comments")]
        [NUnit.Framework.CategoryAttribute("wip")]
        public virtual void GettingASingleIssueWithComments()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting a single issue with comments", new string[] {
                        "wip"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 14
 testRunner.Given("I have created an issue");
#line 15
   testRunner.And("I have given it a comment");
#line 16
  testRunner.When("I request the issue");
#line 17
  testRunner.Then("it has the comment set");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Getting a single issue with attachments")]
        [NUnit.Framework.CategoryAttribute("wip")]
        public virtual void GettingASingleIssueWithAttachments()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting a single issue with attachments", new string[] {
                        "wip"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 21
 testRunner.Given("I have created an issue with an attachment");
#line 22
  testRunner.When("I request the issue");
#line 23
  testRunner.Then("it has the attachment set");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Getting a single issue with links")]
        [NUnit.Framework.CategoryAttribute("wip")]
        public virtual void GettingASingleIssueWithLinks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting a single issue with links", new string[] {
                        "wip"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 27
 testRunner.Given("I have created an issue");
#line 28
   testRunner.And("I have linked it to another issue");
#line 29
  testRunner.When("I request the issue");
#line 30
  testRunner.Then("it has the link to another issue");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Getting a single issue with multiple fix versions")]
        [NUnit.Framework.CategoryAttribute("wip")]
        public virtual void GettingASingleIssueWithMultipleFixVersions()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting a single issue with multiple fix versions", new string[] {
                        "wip"});
#line 33
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 34
 testRunner.Given("I have created an issue");
#line 35
   testRunner.And("I have added two fix versions to it");
#line 36
  testRunner.When("I request the issue");
#line 37
  testRunner.Then("the issue has both fix versions");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
