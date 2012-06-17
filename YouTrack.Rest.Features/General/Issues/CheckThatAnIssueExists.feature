Feature: Check that an Issue Exists

Background: 
	Given I am authenticated

Scenario: Issue does exist
	Given I have created an issue
	 When I check if the issue exists
	 Then I am told it does exist

Scenario: Issue does not exist
	Given I haven't created an issue
	 When I check if the issue exists
	 Then I am told it does not exist
