Feature: JUM50

    JUM50 Test cases

#big rock test cases

	Scenario: big rock Constructed correctly
		Given a big rock at (4, 1)
		When a big rock is constructed
		Then Position x is 4
		And Position y is 1
		And score is set to 10

	Scenario: JUM-50 big rock y position is wrong
		Given a big rock at (4, 2)
		When a big rock is constructed
		Then throw exception

	Scenario: JUM-50 big rock y position is negative
		Given Given a big rock at (4, -1)
		When a big rock is constructed
		Then throw exception

	Scenario: JUM-50 big rock x position is wrong
		Given a big rock at (1, 1)
		When a big rock is constructed
		Then throw exception

	Scenario: JUM-50 big rock x position is too high
		Given Given a big rock at (500, 1)
		When a big rock is constructed
		Then throw exception

	Scenario: JUM-50 big rock points are correct
		Given a big rock at (4, 1)
		When a big rock is constructed
		Then score is set to 10

	Scenario: JUM-50 big rock frame update
		Given a big rock
		When a frame update happens
		Then position x is 1 less
		And y position is the same