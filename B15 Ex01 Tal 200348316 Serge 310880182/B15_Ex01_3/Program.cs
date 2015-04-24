using System;

namespace B15_Ex01_3
{
    public class Program
    {
        public static void Main()
        {
           int numOfLinesInClock = getInputFromUser();
           B15_Ex01_2.Program.PrintSandClock(numOfLinesInClock);
        }

        private static int getInputFromUser()
        {
            int numOfLinesInClock;
            Console.WriteLine("Please enter the number of lines for the sand clock:");
            string inputStrFromUser = Console.ReadLine();
            while (!int.TryParse(inputStrFromUser, out numOfLinesInClock) || numOfLinesInClock < 0)
            {
                Console.WriteLine("The input you entered is invalid. Please try again.");
                inputStrFromUser = Console.ReadLine();
            }

            return numOfLinesInClock;
        }
    }
}
