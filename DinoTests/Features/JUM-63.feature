Feature: JUM-63
	The player object 

@mytag
Scenario: JUM-49 player Constructed correctly
		Given a player at (3, 1)
		When a player is constructed
		Then player Position x is 3
		And player Position y is 1
		And player score is set to 0

	Scenario: JUM-49 player y position is wrong
		Given a player at (3, 2)
		When a player is constructed
		Then throw exception

	Scenario: JUM-49 player y position is negative
		Given a player at (3, -1)
		When a player is constructed
		Then throw exception

	Scenario: JUM-49 player x position is wrong
		Given a player at (4, 1)
		When a player is constructed
		Then throw exception

	
	Scenario: JUM-49 player points are correct
		Given a player at (3, 1)
		When a player is constructed
		Then player score is set to 0

	Scenario: JUM-49 player frame update
		Given a player constructed at (3, 1)
		When a player frame update happens
		Then player Position x is 3
		And player Position y is 1