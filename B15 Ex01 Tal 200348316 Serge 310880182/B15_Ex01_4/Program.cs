using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex01_4
{
    public class Program
    {
        public static void Main()
        {
            while (true)
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


        private static bool isValidInput(string i_inputStrFromUser)
        {
            if (i_inputStrFromUser.Length != 10) 
            {
                return false;
            }
            return isStringConsistsOfOnlyDigits(i_inputStrFromUser) || 
                             isStringConsistsOfOnlyLetters(i_inputStrFromUser);
        }

        private static bool isStringConsistsOfOnlyDigits(string i_stringToCheck)
        {
            char[] inputStrFromAsCharArray = new char[i_stringToCheck.Length];
            inputStrFromAsCharArray= i_stringToCheck.ToCharArray();
            for (int i = 0; i < inputStrFromAsCharArray.Length; i++)
            {
                if (!char.IsDigit(inputStrFromAsCharArray[i]))
                {
                    return false;
                }

            }
            return true;
        }

        private static bool isStringConsistsOfOnlyLetters(string i_stringToCheck)
        {
            char[] inputStrFromAsCharArray = new char[i_stringToCheck.Length];
            inputStrFromAsCharArray = i_stringToCheck.ToCharArray();
            for (int i = 0; i < inputStrFromAsCharArray.Length; i++)
            {
                if (!char.IsLetter(inputStrFromAsCharArray[i]))
                {
                    return false;
                }

            }
            return true;
        }

        private static bool isPalindrome(string i_stringToCheck)
        {
            char[] inputStrFromAsCharArray = new char[i_stringToCheck.Length];
            inputStrFromAsCharArray = i_stringToCheck.ToCharArray();
            for (int i = 0; i < inputStrFromAsCharArray.Length / 2; i++)
                {
                    if (char.ToLower(inputStrFromAsCharArray[i]) != char.ToLower(inputStrFromAsCharArray[inputStrFromAsCharArray.Length - 1 - i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static int calcNumOfUpperCase(string i_stringToCheck)
        {
            int o_numOfUpperCase = 0;
            char[] inputStrFromAsCharArray = new char[i_stringToCheck.Length];
            inputStrFromAsCharArray = i_stringToCheck.ToCharArray();
            for (int i = 0; i < inputStrFromAsCharArray.Length; i++)
            {
                if (char.IsUpper(inputStrFromAsCharArray[i]))
                {
                    o_numOfUpperCase++;
                }
            }
            return o_numOfUpperCase;

        }

        private static int calcSum(string i_stringToCheck)
        {
            int o_sum = 0;
            char[] inputStrFromAsCharArray = new char[i_stringToCheck.Length];
            inputStrFromAsCharArray = i_stringToCheck.ToCharArray();
            for (int i = 0; i < inputStrFromAsCharArray.Length; i++)
            {
                o_sum += inputStrFromAsCharArray[i] - '0';
            }
            return o_sum;

        }

    }
}