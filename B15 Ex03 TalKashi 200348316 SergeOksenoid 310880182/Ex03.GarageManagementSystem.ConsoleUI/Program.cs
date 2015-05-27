using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            GarageMainMenu garageMainMenu = new GarageMainMenu();
            while (true)
            {
                garageMainMenu.ShowMainMenu();
            }
        }
    }
}
