using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            GarageMainMenu m_GarageMainMenu = new GarageMainMenu();
            m_GarageMainMenu.PrintWelcomeMessage();
            while (true)
            {
                m_GarageMainMenu.ShowMainMenu();
            }
        }
    }
}
