using System;

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
<<<<<<< HEAD


=======
>>>>>>> origin/master
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
<<<<<<< HEAD
            return isStringConsistsOfOnlyDigits(i_inputStrFromUser) || 
                             isStringConsistsOfOnlyLetters(i_inputStrFromUser);
=======

            return isStringConsistsOfOnlyDigits(i_InputStrFromUser) || 
                             isStringConsistsOfOnlyLetters(i_InputStrFromUser);
>>>>>>> origin/master
        }

        private static bool isStringConsistsOfOnlyDigits(string i_StringToCheck)
        {
<<<<<<< HEAD
            char[] inputStrFromAsCharArray = new char[i_stringToCheck.Length];
            inputStrFromAsCharArray= i_stringToCheck.ToCharArray();
            for (int i = 0; i < inputStrFromAsCharArray.Length; i++)
=======
            for (int i = 0; i < i_StringToCheck.Length; i++)
>>>>>>> origin/master
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
<<<<<<< HEAD
            char[] inputStrFromAsCharArray = new char[i_stringToCheck.Length];
            inputStrFromAsCharArray = i_stringToCheck.ToCharArray();
            for (int i = 0; i < inputStrFromAsCharArray.Length; i++)
=======
            for (int i = 0; i < i_StringToCheck.Length; i++)
>>>>>>> origin/master
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
<<<<<<< HEAD
            char[] inputStrFromAsCharArray = new char[i_stringToCheck.Length];
            inputStrFromAsCharArray = i_stringToCheck.ToCharArray();
            for (int i = 0; i < inputStrFromAsCharArray.Length / 2; i++)
                {
                    if (char.ToLower(inputStrFromAsCharArray[i]) != char.ToLower(inputStrFromAsCharArray[inputStrFromAsCharArray.Length - 1 - i]))
=======
            for (int i = 0; i < i_StringToCheck.Length / 2; i++)
            {
                if (i_StringToCheck[i] != i_StringToCheck[i_StringToCheck.Length - 1 - i])
>>>>>>> origin/master
                {
                    return false;
                }
            }

            return true;
        }

        private static int calcNumOfUpperCase(string i_StringToCheck)
        {
<<<<<<< HEAD
            int o_numOfUpperCase = 0;
            char[] inputStrFromAsCharArray = new char[i_stringToCheck.Length];
            inputStrFromAsCharArray = i_stringToCheck.ToCharArray();
            for (int i = 0; i < inputStrFromAsCharArray.Length; i++)
=======
            int numOfUpperCase = 0;
            for (int i = 0; i < i_StringToCheck.Length; i++)
>>>>>>> origin/master
            {
                if (char.IsUpper(i_StringToCheck[i]))
                {
                    numOfUpperCase++;
                }
            }

            return numOfUpperCase;
        }

        private static int calcSum(string i_StringToCheck)
        {
<<<<<<< HEAD
            int o_sum = 0;
            char[] inputStrFromAsCharArray = new char[i_stringToCheck.Length];
            inputStrFromAsCharArray = i_stringToCheck.ToCharArray();
            for (int i = 0; i < inputStrFromAsCharArray.Length; i++)
=======
            int sum = 0;
            for (int i = 0; i < i_StringToCheck.Length; i++)
>>>>>>> origin/master
            {
                sum += i_StringToCheck[i] - '0';
            }

            return sum;
        }
    }
}