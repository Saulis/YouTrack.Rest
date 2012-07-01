Feature: Get Issues in a project

Scenario: Get all Issues in a project
	Given I have created an issue
	 When I search all the issues of the project
	 Then I receive the issue

Scenario: Get Issues in a project with search
	Given I have created an issue
	 When I search for the issue with summary filter
	 Then I receive the issue
