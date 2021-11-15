# This feature is best tested from a code review
Feature: JUM-35-GeneratingObstacles
# 	Controller Generating obstacles and adding them to the list

 Scenario: Generating small Rocks
	Given a controller that can create objects on frame update
 	When MakeObstacle has been called 10000 times
 	Then there should be close to 2.00% of the number of frameUpdates small rocks in the obstacles list

 Scenario: Generating Large Rocks
 	Given a controller that can create objects on frame update
 	When MakeObstacle has been called 10000 times
 	Then there should be close to 1.33% of the number of frameUpdates Large rocks in the obstacles list

 Scenario: Generating Birds
    Given a controller that can create objects on frame update
 	When MakeObstacle has been called 10000 times
 	Then there should be close to 1.33% of the number of frameUpdates birds in the obstacles list
    And close to 50 of those birds should be positioned at y = 4
 	And close to 50 of those birds should be positioned at y = 4
    And close to 50 of those birds should be positioned at y = 3