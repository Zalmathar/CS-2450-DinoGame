Feature: JUM49

    JUM49 Test cases

    Scenario: JUM-49 small rock Constructed correctly
		Given a small rock at (4, 1)
		When a small rock is constructed
		Then Position x is 4
		And Position y is 1
		And score is set to 8

	Scenario: JUM-49 small rock y position is wrong
		Given a small rock at (4, 2)
		When a small rock is constructed
		Then throw exception

	Scenario: JUM-49 small rock y position is negative
		Given Given a small rock at (4, -1)
		When a small rock is constructed
		Then throw exception

	Scenario: JUM-49 small rock x position is wrong
		Given a small rock at (1, 1)
		When a small rock is constructed
		Then throw exception

	Scenario: JUM-49 small rock x position is too high
		Given Given a small rock at (500, 1)
		When a small rock is constructed
		Then throw exception

	Scenario: JUM-49 small rock points are correct
		Given a small rock at (4, 1)
		When a small rock is constructed
		Then score is set to 8

	Scenario: JUM-49 small rock frame update
		Given a small rock
		When a frame update happens
		Then position x is 1 less
		And y position is the same



