Feature: Get all groups the specified user participates in
# http://confluence.jetbrains.net/display/YTD4/GET+User+Groups

Scenario: Created user belongs to new users
	Given I have created a user
 	 When I fetch the users groups
	 Then the user belongs to new users group
