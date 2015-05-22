using System;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    class GarageMainMenu
    {
        private string[] m_MainMenu = {"adding new vehicle to the garage",
                                  "display vehicles by thier status",
                                  "changing vehicle status",
                                  "pump air",
                                  "pump fuel",
                                  "charge bettary",
                                   "display info"};

        private string[] m_Status = {"InProgress", "Repaired","Paid" };
        private string[] m_FuelType = { "Octan95", "Octan96", "Octan98", "Soler" };     
        private string[] m_MotorcycleLicense = {"A","A2","AB","B1"};
        private string[] m_CarColor = { "Green", "Black", "White", "Red"};
        private string[] m_Doors = { "2 doors", "3 doors", "4 doors", "5 doors" };
        private string[] m_TruckCarryingDangerousCargo = {"Yes","No"};
       
        private Garage m_Grage;
        
        public GarageMainMenu()
        {
            m_Grage = new Garage();
        }

        public void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome To the Garage Menegment System");
        }

        public void ShowMainMenu()
        {
            string userChoise = getOptionFromMenu(m_MainMenu, "What do you want to do?");
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
                addVehicle();
            }
            else if (i_Operation == m_MainMenu[1]) 
            {
                eStatus filter = (eStatus)Enum.Parse(typeof(eStatus), getOptionFromMenu(m_Status, "Please select your filter"));
                m_Grage.GetLicenseNumbersByStatus(filter);

            }
            else if (i_Operation == m_MainMenu[2])
            {
                string licenseNumber = getLicenseNumber();
                eStatus status = (eStatus)Enum.Parse(typeof(eStatus), getOptionFromMenu(m_Status, "To what status you want to change"));
                m_Grage.ChangeVehicleStatus(licenseNumber, status);
            }
            else if (i_Operation == m_MainMenu[3])
            {
                string licenseNumber = getLicenseNumber();
                m_Grage.PumpAirInWheels(licenseNumber);
            }
            else if (i_Operation == m_MainMenu[4])
            {
                float amount;
                string licenseNumber = getLicenseNumber();
                Console.WriteLine("Please enter the amount of fuel to you to add");
                string amountInput = Console.ReadLine();
                eFuelType fuelType = (eFuelType)Enum.Parse(typeof(eFuelType), getOptionFromMenu(m_FuelType, "What type of fuel?"));
                while (float.TryParse(amountInput, out amount)) 
                {
                    Console.WriteLine("Wrong input type");
                    amountInput = Console.ReadLine();
                }
                m_Grage.PumpFuel(licenseNumber,fuelType,amount);
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
                m_Grage.ChargeBettery(licenseNumber,amount);
            }
            else if (i_Operation == m_MainMenu[6])
            {
                string licenseNumber = getLicenseNumber();
                m_Grage.GetVehicleDetails(licenseNumber);

            }

        }


        private void addVehicle() 
        {
            Console.WriteLine("Please enter license number");
            string liceseNumber = Console.ReadLine();

            if (m_Grage.DoesVehicleExist(liceseNumber)) 
            {
                m_Grage.ChangeVehicleStatus(liceseNumber, eStatus.InProgress);
                return;
            }

            Console.WriteLine("Please enter your name ");
            string ownerName = Console.ReadLine();

            Console.WriteLine("Please enter your phone number");
            string ownerPhone = Console.ReadLine();

            string vehicle = getOptionFromMenu(VehicleInfo.GetVehicleList(),"Please select your vehicle type");
            
            Console.WriteLine("Please enter your vehicle model");
            string vehicleModel = Console.ReadLine();

            Console.WriteLine("Please enter wheels manufacture");
            string wheelsManufacture = Console.ReadLine();

            Console.WriteLine("Please enter current air pressure in your wheels");
            string currentAirPressure = Console.ReadLine();

            string[] vehicleProperties = getPropertiesOfVehicle(vehicle);
        }




        private string getOptionFromMenu(string[] i_Options,string i_GenericMessage)
        {
            int userChoise;
            printGenericMenuFromArray(i_Options, i_GenericMessage);
            string vehicleType = Console.ReadLine();
            while (!isValidVehicle(i_Options.Length, vehicleType, out userChoise))
            {
                Console.WriteLine("Wrong input, please enter number in range");
                vehicleType = Console.ReadLine();
            }

            return i_Options[userChoise];
        }


        private bool isValidVehicle(int i_UpperRangeBound, string i_UserInput, out int o_UserChoise)
        {
            bool isValid  = false;
            o_UserChoise = -1;
            if (Int32.TryParse(i_UserInput,out o_UserChoise)){
                isValid = (0 <= o_UserChoise &&  o_UserChoise < i_UpperRangeBound);
            }
            return isValid;
        }

        private void printGenericMenuFromArray(string[] i_StringArray, string i_GenericMessage) 
        {
            StringBuilder stringBuilder = new StringBuilder(i_GenericMessage);
            stringBuilder.Append(Environment.NewLine);
            for (int i = 0; i < i_StringArray.Length; i++)
            {
                stringBuilder.Append(string.Format("For {0} press {1}", i_StringArray[i], i));
                stringBuilder.Append(Environment.NewLine);
            }
            Console.WriteLine(stringBuilder.ToString());
        }

        private string[] getPropertiesOfVehicle(string i_Vehicle)
        {
            string[] properties;
            switch (i_Vehicle)
            {
                case "Car(Fuel)":
                case "Car(Electric)":
                    properties = new string[2];
                    properties[0] = getOptionFromMenu(m_CarColor, "Please choose car color");
                    properties[1] = getOptionFromMenu(m_Doors, "Please select how many doors your car has");
                    break;
                case "Motorcycle(Fuel)":
                case "Motorcycle(Electric)":
                    properties = new string[2];
                    Console.WriteLine("Whats your engine volume?");
                    properties[0] = Console.ReadLine();
                    properties[1] = getOptionFromMenu(m_MotorcycleLicense, "Please select your license type");
                    break;
                case "Truck(Fuel)":
                    properties = new string[2];
                    properties[0] = getOptionFromMenu(m_TruckCarryingDangerousCargo, "Is your truck carrying dangerous cargo");
                    Console.WriteLine("Whats your currnet truck weight?");
                    properties[1] = Console.ReadLine();
                    break;
                default:
                    properties = null;
                    break;

            }
            return properties;
        }


    }
}
