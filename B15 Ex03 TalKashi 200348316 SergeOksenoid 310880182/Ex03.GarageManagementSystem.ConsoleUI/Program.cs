using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            GarageMainMenu m_garageMainMenu = new GarageMainMenu();
            m_garageMainMenu.PrintWelcomeMessage();
            while (true)
            {
                m_garageMainMenu.ShowMainMenu();
            }
        }
    }
}
