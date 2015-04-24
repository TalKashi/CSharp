using System;
using System.Text;

namespace B15_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            PrintSandClock(5);
        }

        public static void PrintSandClock(int i_NumOfLinesInClock)
        {
            StringBuilder stringBuilder = new StringBuilder();

            // Handle odd input
            if (i_NumOfLinesInClock % 2 == 1)
            {
                i_NumOfLinesInClock--;
            }

            for (int i = i_NumOfLinesInClock; i >= -i_NumOfLinesInClock; i -= 2)
            {
                int spaceFromStart = (i_NumOfLinesInClock - Math.Abs(i)) / 2;
                generateStars(stringBuilder, Math.Abs(i) + 1, spaceFromStart);
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        private static void generateStars(StringBuilder io_StringBuilder, int i_NumOfStars, int i_SpaceFromStart)
        {
            for (int i = 0; i < i_SpaceFromStart; i++)
            {
                io_StringBuilder.Append(" ");
            }

            for (int i = 0; i < i_NumOfStars; i++)
            {
                io_StringBuilder.Append("*");
            }

            io_StringBuilder.AppendLine();
        }
    }
}
