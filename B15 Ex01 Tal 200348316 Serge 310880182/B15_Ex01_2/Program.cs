using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex01_2
{
    class Program
    {
        static void Main()
        {
            PrintStandartSandClock();
            Console.ReadLine();
        }

        public static void PrintStandartSandClock()
        {
            string output = 
@"*****
 ***
  *
 ***
*****";

            Console.WriteLine(output);
        }
    }
}
