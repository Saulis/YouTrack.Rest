Feature: Apply Command to an Issue

Background: 
	Given I am authenticated

Scenario: Add comment to an Issue
	Given I have created an issue
	When I add a comment to the issue
	Then a comment is added to the issue
