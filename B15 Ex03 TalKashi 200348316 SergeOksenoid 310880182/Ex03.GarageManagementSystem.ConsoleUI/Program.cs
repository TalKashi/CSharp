using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {

            while (true)
            {
                displayMenu();
                getInputFromUser();
            }

        }

        private static void displayMenu()
        {
            string[] options = {"adding new vehicle to the grage",
                                  "display vehicles by thier status",
                                  "changing vehicle status",
                                  "pump air","pump fuel",
                                  "charge bettary",
                                   "display info"};
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(string.Format("Press {0} for {1}",i,options[i]));
            }
        }

        private static void getInputFromUser()
        {

        }

    }
}
