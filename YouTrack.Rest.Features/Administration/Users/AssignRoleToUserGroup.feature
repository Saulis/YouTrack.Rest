Feature: Assign role to user group

Scenario: Assign role to an user group
	Given I have created an user group
	 When I assign a role to the user group
	 Then the role is assigned to the group

Scenario: Assign role to an user
	Given I have created an user
	  And I have created an user group
	 When I assign a role to the user group
	  And I add the user to the group
	 Then the role is assigned to the user
