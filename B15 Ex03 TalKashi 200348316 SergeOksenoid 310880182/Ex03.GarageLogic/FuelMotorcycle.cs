using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : Motorcycle
    {
        public FuelMotorcycle(string i_LicenseNumber, string i_VehicleModel, List<Wheel> i_WheelsList, eLicenseType i_LicenseType, FuelEngine i_FuelEngine)
            : base(i_LicenseNumber, i_VehicleModel, i_WheelsList, i_LicenseType, i_FuelEngine)
        {
            // Do nothing
        }

        public void PumpFuel(float i_LitresToAdd, eFuelType i_FuelType)
        {
            ((FuelEngine)m_Engine).PumpFuel(i_LitresToAdd, i_FuelType);
        }
    }
}
