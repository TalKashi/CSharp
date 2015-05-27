using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        public ElectricMotorcycle(string i_LicenseNumber, string i_VehicleModel, List<Wheel> i_WheelsList, eLicenseType i_LicenseType, ElectricEngine i_ElectricEngine)
            : base(i_LicenseNumber, i_VehicleModel, i_WheelsList, i_LicenseType, i_ElectricEngine)
        {
            // Do nothing
        }

        internal ElectricMotorcycle()
        {
            // For dummy object
        }

        public void ChargeBattery(float i_HoursToAdd)
        {
            ((ElectricEngine)m_Engine).ChargeBattery(i_HoursToAdd);
        }
    }
}
