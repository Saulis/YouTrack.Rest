Feature: Delete an Issue

Background: 
	Given I am authenticated

Scenario: Deleting an existing issue
	Given I have created an issue
	 When I delete the issue
	 Then the issue is deleted
