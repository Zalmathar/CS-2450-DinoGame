Feature: JUM47

    JUM47 Test cases
	@JUM-47
	Scenario: JUM47 Bird at level 4 is deleted when it passes off screen
		Given there is a controller object
		And there is a bird located at (2, 4)
		When the next frame cycle happens
		And the next frame cycle happens
		Then an obstacle is removed from the screen

	@JUM-47
	Scenario: JUM47 Bird at level 3 is deleted when it passes off screen
		Given there is a controller object
		And there is a bird located at (2, 3)
		When the next frame cycle happens
		And the next frame cycle happens
		Then an obstacle is removed from the screen

	@JUM-47
	Scenario: JUM47 small rock is deleted when it passes off screen
		Given there is a controller object
		And there is a small rock located at (2, 1)
		When the next frame cycle happens
		And the next frame cycle happens
		Then an obstacle is removed from the screen

	@JUM-47
	Scenario: JUM47 large rock is deleted when it passes off screen
		Given there is a controller object
		And there is a large rock located at (2, 1)
		When the next frame cycle happens
		And the next frame cycle happens
		Then an obstacle is removed from the screen
