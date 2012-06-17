Feature: Get an Issue

Background: 
	Given I am authenticated

Scenario: Getting a single issue
	Given I have created an issue
	When I request the issue
	Then the issue is returned
