using System;
using System.Text;

namespace B15_Ex01_5
{
    class Program
    {
        public static void Main()
        {
            while (true)
            {
                string userInput = getInputFromUser();
                Console.WriteLine("Number of digits which larger than the first digit is: " + calcNumOfDigitsLargerThanFirstDigit(userInput));
                Console.WriteLine("Number of digits which smaller than the first digit is: " + calcNumOfDigitsSmallerThanFirstDigit(userInput));
                Console.WriteLine("The largest degit is: " + findLargestDigitInString(userInput));
                Console.WriteLine("The smallest degit is: " + findSmallestDigitInString(userInput));
            }

        }


        private static string getInputFromUser()
        {
            Console.WriteLine("Please enter number which consist of 8 digits:");
            string inputStrFromUser = Console.ReadLine();
            while (!isValidInput(inputStrFromUser))
            {
                Console.WriteLine("Wrong input, try again");
                inputStrFromUser = Console.ReadLine();
            }

            return inputStrFromUser;
        }

        private static bool isValidInput(string i_InputStrFromUser)
        {
            if (i_InputStrFromUser.Length != 8)
            {
                return false;
            }
            return B15_Ex01_4.Program.IsStringConsistsOfOnlyDigits(i_InputStrFromUser);
        }

        private static int calcNumOfDigitsLargerThanFirstDigit(string i_InputStrFromUser)
        {
            int firstDigit = i_InputStrFromUser[0] - '0';
            int NumOfDigitsLargerThanFirstDigit = 0;
            for (int i = 1; i < i_InputStrFromUser.Length ; i++ )
            {
                if (i_InputStrFromUser[i] - '0' > firstDigit) 
                {
                    NumOfDigitsLargerThanFirstDigit++;
                }
            }
            return NumOfDigitsLargerThanFirstDigit;
            
        }

        private static int calcNumOfDigitsSmallerThanFirstDigit(string i_InputStrFromUser)
        {
            int firstDigit = i_InputStrFromUser[0] - '0';
            int NumOfDigitsSmallerThanFirstDigit = 0;
            for (int i = 1; i < i_InputStrFromUser.Length; i++)
            {
                if (i_InputStrFromUser[i] - '0' < firstDigit)
                {
                    NumOfDigitsSmallerThanFirstDigit++;
                }
            }
            return NumOfDigitsSmallerThanFirstDigit;

        }

        private static int findLargestDigitInString(string i_InputStrFromUser)
         {
            int maxDigit = -1;
            int currentDigit;
            for (int i = 0; i < i_InputStrFromUser.Length; i++)
            {
                currentDigit = i_InputStrFromUser[i] - '0';
                if (currentDigit > maxDigit)
                {
                    maxDigit = currentDigit;
                }
            }
            return maxDigit;
         }

        private static int findSmallestDigitInString(string i_InputStrFromUser)
        {
            int minDigit = 10;
            int currentDigit;
            for (int i = 0; i < i_InputStrFromUser.Length; i++)
            {
                currentDigit = i_InputStrFromUser[i] - '0';
                if (currentDigit < minDigit)
                {
                    minDigit = currentDigit;
                }
            }
            return minDigit;
        }

    }
}
