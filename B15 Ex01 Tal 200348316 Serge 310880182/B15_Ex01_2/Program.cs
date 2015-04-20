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
            // Handle even input
            if (i_NumOfLinesInClock % 2 == 0)
            {
                i_NumOfLinesInClock++;
            }

            int spaceFromStart = 0;
            for (int i = i_NumOfLinesInClock; i > 2; i -= 2)
            {
                generateStars(stringBuilder, i, spaceFromStart);
                spaceFromStart++;
            }
            generateStars(stringBuilder, 1, spaceFromStart);
            for (int i = 3; i <= i_NumOfLinesInClock; i += 2)
            {
                spaceFromStart--;
                generateStars(stringBuilder, i, spaceFromStart);
            }
            Console.WriteLine(stringBuilder.ToString());
        }

        private static void generateStars(StringBuilder i_StringBuilder, int i_NumOfStars, int i_SpaceFromStart)
        {
            for (int i = 0; i < i_SpaceFromStart; i++)
            {
                i_StringBuilder.Append(" ");
            }
            for (int i = 0; i < i_NumOfStars; i++)
            {
                i_StringBuilder.Append("*");
            }
            i_StringBuilder.AppendLine();
        }
    }
}
