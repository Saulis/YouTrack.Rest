Feature: Get user roles
# http://confluence.jetbrains.net/display/YTD4/GET+User+Roles

Scenario: Get user roles
	Given I have created an user
	 When I fetch the user
	 Then the user should have roles
