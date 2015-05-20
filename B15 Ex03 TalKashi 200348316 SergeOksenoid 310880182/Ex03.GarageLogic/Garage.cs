using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleCard> m_Costomers;

        public void AddNewVehicle(string i_LicenceNumber, Type i_TypeOfVehicle)
        {
            // TODO: Research
        }

        public string GetLicenseNumber(string i_FilterBy)
        {
            return null;
        }

        public void ChangeVehicleStatus(string i_LicenceNumber, eStatus i_NewStatus)
        {
            
        }

        public void PumpAirInWheels(string i_LicenceNumber)
        {
            
        }

        public void PumpFuel(string i_LicenceNumber, eFuelType i_FuelType, float i_AmountToAdd)
        {
            
        }

        public void ChargeBettery(string i_LicenceNumber, float i_MinutesToCharge)
        {
            
        }

        public string GetVehicleDetails(string i_LicenceNumber)
        {
            
        }
    }
}
