using System;
using System.Threading;
using DinoClassLib;

namespace DinoMain
{
    class Program
    {
        static void Main(string[] args)
        {
            IO io = new IO();
            Controller controller = new Controller(io);
            controller.runGame();
        }
    }
}
