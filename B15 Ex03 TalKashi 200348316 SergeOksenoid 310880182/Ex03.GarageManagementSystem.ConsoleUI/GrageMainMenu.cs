﻿using System;
using System.Text;
using System.Collections.Generic;
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

            Console.WriteLine("{0}Press Enter to continue", Environment.NewLine);
            Console.ReadLine();
            Console.Clear();
        }

        private void showDisplayVehicleDetailsMenu()
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
                Console.Clear();
                Console.WriteLine(m_Garage.GetVehicleDetails(licencePlateStr));
            }
        }

        private void showChargeBatteryMenu()
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
                const bool v_IsFuel = true;
                float minutesToCharge = getEnergyToFill(!v_IsFuel);

                Console.Clear();
                try
                {
                    m_Garage.ChargeBettery(licencePlateStr, minutesToCharge);
                    Console.WriteLine("Vehicle with licence plate '{0}' battery has been charged", licencePlateStr);
                }
                catch (ValueOutOfRangeException)
                {
                    Console.WriteLine("The amount of minutes you have given has exceeded the capacity of the battery");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("One or more of the arguments you have entered are invalid");
                }
            }
        }

        private void showPumpFuelMenu()
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
                const bool v_IsFuel = true;
                int fuelType = getFuelType();
                float litresToFill = getEnergyToFill(v_IsFuel);

                Console.Clear();
                try
                {
                    m_Garage.PumpFuel(licencePlateStr, fuelType, litresToFill);
                    Console.WriteLine("Vehicle with licence plate '{0}' fuel tank has been filled", licencePlateStr);
                }
                catch (ValueOutOfRangeException)
                {
                    Console.WriteLine("The amount of litres you have given has exceeded the capacity of the fuel tank");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("One or more of the arguments you have entered are invalid");
                }
            }
        }

        private float getEnergyToFill(bool i_IsFuel)
        {
            float energyToFill;
            string msg = i_IsFuel ? "Litres to fill: " : "Minutes to charge: ";

            Console.Clear();
            Console.Write(msg);

            string litresToFillStr = Console.ReadLine();
            while (!isValidInput(litresToFillStr, 0, float.MaxValue, out energyToFill))
            {
                Console.WriteLine("Invalid input! Try again");
                litresToFillStr = Console.ReadLine();
            }

            return energyToFill;
        }

        private int getFuelType()
        {
            int fuelType;

            Console.Clear();
            Console.WriteLine(
@"Please enter fuel type: (enter the digit of the fuel type)
1. Soler
2. Octan95
3. Octan96
4. Octan98");

            Console.WriteLine();
            Console.Write("Fuel Type: ");
            string fuelTypeStr = Console.ReadLine();
            while (!isValidInput(fuelTypeStr, 1, 4, out fuelType))
            {
                Console.WriteLine("Invalid input! Try again");
                fuelTypeStr = Console.ReadLine();
            }

            return fuelType;
        }

        private void showInflateAirMenu()
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
                m_Garage.PumpAirInWheels(licencePlateStr);
                Console.Clear();
                Console.WriteLine("Vehicle with licence plate '{0}' wheels has been inflated to max", licencePlateStr);
            }
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
                            newStatus = (eStatus) Enum.Parse(typeof(eStatus), newStatusStr, v_IgnoreCase);
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
                        filterBy = (eStatus) Enum.Parse(typeof(eStatus), filterByStr, v_IgnoreCase);
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
                    else if (requiredData.Value == typeof(bool))
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
                    m_Garage.AddNewVehicle(vehicleType, licensePlateSrting, vehicleModel, ownerName, ownerPhone, energyLeft, wheelManufacturer, wheelCurrentAirPressure, parameters);
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

            while (!float.TryParse(currentAirPressureStr, out currentAirPressure) || currentAirPressure < 0)
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
            string msg = string.Format("Please enter {0}", i_IsFuel ? "litres left in fuel tank" : "hours left int battery");

            Console.Clear();
            Console.WriteLine(msg);
            string energyLeftStr = Console.ReadLine();

            while (!float.TryParse(energyLeftStr, out energyLeft) || energyLeft < 0)
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

        private bool isValidInput(string i_Input, float i_MinRange, float i_MaxRange, out float o_ChoiceNum)
        {
            bool isValid = true;

            if (!float.TryParse(i_Input, out o_ChoiceNum))
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

            for (int i = 0; i < i_StringArray.Length; i++)
            {
                stringBuilder.AppendLine(string.Format("{0}. {1}", i + 1, i_StringArray[i]));
            }

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}