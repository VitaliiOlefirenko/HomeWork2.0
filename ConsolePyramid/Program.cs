using System;

namespace ConsolePyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePyramidFromAsterisk();
        }
        static void ConsolePyramidFromAsterisk(int rows = 7)
        {
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= (rows - i); j++)
                    Console.Write("  ");
                for (int k = 1; k <= 2 * i - 1; k++)
                    Console.Write("* ");
                Console.WriteLine();
            }

            Console.WriteLine("Please press Enter to close console.");
            Console.ReadLine();
        }
    }
}