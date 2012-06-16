Feature: Deleting an issue

Background: 
	Given I am authenticated

Scenario: Deleting an issue
	Given I have created an issue
	 When I delete the issue
	 Then the issue is deleted
