Feature: Get User (admin)
# http://confluence.jetbrains.net/display/YTD4/GET+User

@wip
Scenario: Get an existing user
	Given I have added an user
	 When I fetch the user
	 Then user is fetched
