using System;
using System.Collections.Generic;
using System.Reflection;
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
            Type vehicleType = m_VehicleCards[i_LicenceNumber].Vehicle.GetType();
            MethodInfo pumpFuelMethod = null;

            foreach (MethodInfo method in vehicleType.GetMethods())
            {
                if (method.Name == "PumpFuel")
                {
                    pumpFuelMethod = method;
                    break;
                }
            }

            if (pumpFuelMethod == null)
            {
                throw new ArgumentException(string.Format("The vehicle by {0} licence number does not have a fuel engine", i_LicenceNumber));
            }

            pumpFuelMethod.Invoke(m_VehicleCards[i_LicenceNumber].Vehicle, new object[] {i_FuelType, i_AmountToAdd});
        }

        public void ChargeBettery(string i_LicenceNumber, float i_MinutesToCharge)
        {
            const float k_MinutesInHour = 60;

            Type vehicleType = m_VehicleCards[i_LicenceNumber].Vehicle.GetType();
            MethodInfo chargeBatteryMethod = null;

            foreach (MethodInfo method in vehicleType.GetMethods())
            {
                if (method.Name == "ChargeBattery")
                {
                    chargeBatteryMethod = method;
                    break;
                }
            }

            if (chargeBatteryMethod == null)
            {
                throw new ArgumentException(string.Format("The vehicle by {0} licence number does not have an electric engine", i_LicenceNumber));
            }

            chargeBatteryMethod.Invoke(m_VehicleCards[i_LicenceNumber].Vehicle, new object[] {i_MinutesToCharge / k_MinutesInHour});
        }

        public string GetVehicleDetails(string i_LicenceNumber)
        {
            return m_VehicleCards[i_LicenceNumber].ToString();
        }
    }
}
