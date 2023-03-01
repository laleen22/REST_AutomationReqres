Feature: CreateUser
	Create a new user

@Test
Scenario: Create a new user with given inputs
	Given User with name "Amal"
	And user with job "Manager"
	When Send request to create user
	Then Validate user is created