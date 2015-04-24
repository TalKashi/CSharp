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

            if (IsStringConsistsOfOnlyDigits(userInput))
            {
                Console.WriteLine("The sum of digits is: " + calcSumOfDigitsInString(userInput));
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

            return IsStringConsistsOfOnlyDigits(i_InputStrFromUser) || 
                             isStringConsistsOfOnlyLetters(i_InputStrFromUser);
        }

        public static bool IsStringConsistsOfOnlyDigits(string i_StringToCheck)
        {
            for (int i = 0; i < i_StringToCheck.Length; i++)
            {
                if (!char.IsDigit(i_StringToCheck[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool isStringConsistsOfOnlyLetters(string i_StringToCheck)
        {
            for (int i = 0; i < i_StringToCheck.Length; i++)
            {
                if (!char.IsLetter(i_StringToCheck[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool isPalindrome(string i_StringToCheck)
        {
            for (int i = 0; i < i_StringToCheck.Length / 2; i++)
            {
                if (char.ToLower(i_StringToCheck[i]) != char.ToLower(i_StringToCheck[i_StringToCheck.Length - 1 - i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static int calcNumOfUpperCase(string i_StringToCheck)
        {
            int numOfUpperCase = 0;
            for (int i = 0; i < i_StringToCheck.Length; i++)
            {
                if (char.IsUpper(i_StringToCheck[i]))
                {
                    numOfUpperCase++;
                }
            }

            return numOfUpperCase;
        }

        private static int calcSumOfDigitsInString(string i_StringToCheck)
        {
            int sumOfDigitsInString = 0;
            for (int i = 0; i < i_StringToCheck.Length; i++)
            {
                sumOfDigitsInString += i_StringToCheck[i] - '0';
            }

            return sumOfDigitsInString;
        }
    }
}