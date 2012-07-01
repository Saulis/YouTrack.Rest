Feature: Get User (admin)

Scenario: Get an existing user
	Given I have added an user
	 When I fetch the user
	 Then user is fetched
