using System;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    public class GarageMainMenu
    {
        private enum eOptions
        {
            EnterVehicle = 1,
            DisplayLicensePlates = 2,
            UpdateVehicleStatus = 3,
            InflateAir = 4,
            PumpFuel = 5,
            ChargeBattery = 6,
            DisplayVehicleDetails = 7
        }

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
       
        private Garage m_Garage;
        
        public GarageMainMenu()
        {
            m_Garage = new Garage();
        }

        public void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome To the Garage Management System");
        }

        public void ShowMainMenu()
        {
            Console.WriteLine(
@"What do you want to do? (enter the digit of the desired option)
1. Enter a vehicle into the garage
2. Display the license plate of vehicles in the garage
3. Update vehicle status in garage
4. Inflate air in vehicle wheels to max
5. Pump fuel in vehicle
6. Charge battery in vehicle
7. Display details of a vehicle in the garage");

            eOptions userChoise = getMainMenuChoice();
            //string userChoise = getOptionFromMenu(m_MainMenu, "What do you want to do?");
            //executeSelectedOparetion(userChoise);

            switch (userChoise)
            {
                case eOptions.EnterVehicle:
                    showEnterVehicleMenu();
                    break;
                case eOptions.DisplayLicensePlates:
                    showDisplayLicensePlatesMenu();
                    break;
                case eOptions.UpdateVehicleStatus:
                    showUpdateVehicleStatusMenu();
                    break;
                case eOptions.InflateAir:
                    showInflateAirMenu();
                    break;
                case eOptions.PumpFuel:
                    showPumpFuelMenu();
                    break;
                case eOptions.ChargeBattery:
                    showChargeBatteryMenu();
                    break;
                case eOptions.DisplayVehicleDetails:
                    showDisplayVehicleDetailsMenu();
                    break;
            }
        }

        private void showEnterVehicleMenu()
        {
            string licensePlateSrting = getLicensePlaterNumberFromUser();

            if (m_Garage.DoesVehicleExist(licensePlateSrting))
            {
                m_Garage.ChangeVehicleStatus(licensePlateSrting, eStatus.InProgress);
                Console.Clear();
                Console.WriteLine("We already have this vehicle in our database. Status change to 'In Repair'");
            }
            else
            {
                string ownerName = getOwnerName();
                string ownerPhone = getOwnerPhone();
                string vehicleType = getVehicleType();
            }
        }

        private string getVehicleType()
        {
            int choiceNum;

            Console.Clear();
            Console.WriteLine("What vehicle you have? (enter the digit of the desired option)");
            string[] supportedVehicles = VehicleInfo.GetVehicleList();
            printGenericMenuFromArray(supportedVehicles);

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            while (!isValidInput(input, 1, supportedVehicles.Length, out choiceNum))
            {
                Console.WriteLine("Invalid input! Please enter a digit between 1 to {0}", supportedVehicles.Length);
                Console.Write("Enter your choice: ");
                input = Console.ReadLine();
            }

            return supportedVehicles[choiceNum - 1];
        }

        private string getOwnerPhone()
        {
            Console.Clear();
            Console.Write("Please enter your phone number: ");
            string ownerPhone = Console.ReadLine();
            while (string.IsNullOrEmpty(ownerPhone) || string.IsNullOrEmpty(ownerPhone.Trim()))
            {
                Console.WriteLine("Invalid input! Please enter a non empty string");
                Console.Write("Please enter your phone number: ");
                ownerPhone = Console.ReadLine();
            }

            return ownerPhone;
        }

        private string getOwnerName()
        {
            Console.Clear();
            Console.Write("Please enter your name: ");
            string ownerName = Console.ReadLine();
            while (string.IsNullOrEmpty(ownerName) || string.IsNullOrEmpty(ownerName.Trim()))
            {
                Console.WriteLine("Invalid input! Please enter a non empty string");
                Console.Write("Please enter your name: ");
                ownerName = Console.ReadLine();
            }

            return ownerName;
        }

        private string getLicensePlaterNumberFromUser()
        {
            Console.Clear();
            Console.WriteLine("Please enter vehicle license plate number: ");
            string licensePlateSrting = Console.ReadLine();
            while (string.IsNullOrEmpty(licensePlateSrting) || string.IsNullOrEmpty(licensePlateSrting.Trim()))
            {
                Console.WriteLine("Invalid input! Please enter a non empty string");
                Console.Write("License Plate Number: ");
                licensePlateSrting = Console.ReadLine();
            }

            return licensePlateSrting;
        }

        private eOptions getMainMenuChoice()
        {
            int choiceNum;

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();
            
            while (!isValidInput(input, 1, 7, out choiceNum))
            {
                Console.WriteLine("Invalid input! Please enter a digit between 1 to 7");
                Console.Write("Enter your choice: ");
                input = Console.ReadLine();
            }

            return (eOptions) choiceNum;
        }

        private bool isValidInput(string i_Input, int i_MinRange, int i_MaxRange, out int o_ChoiceNum)
        {
            bool isValid = true;

            if (!int.TryParse(i_Input, out o_ChoiceNum))
            {
                isValid = false;
            }
            else if (o_ChoiceNum < i_MinRange || o_ChoiceNum > i_MaxRange)
            {
                isValid = false;
            }

            return isValid;
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
                m_Garage.GetLicenseNumbersByStatus(filter);

            }
            else if (i_Operation == m_MainMenu[2])
            {
                string licenseNumber = getLicenseNumber();
                eStatus status = (eStatus)Enum.Parse(typeof(eStatus), getOptionFromMenu(m_Status, "To what status you want to change"));
                m_Garage.ChangeVehicleStatus(licenseNumber, status);
            }
            else if (i_Operation == m_MainMenu[3])
            {
                string licenseNumber = getLicenseNumber();
                m_Garage.PumpAirInWheels(licenseNumber);
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
                m_Garage.PumpFuel(licenseNumber,fuelType,amount);
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
                m_Garage.ChargeBettery(licenseNumber,amount);
            }
            else if (i_Operation == m_MainMenu[6])
            {
                string licenseNumber = getLicenseNumber();
                m_Garage.GetVehicleDetails(licenseNumber);

            }

        }


        private void addVehicle() 
        {
            Console.WriteLine("Please enter license number");
            string liceseNumber = Console.ReadLine();

            if (m_Garage.DoesVehicleExist(liceseNumber)) 
            {
                m_Garage.ChangeVehicleStatus(liceseNumber, eStatus.InProgress);
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




        private string getOptionFromMenu(string[] i_Options, string i_GenericMessage)
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

        private void printGenericMenuFromArray(string[] i_StringArray) 
        {
            StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.Append(Environment.NewLine);
            for (int i = 0; i < i_StringArray.Length; i++)
            {
                stringBuilder.AppendLine(string.Format("{0}. {1}", i + 1, i_StringArray[i]));
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
