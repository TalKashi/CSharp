using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex01_3
{
    public class Program
    {
        public static void Main()
        {
            int numOfLinesInClock = readInputFromUser();
            B15_Ex01_2.Program.PrintSandClock(numOfLinesInClock);
            Console.ReadKey();
        }

        private static int readInputFromUser()
        {
            int numOfLinesInClock = 0;
            Console.WriteLine("Please enter the number of lines for the sand clock:");
            string inputStr = Console.ReadLine();
            while (!int.TryParse(inputStr, out numOfLinesInClock) || numOfLinesInClock < 0)
            {
                Console.WriteLine("The input you entered is invalid. Please try again.");
                inputStr = Console.ReadLine();
            }

            return numOfLinesInClock;
        }
    }
}
