Feature: JUM-22

    JUM-22 Tests
    
    #small rock test cases
    Scenario: JUM-22 1
		Given a player constructed at (3, 1)
		And player is jumping
		When a player frame update happens
		Then player Position y is 2

	Scenario: JUM-22 2
		Given a player constructed at (3, 1)
		And player is jumping
		When a player frame update happens
		And a player frame update happens
		Then player Position y is 3

	Scenario: JUM-22 3
		Given a player constructed at (3, 1)
		And player is jumping
		When a player frame update happens
		And a player frame update happens
		And a player frame update happens
		Then player Position y is 3

	Scenario: JUM-22 4
		Given a player constructed at (3, 1)
		And player is jumping
		When a player frame update happens
		And a player frame update happens
		And a player frame update happens
		And a player frame update happens
		Then player Position y is 2

	Scenario: JUM-22 5
		Given a player constructed at (3, 1)
		And player is jumping
		When a player frame update happens
		And a player frame update happens
		And a player frame update happens
		And a player frame update happens
		And a player frame update happens
		Then player Position y is 1

	Scenario: JUM-22 no double jump
		Given a player constructed at (3, 1)
		And player is jumping
		When a player frame update happens
		And a player frame update happens
		And player jumps again
		And a player frame update happens
		Then player Position y is 3