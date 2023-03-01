Feature: GetSingleUser
	Get a Single User when id is given 

@Test
Scenario: Retrive a user when gievn with is

	Given user with id "2"
	When Send request to get single user
	Then Validate single user is received