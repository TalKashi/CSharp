using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex01_1
{
    public class Program
    {
        public static void Main()
        {
            int totalOfAscendingNumbers = 0;
            int totalOfDescendingNumbers = 0;
            int totalValueOfNumbers = 0;
            int totalNumbersInBinaryRepresentation = 0;
            string[] inputsFromUser = new string[5];
            for (int i = 0; i < inputsFromUser.Length; i++)
            {
                inputsFromUser[i] = getInputFromUser();
            }
            string[] binaryRepresentation = new string[inputsFromUser.Length];
            for (int i = 0; i < binaryRepresentation.Length; i++)
            {
                binaryRepresentation[i] = decimalStringToBinaryString(inputsFromUser[i]);
                totalNumbersInBinaryRepresentation += binaryRepresentation[i].Length;
                totalValueOfNumbers += int.Parse(inputsFromUser[i]);
                if (checkIfDescending(inputsFromUser[i]))
                {
                    totalOfDescendingNumbers++;
                } 
                else if (checkIfAscending(inputsFromUser[i]))
                {
                    totalOfAscendingNumbers++;
                }
            }

            string concatBinarySrting = concatStringArrayWithSpaces(binaryRepresentation);
            // WYSIWYG
            string outputMsg = string.Format(
@"The binary numbers are: {0}.
There are {1} numbers which are an ascending series and {2} which are descending.
The avarege number of digits in binary number is {3}.
The general avarege of the inserted numbers is {4}.", concatBinarySrting, totalOfAscendingNumbers,
                                                    totalOfDescendingNumbers,
                                                    (float) totalNumbersInBinaryRepresentation/inputsFromUser.Length,
                                                    (float) totalValueOfNumbers/inputsFromUser.Length);
            Console.WriteLine(outputMsg);
        }

        private static string concatStringArrayWithSpaces(string[] i_BinaryRepresentation)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < i_BinaryRepresentation.Length; i++)
            {
                stringBuilder.Append(i_BinaryRepresentation[i] + " ");
            }
            return stringBuilder.ToString();
        }

        private static bool checkIfDescending(string i_DecimalString)
        {
            for (int i = 0; i < i_DecimalString.Length - 1; i++)
            {
                if (i_DecimalString[i] - 1 != i_DecimalString[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        private static bool checkIfAscending(string i_DecimalString)
        {
            for (int i = 0; i < i_DecimalString.Length - 1; i++)
            {
                if (i_DecimalString[i] + 1 != i_DecimalString[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        private static string getInputFromUser()
        {
            Console.WriteLine("Please enter 5 numbers with 3 digits each:");
            
            string inputStrFromUser = Console.ReadLine();
            while (!isValidInput(inputStrFromUser))
            {
                Console.WriteLine("The input you entered is invalid. Please try again.");
                inputStrFromUser = Console.ReadLine();
            }
            return inputStrFromUser;
        }

        private static bool isValidInput(string i_InputStrFromUser)
        {
            if (string.IsNullOrEmpty(i_InputStrFromUser))
            {
                return false;
            }
            i_InputStrFromUser = i_InputStrFromUser.Trim();
            if (i_InputStrFromUser.Length != 3)
            {
                return false;
            }
            for (int i = 0; i < i_InputStrFromUser.Length; i++)
            {
                if (!char.IsDigit(i_InputStrFromUser[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static string decimalStringToBinaryString(string i_DecimalString)
        {
            StringBuilder reversedOrderBinaryStringBuilder = new StringBuilder();
            int number = int.Parse(i_DecimalString);

            // Special case number==0
            if (number == 0)
            {
                return "0";
            }
            while (number > 0)
            {
                int reminder = number % 2;
                reversedOrderBinaryStringBuilder.Append(reminder.ToString());
                number /= 2;
            }

            // Reverse the order
            StringBuilder correctBinaryOrderStringBuilder = new StringBuilder();
            for (int i = reversedOrderBinaryStringBuilder.Length - 1; i >= 0; i--)
            {
                correctBinaryOrderStringBuilder.Append(reversedOrderBinaryStringBuilder[i]);
            }
            return correctBinaryOrderStringBuilder.ToString();
        }
    }
}
