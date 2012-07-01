Feature: Create New Issue

Scenario: Creating a new issue with basic parameters
	When I create a new issue to a project with summary and description
	Then an issue is created

