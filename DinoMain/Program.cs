using System;
using System.Threading;
namespace DinoMain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            ConsoleKeyInfo cki;

            do
            {
                Console.WriteLine("\nPress a  key to display; press the 'x' key to quit.");

                // Your code could perform some useful task in the following loop. However,
                // for the sake of this example we'll merely pause for a quarter second.

                while (Console.KeyAvailable == false)
                    Thread.Sleep(250); // Loop until input is entered.

                cki = Console.ReadKey(true);
                Console.WriteLine("You pressed the '{0}' key.", cki.Key);
                if (cki.Key.ToString() == "UpArrow" || cki.Key.ToString() == "Spacebar" || cki.Key.ToString() == "W") { Console.WriteLine("Jump detected!"); }
                
            } while (cki.Key != ConsoleKey.X);  
        }
    }
}
