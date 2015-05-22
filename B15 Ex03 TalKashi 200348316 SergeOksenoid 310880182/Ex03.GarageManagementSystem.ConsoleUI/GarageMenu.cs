using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    class GarageMenu
    {
        private Garage m_Grage;

        string[] m_MotorcycleLicense = {"A","A2","AB","B1"};
        string[] m_CarColor = { "Green", "Black", "White", "Red"};
        string[] m_Doors = { "2 doors", "3 doors", "4 doors", "5 doors" };
        string[] m_TruckCarryingDangerousCargo = {"Yes","No"};




        public GarageMenu()
        {
            m_Grage = new Garage();
        }

        public void AddVehicle() 
        {
            Console.WriteLine("Please enter license number");
            string liceseNumber = Console.ReadLine();

            if (m_Grage.DoesVehicleExist(liceseNumber)) 
            {
                ChangeVehicleStatus(liceseNumber, eStatus.InProgress);
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


        public void DisplayVehicleLicensePlateByStatus(eStatus i_Status) 
        {
            m_Grage.GetLicenseNumbersByStatus(i_Status);
        }

        public void ChangeVehicleStatus(string i_LicensePlate, eStatus i_Status)
        {
            m_Grage.ChangeVehicleStatus(i_LicensePlate, i_Status);
        }

        public void PumpAirToMax(string i_LicensePlate)
        {
            m_Grage.PumpAirInWheels(i_LicensePlate);
        }


        public void AddFuel(string i_LicensePlate, eFuelType i_FuelType, float i_Amount) 
        {
            m_Grage.PumpFuel(i_LicensePlate, i_FuelType, i_Amount);
        }

        public void ChargeBettary(string i_LicensePlate, float i_Amount) 
        {
            m_Grage.ChargeBettery(i_LicensePlate, i_Amount);
        }

        public void DisplayInfo(string i_LicensePlate) 
        {
            m_Grage.GetVehicleDetails(i_LicensePlate);
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
