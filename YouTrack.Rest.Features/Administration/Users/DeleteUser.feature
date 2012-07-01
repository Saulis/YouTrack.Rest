Feature: Delete User
# http://confluence.jetbrains.net/display/YTD4/DELETE+User

Scenario: Delete a specific user
	Given I have create a user
	 When I delete the user
	 Then the user is deleted
