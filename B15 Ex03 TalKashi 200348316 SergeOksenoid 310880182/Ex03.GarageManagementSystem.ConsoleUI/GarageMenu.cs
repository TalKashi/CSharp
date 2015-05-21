using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    class GarageMenu
    {
        public void AddVehicle() 
        {
            Console.WriteLine("Please enter license plate");
            string licesePlate = Console.ReadLine();

            string vehicle = getVehicle();

            string engine = getEngine();

            Console.WriteLine("Please enter wheels manufacture");
            string wheelsManufacture = Console.ReadLine();

        }


        public void DisplayVehicleLicensePlateByStatus(int i_status) 
        {
        
        }

        public void ChangeVehicleStatus(string i_licensePlate, string i_status)
        {

        }

        public void PumpAirToMax(string i_licensePlate)
        {

        }


        public void AddFuel(string i_licensePlate, string i_fuelType, float i_amount) 
        {
        
        }

        public void ChargeBettary(string i_licensePlate, float i_amount) 
        {
        
        }

        public void DisplayInfo(string i_licensePlate) 
        {
        
        }


        private string getVehicle() 
        {
            int userChoose;
            StringBuilder vehicleMenu;
            //get vehicle list
            vehicleList =  Garage.getVehicleList;
            int i = 0;
            for (int i = 0 ; i < getVehicleList.lenght ; i++)
            {
               vehicleMenu.Append(string.Format("For {0} press {1}",getVehicleList[i],i));
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

        private string getEngine() 
        {
            string engineMessage = string.Format(@"What kind of engine do you have?
Press 0 for Fuel Engine
Press 1 for Electric Engine");

            Console.WriteLine(engineMessage.ToString());
            string engine = Console.ReadLine();
            while (engine != "0" && engine != "1") 
            {
                Console.WriteLine("Wrong input,Please enter 0 for Fuel Engine or 1 for Electric Engine");
                engine = Console.ReadLine();
            }

            return (engine == "0" ? "fuelEngine" : "electricEngine");
        }

        private bool isValidVehicle(int i_upperRangeBound, string i_userInput, out int o_userChoise)
        {
            bool isValid  = false;
            o_userChoise = -1;
            try 
            {
               o_userChoise = Convert.ToInt32(i_userInput);
               isValid = (0 <= o_userChoise &&  o_userChoise < i_upperRangeBound);
            }
            catch (ArgumentException ae)
            {
            }

            return isValid;
        }

    }
}
