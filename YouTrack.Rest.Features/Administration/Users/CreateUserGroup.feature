Feature: Create user group
# http://confluence.jetbrains.net/display/YTD4/PUT+Group

Scenario: Create a new user group
   Given I have created an user
	When I have created an user group
	 And I add the user to the group
	Then the user group is created
