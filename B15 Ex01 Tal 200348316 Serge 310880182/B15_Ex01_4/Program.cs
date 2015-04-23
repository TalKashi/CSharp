using System;

namespace B15_Ex01_4
{
    public class Program
    {
        public static void Main()
        {
            string userInput = getInputFromUser();
            if (isPalindrome(userInput)) 
            {
                Console.WriteLine("Is Palindrome");
            }

            if (isStringConsistsOfOnlyLetters(userInput)) 
            {
                Console.WriteLine("The number of upper case letters is: " + calcNumOfUpperCase(userInput));
            }

            if (isStringConsistsOfOnlyDigits(userInput))
            {
                Console.WriteLine("The sum of digits is: " + calcSum(userInput));
            }
        }

        private static string getInputFromUser()
        {
            Console.WriteLine("Please enter string of lenght 10 chars:");
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
            if (i_InputStrFromUser.Length != 10) 
            {
                return false;
            }

            char[] inputStrFromAsCharArray = new char[i_InputStrFromUser.Length];
            return isStringConsistsOfOnlyDigits(i_InputStrFromUser) || 
                             isStringConsistsOfOnlyLetters(i_InputStrFromUser);
        }

        private static bool isStringConsistsOfOnlyDigits(string i_StringToCheck)
        {
            char[] inputStrFromAsCharArray = new char[i_StringToCheck.Length];
            for (int i = 0; i < inputStrFromAsCharArray.Length; i++)
            {
                if (!char.IsDigit(inputStrFromAsCharArray[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool isStringConsistsOfOnlyLetters(string i_StringToCheck)
        {
            char[] inputStrFromAsCharArray = new char[i_StringToCheck.Length];
            for (int i = 0; i < inputStrFromAsCharArray.Length; i++)
            {
                if (!char.IsLetter(inputStrFromAsCharArray[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool isPalindrome(string i_StringToCheck)
        {
            char[] inputStrFromAsCharArray = new char[i_StringToCheck.Length];
            for (int i = 0; i < inputStrFromAsCharArray.Length / 2; i++)
            {
                if (inputStrFromAsCharArray[i] != inputStrFromAsCharArray[inputStrFromAsCharArray.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        private static int calcNumOfUpperCase(string i_StringToCheck)
        {
            int numOfUpperCase = 0;
            char[] inputStrFromAsCharArray = new char[i_StringToCheck.Length];
            for (int i = 0; i < inputStrFromAsCharArray.Length; i++)
            {
                if (char.IsUpper(inputStrFromAsCharArray[i]))
                {
                    numOfUpperCase++;
                }
            }

            return numOfUpperCase;
        }

        private static int calcSum(string i_StringToCheck)
        {
            int sum = 0;
            char[] inputStrFromAsCharArray = new char[i_StringToCheck.Length];
            for (int i = 0; i < inputStrFromAsCharArray.Length; i++)
            {
                sum += inputStrFromAsCharArray[i] - '0';
            }

            return sum;
        }
    }
}