using System;
using System.Text;
using Ex03.GarageLogic;
using System.Collections.Generic;

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

        private string[] m_MainMenu =
        {
            "adding new vehicle to the garage",
            "display vehicles by thier status",
            "changing vehicle status",
            "pump air",
            "pump fuel",
            "charge bettary",
            "display info"
        };

        private string[] m_Status = {"InRepair", "Repaired", "Paid"};
        private string[] m_FuelType = {"Octan95", "Octan96", "Octan98", "Soler"};
        private string[] m_MotorcycleLicense = {"A", "A2", "AB", "B1"};
        private string[] m_CarColor = {"Green", "Black", "White", "Red"};
        private string[] m_Doors = {"2 doors", "3 doors", "4 doors", "5 doors"};
        private string[] m_TruckCarryingDangerousCargo = {"Yes", "No"};

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
                    //showInflateAirMenu();
                    break;
                case eOptions.PumpFuel:
                    //showPumpFuelMenu();
                    break;
                case eOptions.ChargeBattery:
                    //showChargeBatteryMenu();
                    break;
                case eOptions.DisplayVehicleDetails:
                    //showDisplayVehicleDetailsMenu();
                    break;
            }

            Console.WriteLine("{0}Press Enter to continue", Environment.NewLine);
            Console.ReadLine();
            Console.Clear();
        }

        private void showUpdateVehicleStatusMenu()
        {
            Console.Clear();
            string licencePlateStr = getLicensePlaterNumberFromUser();

            if (!m_Garage.DoesVehicleExist(licencePlateStr))
            {
                Console.Clear();
                Console.WriteLine("The given licence plate '{0}' does not exist in out database!", licencePlateStr);
            }
            else
            {
                const bool v_IgnoreCase = true;
                eStatus newStatus = eStatus.None;

                Console.Clear();
                Console.WriteLine(
@"Please enter the new status of the vehicle:
1. In Repair
2. Repaired
3. Paid");

                Console.WriteLine();
                Console.Write("New status: ");
                while (newStatus == eStatus.None)
                {
                    string newStatusStr = Console.ReadLine();
                    if (string.IsNullOrEmpty(newStatusStr))
                    {
                        Console.WriteLine("Please enter a non-empty string. Try again");
                    }
                    else
                    {
                        try
                        {
                            newStatus = (eStatus) Enum.Parse(typeof (eStatus), newStatusStr, v_IgnoreCase);
                            if (newStatus == eStatus.None)
                            {
                                Console.WriteLine("Invalid input! Try again");
                            }
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Invalid input! Try again");
                        }
                    }
                }

                m_Garage.ChangeVehicleStatus(licencePlateStr, newStatus);
                Console.Clear();
                Console.WriteLine("Vehicle with licence plate '{0}' status has been updated", licencePlateStr);
            }
        }

        private void showDisplayLicensePlatesMenu()
        {
            Console.Clear();
            Console.WriteLine(
@"Please choose how you want to filter the displayed license plates:
1. In Repair
2. Repaired
3. Paid
4. None");
            eStatus filterBy = getFilterBy();

            Console.Clear();
            Console.WriteLine(m_Garage.GetLicenseNumbers(filterBy));
        }

        private eStatus getFilterBy()
        {
            eStatus filterBy = eStatus.None;
            const bool v_IgnoreCase = true;
            bool parsedSuccesfully = false;

            Console.WriteLine();
            Console.Write("Filter by: ");

            while (!parsedSuccesfully)
            {
                string filterByStr = Console.ReadLine();

                if (string.IsNullOrEmpty(filterByStr))
                {
                    Console.WriteLine("Please enter a non-empty string. Try again");
                }
                else
                {
                    try
                    {
                        filterBy = (eStatus) Enum.Parse(typeof (eStatus), filterByStr, v_IgnoreCase);
                        parsedSuccesfully = true;
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Invalid input! Try again");
                    }
                }
            }

            return filterBy;
        }

        private void showEnterVehicleMenu()
        {
            string licensePlateSrting = getLicensePlaterNumberFromUser();

            if (m_Garage.DoesVehicleExist(licensePlateSrting))
            {
                m_Garage.ChangeVehicleStatus(licensePlateSrting, eStatus.InRepair);
                Console.Clear();
                Console.WriteLine("We already have this vehicle in our database. Status change to 'In Repair'");
            }
            else
            {
                const string k_Fuel = "Fuel";
                const bool v_IsFuel = true;

                string ownerName = getOwnerName();
                string ownerPhone = getOwnerPhone();
                string vehicleType = getVehicleType();
                string vehicleModel = getVehicleModel();
                float energyLeft;

                if (vehicleType.Contains(k_Fuel))
                {
                    energyLeft = getEnergyLeft(v_IsFuel);
                }
                else
                {
                    energyLeft = getEnergyLeft(!v_IsFuel);
                }

                string wheelManufacturer = getWheelManufecturer();
                float wheelCurrentAirPressure = getWheelCurrentAirPressure();

                int i = 0;

                List<KeyValuePair<string, Type>> requiredDataList =
                    VehicleInfo.GetRequiredDataOfSpecificVehicleType(vehicleType);
                string[] parameters = new string[requiredDataList.Count];
                foreach (KeyValuePair<string, Type> requiredData in requiredDataList)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter {0}", requiredData.Key);

                    if (requiredData.Value.IsEnum)
                    {
                        Console.WriteLine("Enter one of the values below:");
                        string[] enumNames = Enum.GetNames(requiredData.Value);

                        foreach (string name in enumNames)
                        {
                            Console.WriteLine("{0}", name);
                        }

                        Console.WriteLine();
                    }
                    else if (requiredData.Value == typeof (bool))
                    {
                        Console.Write("Enter 'Y' or 'N': ");

                    }

                    string input = Console.ReadLine();

                    while (string.IsNullOrEmpty(input) || input.Trim().Length == 0)
                    {
                        Console.WriteLine("Please enter a non-empty string. Try again");
                        input = Console.ReadLine();
                    }

                    parameters[i] = input;
                    i++;
                }

                try
                {
                    m_Garage.AddNewVehicle(vehicleType, licensePlateSrting, vehicleModel, ownerName, ownerPhone,
                        energyLeft,
                        wheelManufacturer, wheelCurrentAirPressure, parameters);
                    Console.Clear();
                    Console.WriteLine("We have entered your vehicle into our system.");
                }
                catch (ArgumentException)
                {
                    Console.Clear();
                    Console.WriteLine("One or more of the given arguments you have entered are not valid. Try again");
                }
                catch (ValueOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("One or more of the given argument you have entered are out of valid range. Try again");
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("One or more of the given arguments you have entered are not valid format. Try again");
                }
            }
        }

        private string getVehicleModel()
        {
            Console.Clear();
            Console.WriteLine("Please enter the vehicle model");
            string vehicleModel = Console.ReadLine();

            while (string.IsNullOrEmpty(vehicleModel) || vehicleModel.Trim().Length == 0)
            {
                Console.WriteLine("Please enter a non-empty string. Try again");
                vehicleModel = Console.ReadLine();
            }

            return vehicleModel;
        }

        private float getWheelCurrentAirPressure()
        {
            float currentAirPressure;

            Console.Clear();
            Console.WriteLine("Please enter the current air pressure in your wheels");
            string currentAirPressureStr = Console.ReadLine();

            while (!float.TryParse(currentAirPressureStr, out currentAirPressure) && currentAirPressure < 0)
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Please enter a positive value: ");
                currentAirPressureStr = Console.ReadLine();
            }

            return currentAirPressure;
        }

        private string getWheelManufecturer()
        {
            Console.Clear();
            Console.WriteLine("Please enter wheel manufecturer");
            string wheelManufecturer = Console.ReadLine();

            while (string.IsNullOrEmpty(wheelManufecturer) || wheelManufecturer.Trim().Length == 0)
            {
                Console.WriteLine("Please enter a non-empty string. Try again");
                wheelManufecturer = Console.ReadLine();
            }

            return wheelManufecturer;
        }

        private float getEnergyLeft(bool i_IsFuel)
        {
            float energyLeft;
            string msg = string.Format("Please enter {0}",
                i_IsFuel ? "litres left in fuel tank" : "hours left int battery");

            Console.Clear();
            Console.WriteLine(msg);
            string energyLeftStr = Console.ReadLine();

            while (!float.TryParse(energyLeftStr, out energyLeft) && energyLeft < 0)
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Please enter a positive value: ");
                energyLeftStr = Console.ReadLine();
            }

            return energyLeft;
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
            Console.Write("Please enter vehicle license plate number: ");
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
            Console.WriteLine();
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

        //private void executeSelectedOparetion(string i_Operation)
        //{
        //    if (i_Operation == m_MainMenu[0]) 
        //    {
        //        addVehicle();
        //    }
        //    else if (i_Operation == m_MainMenu[1]) 
        //    {
        //        eStatus filter = (eStatus)Enum.Parse(typeof(eStatus), getOptionFromMenu(m_Status, "Please select your filter"));
        //        m_Garage.GetLicenseNumbersByStatus(filter);

        //    }
        //    else if (i_Operation == m_MainMenu[2])
        //    {
        //        string licenseNumber = getLicenseNumber();
        //        eStatus status = (eStatus)Enum.Parse(typeof(eStatus), getOptionFromMenu(m_Status, "To what status you want to change"));
        //        m_Garage.ChangeVehicleStatus(licenseNumber, status);
        //    }
        //    else if (i_Operation == m_MainMenu[3])
        //    {
        //        string licenseNumber = getLicenseNumber();
        //        m_Garage.PumpAirInWheels(licenseNumber);
        //    }
        //    else if (i_Operation == m_MainMenu[4])
        //    {
        //        float amount;
        //        string licenseNumber = getLicenseNumber();
        //        Console.WriteLine("Please enter the amount of fuel to you to add");
        //        string amountInput = Console.ReadLine();
        //        //eFuelType fuelType = (eFuelType)Enum.Parse(typeof(eFuelType), getOptionFromMenu(m_FuelType, "What type of fuel?"));
        //        while (float.TryParse(amountInput, out amount)) 
        //        {
        //            Console.WriteLine("Wrong input type");
        //            amountInput = Console.ReadLine();
        //        }
        //        m_Garage.PumpFuel(licenseNumber,fuelType,amount);
        //    }
        //    else if (i_Operation == m_MainMenu[5])
        //    {
        //        float amount;
        //        string licenseNumber = getLicenseNumber();
        //        Console.WriteLine("Please enter the amount in minutes");
        //        string amountInput = Console.ReadLine();
        //        while (float.TryParse(amountInput, out amount)) 
        //        {
        //            Console.WriteLine("Wrong input type");
        //            amountInput = Console.ReadLine();
        //        }
        //        m_Garage.ChargeBettery(licenseNumber,amount);
        //    }
        //    else if (i_Operation == m_MainMenu[6])
        //    {
        //        string licenseNumber = getLicenseNumber();
        //        m_Garage.GetVehicleDetails(licenseNumber);

        //    }

        //    }


        //    private void addVehicle() 
        //    {
        //        Console.WriteLine("Please enter license number");
        //        string liceseNumber = Console.ReadLine();

        //        if (m_Garage.DoesVehicleExist(liceseNumber)) 
        //        {
        //            m_Garage.ChangeVehicleStatus(liceseNumber, eStatus.InRepair);
        //            return;
        //        }

        //        Console.WriteLine("Please enter your name ");
        //        string ownerName = Console.ReadLine();

        //        Console.WriteLine("Please enter your phone number");
        //        string ownerPhone = Console.ReadLine();

        //        string vehicle = getOptionFromMenu(VehicleInfo.GetVehicleList(),"Please select your vehicle type");

        //        Console.WriteLine("Please enter your vehicle model");
        //        string vehicleModel = Console.ReadLine();

        //        Console.WriteLine("Please enter wheels manufacture");
        //        string wheelsManufacture = Console.ReadLine();

        //        Console.WriteLine("Please enter current air pressure in your wheels");
        //        string currentAirPressure = Console.ReadLine();

        //        string[] vehicleProperties = getPropertiesOfVehicle(vehicle);
        //    }




        //    private string getOptionFromMenu(string[] i_Options, string i_GenericMessage)
        //    {
        //        int userChoise;

        //        //printGenericMenuFromArray(i_Options, i_GenericMessage);
        //        string vehicleType = Console.ReadLine();
        //        while (!isValidVehicle(i_Options.Length, vehicleType, out userChoise))
        //        {
        //            Console.WriteLine("Wrong input, please enter number in range");
        //            vehicleType = Console.ReadLine();
        //        }

        //        return i_Options[userChoise];
        //    }


        //    private bool isValidVehicle(int i_UpperRangeBound, string i_UserInput, out int o_UserChoise)
        //    {
        //        bool isValid  = false;
        //        o_UserChoise = -1;
        //        if (Int32.TryParse(i_UserInput,out o_UserChoise)){
        //            isValid = (0 <= o_UserChoise &&  o_UserChoise < i_UpperRangeBound);
        //        }
        //        return isValid;
        //    }

        //    private void printGenericMenuFromArray(string[] i_StringArray) 
        //    {
        //        StringBuilder stringBuilder = new StringBuilder();
        //        //stringBuilder.Append(Environment.NewLine);
        //        for (int i = 0; i < i_StringArray.Length; i++)
        //        {
        //            stringBuilder.AppendLine(string.Format("{0}. {1}", i + 1, i_StringArray[i]));
        //        }

        //        Console.WriteLine(stringBuilder.ToString());
        //    }

        //    private string[] getPropertiesOfVehicle(string i_Vehicle)
        //    {
        //        string[] properties;
        //        switch (i_Vehicle)
        //        {
        //            case "Car(Fuel)":
        //            case "Car(Electric)":
        //                properties = new string[2];
        //                properties[0] = getOptionFromMenu(m_CarColor, "Please choose car color");
        //                properties[1] = getOptionFromMenu(m_Doors, "Please select how many doors your car has");
        //                break;
        //            case "Motorcycle(Fuel)":
        //            case "Motorcycle(Electric)":
        //                properties = new string[2];
        //                Console.WriteLine("Whats your engine volume?");
        //                properties[0] = Console.ReadLine();
        //                properties[1] = getOptionFromMenu(m_MotorcycleLicense, "Please select your license type");
        //                break;
        //            case "Truck(Fuel)":
        //                properties = new string[2];
        //                properties[0] = getOptionFromMenu(m_TruckCarryingDangerousCargo, "Is your truck carrying dangerous cargo");
        //                Console.WriteLine("Whats your currnet truck weight?");
        //                properties[1] = Console.ReadLine();
        //                break;
        //            default:
        //                properties = null;
        //                break;

        //        }
        //        return properties;
        //    }


        //}
    }
}