using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleCard> m_VehicleCards;

        public void AddNewVehicle(string i_LicenceNumber, Type i_TypeOfVehicle)
        {
            // TODO: Research
        }

        public bool DoesVehicleExist(string i_LicenceNumber)
        {
            return m_VehicleCards.ContainsKey(i_LicenceNumber);
        }

        public string GetLicenseNumbers()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (VehicleCard vehicleCard in m_VehicleCards.Values)
            {
                stringBuilder.AppendLine(vehicleCard.Vehicle.LicenseNumber);
            }

            return stringBuilder.ToString();
        }

        public string GetLicenseNumbersByStatus(eStatus i_FilterByStatus)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (VehicleCard vehicleCard in m_VehicleCards.Values)
            {
                if (vehicleCard.VehicleStatus == i_FilterByStatus)
                {
                    stringBuilder.AppendLine(vehicleCard.Vehicle.LicenseNumber);
                }
            }

            return stringBuilder.ToString();
        }

        public void ChangeVehicleStatus(string i_LicenceNumber, eStatus i_NewStatus)
        {
            m_VehicleCards[i_LicenceNumber].VehicleStatus = i_NewStatus;
        }

        public void PumpAirInWheels(string i_LicenceNumber)
        {
            List<Wheel> wheels = m_VehicleCards[i_LicenceNumber].Vehicle.Wheels;

            foreach (Wheel wheel in wheels)
            {
                wheel.PumpAir(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }

        public void PumpFuel(string i_LicenceNumber, eFuelType i_FuelType, float i_AmountToAdd)
        {
            if (!(m_VehicleCards[i_LicenceNumber].Vehicle.Engine is FuelEngine))
            {
                // TODO: Throw some excpetion???
            }

            FuelEngine fuelEngine = (FuelEngine) m_VehicleCards[i_LicenceNumber].Vehicle.Engine;
            fuelEngine.PumpFuel(i_AmountToAdd, i_FuelType);
        }

        public void ChargeBettery(string i_LicenceNumber, float i_MinutesToCharge)
        {
            const float k_MinutesInHour = 60;

            if (!(m_VehicleCards[i_LicenceNumber].Vehicle.Engine is ElectricEngine))
            {
                // TODO: Throw some excpetion???
            }

            ElectricEngine electricEngineEngine = (ElectricEngine)m_VehicleCards[i_LicenceNumber].Vehicle.Engine;
            electricEngineEngine.ChargeBattery(i_MinutesToCharge / k_MinutesInHour);
        }

        public string GetVehicleDetails(string i_LicenceNumber)
        {
            return m_VehicleCards[i_LicenceNumber].ToString();
        }
    }
}
