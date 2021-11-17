using System;
using System.Threading;

namespace DinoMain
{
    class Program
    {
        

        static void Main(string[] args)
        {
            void FrameLimiter(double fps)
            {
                double info = 1 / fps;
                info *= 1000;
                Thread.Sleep((int)info);
            }
            double fps = .25;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Hello World!");
                FrameLimiter(fps);
            }
        }

    }
}
