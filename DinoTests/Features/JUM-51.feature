Feature: JUM51

    JUM51 Test cases

	#bird test cases

	Scenario: JUM-51 bird Constructed correctly
		Given a bird at (4, 4)
		When a bird is constructed
		Then Position x is 4
		And Position y is 4
		And score is set to 20

	Scenario: JUM-51 bird y position is wrong
		Given a bird at (4, 2)
		When a bird is constructed
		Then throw exception

	Scenario: JUM-51 bird y position is negative
		Given a bird at (4, -1)
		When a bird is constructed
		Then throw exception

	Scenario: JUM-51 bird x position is wrong
		Given a bird at (1, 1)
		When a bird is constructed
		Then throw exception

	Scenario: JUM-51 bird x position is too high
		Given a bird at (500, 1)
		When a bird is constructed
		Then throw exception

	Scenario: JUM-51 bird points are correct
		Given a bird at (4, 3)
		When a bird is constructed
		Then score is set to 20

	Scenario: JUM-51 bird frame update
		Given a bird constructed at (4, 4)
		When a frame update happens
		Then Position x is 3
		And Position y is 4
