Feature: JUM50

    JUM50 Test cases

#big rock test cases

	Scenario: big rock Constructed correctly
		Given a big rock at (4, 1)
		When a big rock is constructed
		Then big Position x is 4
		And big Position y is 1
		And big score is set to 10

	Scenario: JUM-50 big rock y position is wrong
		Given a big rock at (4, 2)
		When a big rock is constructed
		Then throw exception

	Scenario: JUM-50 big rock y position is negative
		Given a big rock at (4, -1)
		When a big rock is constructed
		Then throw exception

	Scenario: JUM-50 big rock x position is wrong
		Given a big rock at (1, 1)
		When a big rock is constructed
		Then throw exception

	Scenario: JUM-50 big rock x position is too high
		Given a big rock at (500, 1)
		When a big rock is constructed
		Then throw exception

	Scenario: JUM-50 big rock points are correct
		Given a big rock at (4, 1)
		When a big rock is constructed
		Then big score is set to 10

	Scenario: JUM-50 big rock frame update
		Given a big rock constructed at (4, 1)
		When a big frame update happens
		Then big Position x is 3
		And big Position y is 1