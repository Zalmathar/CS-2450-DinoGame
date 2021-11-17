// Tanis Olesen
// 11/5/2021
// Controlls the behavior of the game
using System;
// Only used for Thread.sleep
using System.Threading;
using System.Collections.Generic;

namespace DinoClassLib
{
    public class Controller
    {

        // Represents the player
        public Player player = new Player(3, 1);

        public List<IPiece> Obstacles { get; set; }

        public IO io { private get; set; }


        // Represents the current score the player of the game has achieved. 
        public int score { get; set; }


        //represesnts the display size in the x direction. should be set on frame update by the returned value of the IO
        private int displayXsize = 50;

        // Represents the states the game can be in
        public enum status
        {
            // In the pre game state, a screen should be generated that has the player and no other objects. When one of the jump keys in pressed. The game starts
            pre,

            // In the running state, The player is able to jump, obsticals get randomly generated and move toward the left of the screen.
            running,

            // In the dead state. The total score of the game is showed. When one of the jump keys is pressed. The game re-starts
            dead
        }

        // Represents the current state of the game
        public status gameState;


        // Constructs the starting state of the game.
        public Controller(IO io)
        {
            Obstacles = new List<IPiece>();
            score = 0;
            // TODO: Start the game in the pre game state, Create the player, and let the IO render the screen. When one of the jump keys is received start the game.
            this.gameState = status.pre;
            this.io = io;
        }

        // Generates a new game state representing the next frame. 
        public void FrameUpdate()
        {
            IOReturner ioResult = io.render(this);

            //IF the game is not running, render the screen, if input is recieved change the game state to start, but do nothing else.. 
            if (gameState != status.running)
            {
                if (ioResult.inputDetected)
                {
                    gameState = status.running;
                }
                return;
            }

            bool dodge = false;
            List<int> delList = new List<int>();

            //I realize this still not ideal.
            player.Jump(ioResult.inputDetected);

            // Want to update player before the pieces for CheckCollision to work
            player.onFrameUpdate();
            for (int i = 0; i < Obstacles.Count; i++)
            {
                IPiece piece = Obstacles[i];
                piece.onFrameUpdate();
                if (CheckCollision(piece) == true)
                {
                    gameState = status.dead;
                    // TODO: Display the end game card
                }
                if (piece.position.getX() == 3 && !CheckCollision(piece))
                {
                    //increase the score for dodging an obstacle
                    score += piece.pointVal;
                    dodge = true;
                }
                if (piece.position.getX() <= 1)
                {
                    // Mark the obstacle to be deleted
                    delList.Add(i);
                }
            }
            if (!dodge)
            {
                //increments the score by one for every tile traveled that's not dodging an obstacle
                score++;
            }


            DeleteObstacle(delList);
            MakeObstacle();

            // TODO: Display the game state to the user.
            ioResult = io.render(this);

        }

        // Checks an obstacle against the players position to determin if a collision has been detected.
        // When this returns false, in frame update, we will want to change the games running state
        private bool CheckCollision(IPiece _obstacle)
        {
            if (_obstacle.position.getX() != player.position.getX())
            {
                return false;
            }
            else
            {
                for (int i = 0; i < _obstacle.ySize; i++)
                {
                    if (player.position.getY() == _obstacle.position.getY() + i || player.position.getY() + 1 == _obstacle.position.getY() + i)
                    {
                        return true;
                    }
                }
                return false;
            }
            throw new Exception("CheckCollision Failed");
        }

        // Randomly creates obstacles that are then stored in the obstacle list. Has a chance of not creating any obstacle's
        private void MakeObstacle()

        {
            Random RNG = new Random();

            //1-50 Chance of the obstacle being a small rock
            if (RNG.Next(50) == 1)
            {
                Obstacles.Add(new SmallRock(new Position(displayXsize, 1)));
            }
            //1-75 Chance of the obstacle being a large rock
            else if (RNG.Next(75) == 1)
            {
                Obstacles.Add(new BigRock(new Position(displayXsize, 1)));
            }
            //1-100 Chance of the obstacle being a bird
            else if (RNG.Next(100) == 1)
            {
                Obstacles.Add(new Bird(new Position(displayXsize, RNG.Next(2) + 3)));
            }
        }

        // When an obsticale has reached the minimum it can be (Far left of the view). Remove each obsticale that has reached the end of the screen
        private void DeleteObstacle(List<int> delThese)
        {
            for (int i = delThese.Count; i > 0; i--)
            {
                Obstacles.RemoveAt(delThese[i - 1]);
            }
        }

        public void runGame()
        {
            IOReturner ioResult;
            double fps = (double)IO.maxFPS;
            while (true)
            {
                if ((gameState == status.pre) || (gameState == status.dead))
                {
                    ioResult = io.render(this);
                    if (ioResult.inputDetected == true)
                    {
                        // Reset the score
                        score = 0;
                        // Reset the obstacle list
                        Obstacles = new List<IPiece>();
                        // Reset the player
                        player = new Player(3, 1);
                        gameState = status.running;
                    }
                    FrameLimiter(fps);
                }
                
                else if (gameState == status.running)
                {
                    while (gameState == status.running)
                    {
                        FrameLimiter(fps);
                        FrameUpdate();
                    }
                }
            }

            void FrameLimiter(double fps)
            {
                double info = 1 / fps;
                info *= 2000;
                Thread.Sleep((int)info);
            }
        }
    }
}
