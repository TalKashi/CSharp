using System;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    class GarageMainMenu
    {
        private string[] m_MainMenu = {"adding new vehicle to the grage",
                                  "display vehicles by thier status",
                                  "changing vehicle status",
                                  "pump air",
                                  "pump fuel",
                                  "charge bettary",
                                   "display info"};

        private string[] m_Status = {"InProgress", "Repaired","Paid" };
        private string[] m_FuelType = { "Octan95", "Octan96", "Octan98", "Soler" };

        private GarageMenu m_GrageMenu;
        
        public void GarageMainMenu()
        {
            m_GrageMenu = new GarageMenu();
        }

        public void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome To the Garage Menegment System");
        }

        public void ShowMainMenu()
        {
            string userChoise = m_GrageMenu.getOptionFromMenu(m_MainMenu, "What do you want to do?");
            executeSelectedOparetion(userChoise);
        }

        private string getLicenseNumber()
        {
            Console.WriteLine("Please enter license number");
            return Console.ReadLine();
        }

        private void executeSelectedOparetion(string i_Operation)
        {
            if (i_Operation == m_MainMenu[0]) 
            {
                m_GrageMenu.AddVehicle();
            }
            else if (i_Operation == m_MainMenu[1]) 
            {
                eStatus filter = (eStatus)Enum.Parse(typeof(eStatus), m_GrageMenu.getOptionFromMenu(m_Status, "Please select your filter"));
                m_GrageMenu.DisplayVehicleLicensePlateByStatus(filter);

            }
            else if (i_Operation == m_MainMenu[2])
            {
                string licenseNumber = getLicenseNumber();
                eStatus status = (eStatus)Enum.Parse(typeof(eStatus), m_GrageMenu.getOptionFromMenu(m_Status, "To what status you want to change"));
                m_GrageMenu.ChangeVehicleStatus(licenseNumber, status);
            }
            else if (i_Operation == m_MainMenu[3])
            {
                string licenseNumber = getLicenseNumber();
                m_GrageMenu.PumpAirToMax(licenseNumber);
            }
            else if (i_Operation == m_MainMenu[4])
            {
                float amount;
                string licenseNumber = getLicenseNumber();
                Console.WriteLine("Please enter the amount of fuel to you to add");
                string amountInput = Console.ReadLine();
                eFuelType fuelType = (eFuelType)Enum.Parse(typeof(eFuelType), m_GrageMenu.getOptionFromMenu(m_FuelType, "What type of fuel?"));
                while (float.TryParse(amountInput, out amount)) 
                {
                    Console.WriteLine("Wrong input type");
                    amountInput = Console.ReadLine();
                }
                m_GrageMenu.AddFuel(licenseNumber,fuelType,amount);
            }
            else if (i_Operation == m_MainMenu[5])
            {
                float amount;
                string licenseNumber = getLicenseNumber();
                Console.WriteLine("Please enter the amount in minutes");
                string amountInput = Console.ReadLine();
                while (float.TryParse(amountInput, out amount)) 
                {
                    Console.WriteLine("Wrong input type");
                    amountInput = Console.ReadLine();
                }
                m_GrageMenu.ChargeBettary(licenseNumber,amount);
            }
            else if (i_Operation == m_MainMenu[6])
            {
                string licenseNumber = getLicenseNumber();
                m_GrageMenu.DisplayInfo(licenseNumber);

            }


        }


    }
}
