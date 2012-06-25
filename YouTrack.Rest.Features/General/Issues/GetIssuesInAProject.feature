Feature: Get Issues in a project

Background: 
	Given I am authenticated

Scenario: Get Issues in a project with search
	Given I have created an issue
	 When I search for the issue with summary filter
	 Then I receive the issue
