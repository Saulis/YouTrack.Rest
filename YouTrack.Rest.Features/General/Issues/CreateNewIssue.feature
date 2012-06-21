Feature: Create New Issue

Background: 
	Given I am authenticated 

Scenario: Creating a new issue with basic parameters
	When I create a new issue to a project with summary and description
	Then an issue is created

@ignore
Scenario: Creating a new issue with attachments
	When I create a new issue to a project with attachments
	Then an issue is created with attachments
