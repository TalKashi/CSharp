using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    class GarageMenu
    {
        private Garage m_grage;

        public GarageMenu()
        {
            m_grage = new Garage();
        }

        public void AddVehicle() 
        {
            Console.WriteLine("Please enter license number");
            string licesePlate = Console.ReadLine();

            Console.WriteLine("Please enter your name ");
            string ownerName = Console.ReadLine();

            Console.WriteLine("Please enter your phone");
            string ownerPhone = Console.ReadLine();

            string vehicle = getVehicle();

            Console.WriteLine("Please enter wheels manufacture");
            string wheelsManufacture = Console.ReadLine();

        }


        public void DisplayVehicleLicensePlateByStatus(eStatus i_status) 
        {
            m_grage.GetLicenseNumbersByStatus(i_status);
        }

        public void ChangeVehicleStatus(string i_licensePlate, eStatus i_status)
        {
            m_grage.ChangeVehicleStatus(i_licensePlate, i_status);
        }

        public void PumpAirToMax(string i_licensePlate)
        {
            m_grage.PumpAirInWheels(i_licensePlate);
        }


        public void AddFuel(string i_licensePlate, eFuelType i_fuelType, float i_amount) 
        {
            m_grage.PumpFuel(i_licensePlate, i_fuelType, i_amount);
        }

        public void ChargeBettary(string i_licensePlate, float i_amount) 
        {
            m_grage.ChargeBettery(i_licensePlate, i_amount);
        }

        public void DisplayInfo(string i_licensePlate) 
        {
            m_grage.GetVehicleDetails(i_licensePlate);
        }


        private string getVehicle() 
        {
            int userChoose;
            StringBuilder vehicleMenu;
            //get vehicle list
            vehicleList = m_grage.GetVehicleList();

            for (int i = 0 ; i < getVehicleList.lenght ; i++)
            {
               vehicleMenu.Append(string.Format("For {0} press {1}",getVehicleList[i],i));
               vehicleMenu.Append(Environment.NewLine);
            }
            Console.WriteLine(vehicleMenu.ToString());
            string vehicleType = Console.ReadLine();
            while(!isValidVehicle(getVehicleList.lenght,vehicleType,userChoise))
            {
                Console.WriteLine("Wrong input, please enter number in range");
                vehicleType = Console.ReadLine();
            }

            return vehicleList[userChoise];
        }


        private bool isValidVehicle(int i_upperRangeBound, string i_userInput, out int o_userChoise)
        {
            bool isValid  = false;
            o_userChoise = -1;
            if (Int32.TryParse(i_userInput,out o_userChoise)){
                isValid = (0 <= o_userChoise &&  o_userChoise < i_upperRangeBound);
            }
            return isValid;
        }

        private string[] GetVehicleList() 
        {
            string[] vehicleTypes = { "Car(Fuel)", "Car(Electric)", "Motorcycle(Fuel)", "Motorcycle(Electric)", "Truck" };
            return vehicleTypes;
        }

    }
}
