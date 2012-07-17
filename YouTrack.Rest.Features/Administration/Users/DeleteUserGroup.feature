Feature: Delete user group
# http://confluence.jetbrains.net/display/YTD4/DELETE+Group

Scenario: Delete a specific user group
	Given I have created an user group
	 When I delete the user group
	 Then the user group is deleted
