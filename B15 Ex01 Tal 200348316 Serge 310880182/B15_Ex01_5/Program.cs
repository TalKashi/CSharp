using System;

namespace B15_Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            string userInput = getInputFromUser();

            // WYSIWYG
            string outputMsg = string.Format(
@"Number of digits which larger than the first digit is: {0}
Number of digits which smaller than the first digit is: {1}
The largest degit is: {2}
The smallest degit is: {3}", calcNumOfDigitsLargerThanFirstDigit(userInput),
                calcNumOfDigitsSmallerThanFirstDigit(userInput),
                findLargestDigitInString(userInput),
                findSmallestDigitInString(userInput));

            Console.WriteLine(outputMsg);
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
            int numOfDigitsLargerThanFirstDigit = 0;
            for (int i = 1; i < i_InputStrFromUser.Length; i++ )
            {
                if (i_InputStrFromUser[i] - '0' > firstDigit) 
                {
                    numOfDigitsLargerThanFirstDigit++;
                }
            }

            return numOfDigitsLargerThanFirstDigit;
        }

        private static int calcNumOfDigitsSmallerThanFirstDigit(string i_InputStrFromUser)
        {
            int firstDigit = i_InputStrFromUser[0] - '0';
            int numOfDigitsSmallerThanFirstDigit = 0;
            for (int i = 1; i < i_InputStrFromUser.Length; i++)
            {
                if (i_InputStrFromUser[i] - '0' < firstDigit)
                {
                    numOfDigitsSmallerThanFirstDigit++;
                }
            }

            return numOfDigitsSmallerThanFirstDigit;
        }

        private static int findLargestDigitInString(string i_InputStrFromUser)
         {
            int maxDigit = -1;
            for (int i = 0; i < i_InputStrFromUser.Length; i++)
            {
                int currentDigit = i_InputStrFromUser[i] - '0';
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
            for (int i = 0; i < i_InputStrFromUser.Length; i++)
            {
                int currentDigit = i_InputStrFromUser[i] - '0';
                if (currentDigit < minDigit)
                {
                    minDigit = currentDigit;
                }
            }

            return minDigit;
        }
    }
}
