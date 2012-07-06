Feature: Add user account to an group
# http://confluence.jetbrains.net/display/YTD4/POST+User+Group

Scenario: Add user to admin group
	Given I have created a user
 	 When I add the user to admin group
	 Then the user belongs to admin group
