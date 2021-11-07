Feature: JUM47

    JUM47 Test cases
	@JUM-47
	Scenario: JUM47 Bird at level 4 is deleted when it passes off screen
		Given there is a bird located at (1, 4)
		When the next frame cycle happens
		Then the bird is removed from the screen

	@JUM-47
	Scenario: JUM47 Bird at level 3 is deleted when it passes off screen
		Given there is a bird located at (1, 3)
		When the next frame cycle happens
		Then the bird is removed from the screen

	@JUM-47
	Scenario: JUM47 small rock 3 is deleted when it passes off screen
		Given there is a small rock located at (1, 1)
		When the next frame cycle happens
		Then the bird is removed from the screen

	@JUM-47
	Scenario: JUM47 large rock is deleted when it passes off screen
		Given there is a large rock located at (1, 1)
		When the next frame cycle happens
		Then the bird is removed from the screen
