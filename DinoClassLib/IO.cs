using System;

/// <summary>

namespace DinoClassLib {
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
                    break;
                case Controller.status.running: //TODO:
                    // Add player to screen
                    for(int i = 0; i < ConsoleController.player.ySize; i++)
                    {
                        Pixel playerPixel = new Pixel();
                        playerPixel.text = "||";
                        Screen[ConsoleController.player.position.getX(), i + ConsoleController.player.position.getY()] = playerPixel;
                    }
                    // Add controller to screen
                    foreach(IPiece obst in ConsoleController.Obstacles)
                    {
                        Pixel obstPixel = new Pixel();
                        Type obsType = obst.GetType();
                        if(obsType.Equals(typeof(Bird)))
                        {
                            obstPixel.text = "< ";
                        }
                        else if (obsType.Equals(typeof(SmallRock)) || obsType.Equals(typeof(BigRock)))
                        {
                            obstPixel.text = "XX";
                        }
                    }
                    break;
                case Controller.status.dead: //TODO: Impliment a dead render
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