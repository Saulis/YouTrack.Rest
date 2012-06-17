Feature: Create New Issue

Background: 
	Given I am authenticated 

Scenario: Creating a new issue with basic parameters
	When I create a new issue to a project with summary and description
	Then an issue is created

@wip
Scenario: Creating a new issue with group restrictions
	When I create a new issue to a project with permitted group
	Then an issue is created with group permissions

@wip
Scenario: Creating a new issue with attachments
	When I create a new issue to a project with attachments
	Then an issue is created with attachments
