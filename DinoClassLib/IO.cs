using System;

/// <summary>

namespace DinoClassLib
{
    public class IO
    {
        private static int maxScreenXsize = 50;
        private static int maxFPS = 60;
        Pixel[,] Screen = new Pixel[maxScreenXsize, 6];
        private bool checkInput()
        {
            ConsoleKeyInfo cki;
            cki = Console.ReadKey(true);
            if (cki.Key.ToString() == "UpArrow" || cki.Key.ToString() == "Spacebar" || cki.Key.ToString() == "W")
            {
                return true;
            }
            return false;
        }

        public IOReturner render(Controller ConsoleController)
        {
            //Paint the backdrop
            for (int yi = 5; yi >= 0; yi--)
            {
                for (int xi = 0; xi < maxScreenXsize; xi++)
                {
                    switch (yi)
                    {
                        case 6:
                            Screen[xi, yi].backgroundColor = ConsoleColor.Blue;
                            break;
                        case 0:
                            Screen[xi, yi].backgroundColor = ConsoleColor.Green;
                            break;
                        default:
                            Screen[xi, yi].backgroundColor = ConsoleColor.Blue;
                            break;
                    }
                }
            }

            //Set colors that should be different from default, making sure to stay within bounds.
            switch (ConsoleController.gameState)
            {
                case Controller.status.pre: //TODO: Impliment a pregame render
                    Console.WriteLine("Welcome to the dinosaur game!");
                    Console.WriteLine("Please press up, 'w' or the space bar to begin");
                    
                    break;
                case Controller.status.running: //TODO:
                    // Add player to screen
                    for (int i = 1; i < ConsoleController.player.ySize; i++)
                    {
                        // Player Safety check
                        if((ConsoleController.player.position.getX() != 3) || (ConsoleController.player.position.getY() > 3) || (ConsoleController.player.position.getY() < 1))
                        {
                            throw new Exception("Attempted to display a player at an invalid position");
                        }
                        // Create new pixel with formating for player
                        Pixel playerPixel = new Pixel();
                        playerPixel.foregroundColor = ConsoleColor.Black;
                        playerPixel.backgroundColor = ConsoleColor.Blue;
                        playerPixel.text = "||";
                        // overwrite the existing pixel with our new pixel at the correct position.
                        Screen[ConsoleController.player.position.getX(), i + ConsoleController.player.position.getY()] = playerPixel;
                    }

                    // Add controller to screen
                    foreach (IPiece obst in ConsoleController.Obstacles)
                    {
                        //Obstacle X and Y safety Checks
                        if((obst.position.getX() > maxScreenXsize) || (obst.position.getX() < 0) || (obst.position.getY() > 4) || (obst.position.getY() < 1))
                        {
                            throw new Exception("Attempted to display an obstacle at an invalid position");
                        }

                        Pixel obstPixel = new Pixel();
                        obstPixel.foregroundColor = ConsoleColor.Black;
                        obstPixel.backgroundColor = ConsoleColor.Blue;
                        Type obsType = obst.GetType();
                        if (obsType.Equals(typeof(Bird)))
                        {
                            obstPixel.text = "< ";
                        }
                        else if (obsType.Equals(typeof(SmallRock)) || obsType.Equals(typeof(BigRock)))
                        {
                            obstPixel.text = "XX";
                        }
                        else
                        {
                            // Obst is of an Invalid type
                            throw new Exception("Controller obstacle list contains an object type not supported");
                        }
                        for (int i = 1; i < obst.ySize; i++)
                        {
                            Screen[obst.position.getX(), i + obst.position.getY()] = obstPixel;
                        }
                    }
                    break;
                case Controller.status.dead:
                    Console.Clear();
                    Console.WriteLine($"Youre final score is {ConsoleController.score}");
                    Console.WriteLine("Please play again.");
                    break;
            }

            //Render screen
            for (int yi = 5; yi >= 0; yi--)
            {
                for (int xi = 0; xi < maxScreenXsize - 1; xi++)
                {
                    Console.BackgroundColor = Screen[xi, yi].backgroundColor;
                    Console.ForegroundColor = Screen[xi, yi].foregroundColor;
                    Console.Write(Screen[xi, yi].text);
                }
                Console.ResetColor();
                Console.Write("\n");
            }
            //render score below screen
            Console.Write("Score: " + ConsoleController.score + "                    ");
            IOReturner returnVal = new IOReturner(checkInput(), maxScreenXsize);
            return returnVal;
        }

        public IO()
        {
            for (int yi = 5; yi >= 0; yi--)
            {
                for (int xi = 0; xi < maxScreenXsize; xi++)
                {
                    Screen[xi, yi] = new Pixel();
                    switch (yi)
                    {
                        case 6:
                            Screen[xi, yi].backgroundColor = ConsoleColor.Blue;
                            break;
                        case 0:
                            Screen[xi, yi].backgroundColor = ConsoleColor.Green;
                            break;
                        default:
                            Screen[xi, yi].backgroundColor = ConsoleColor.Blue;
                            break;
                    }
                }
            }
        }

        public IO(int screenXsize)
        {
            //
            // TODO: Add constructor logic here
            maxScreenXsize = screenXsize;
            //initialize screen
            for (int yi = 5; yi >= 0; yi--)
            {
                for (int xi = 0; xi < maxScreenXsize; xi++)
                {
                    Screen[xi, yi] = new Pixel();
                    switch (yi)
                    {
                        case 6:
                            Screen[xi, yi].backgroundColor = ConsoleColor.Blue;
                            break;
                        case 0:
                            Screen[xi, yi].backgroundColor = ConsoleColor.Green;
                            break;
                        default:
                            Screen[xi, yi].backgroundColor = ConsoleColor.Blue;
                            break;
                    }
                }
            }
        }
    }

    public class IOReturner
    {

        public bool inputDetected { get; private set; }
        public int maxScreenXSize { get; private set; }

        public IOReturner(bool inputDetected, int maxScreenXSize)
        {
            this.inputDetected = inputDetected;
            this.maxScreenXSize = maxScreenXSize;

        }

    }

    public class Pixel
    {
        public string text;
        public ConsoleColor backgroundColor;
        public ConsoleColor foregroundColor;

        public Pixel()
        {
            text = "  ";
            backgroundColor = ConsoleColor.Black;
            foregroundColor = ConsoleColor.White;
        }
    }
}