Feature: JUM-42
JUM-42 test cases

# These tests need to get re-woked, - Tanis Olesen
Scenario: Controller gets constrcuted properly
# Given main program that will declare a controller
# When the controller is created
# Then it will create a player piece
# And it will initialize its location
# And it will store it in a way that IO can access

Scenario: Controller displays all the correct varibles to the IO
# Given main program that will declare a controller and provide an IO function to the controller
# When the controller is created
# Then it will start a loop that will call the time Increase function on each piece
# and the loop will attempt to create new pieces, and store them in a way io can access
# and the loop will update the score for each player
# and the loop will tell the io to render each object

Scenario: IO does not initiate a jump, The player will not jump randomly
# Given that the io render function 
# when it returns a 0,
# then the player jump function will not be called

Scenario: IO Initates a jump, Controller starts the jump sequence for the player
# Given that the io render function 
# when it returns a 1,
# then the player jump function will be called

Scenario: Start game screen is displayed
# Given that the game has not started
# When frameupdate is called
# the IO should be told to display the pregame scene

Scenario: Enb game screen is displayed
# Given that the game has finished
# when frameupdate is called
# The IO should be told to display the post game scene.