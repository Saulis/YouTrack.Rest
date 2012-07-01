Feature: Create a new user
# http://confluence.jetbrains.net/display/YTD4/PUT+User

Scenario: Create a new user
	When I create a new user
	Then the user is created
