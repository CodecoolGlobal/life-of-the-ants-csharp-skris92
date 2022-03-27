using System;

namespace Codecool.LifeOfAnts
{
    /// <summary>
    ///     Simulation main class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main method
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Hello, Ants! (Enter 'q' to exit)");
            Colony colony = new Colony(11);
            colony.GenerateAnts(2, 3, 4);
            colony.Display();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "")
                {
                    colony.Update();
                    Console.Clear();
                    Console.WriteLine("Hello, Ants! (Enter 'q' to exit)");
                    colony.Display();
                }
                else if (input == "q")
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
