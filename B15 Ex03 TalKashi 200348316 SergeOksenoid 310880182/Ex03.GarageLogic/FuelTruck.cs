using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class FuelTruck : Truck
    {
        public FuelTruck(string i_LicenseNumber, string i_VehicleModel, List<Wheel> i_WheelsList, FuelEngine i_Engine, bool i_IsCarryingDangerousMaterials, float i_CurrentCarryingWeight)
            : base(i_LicenseNumber, i_VehicleModel, i_WheelsList, i_Engine, i_IsCarryingDangerousMaterials, i_CurrentCarryingWeight)
        {
            // Do nothing
        }

        internal FuelTruck()
        {
            // For dummy object
        }

        public void PumpFuel(float i_LitresToAdd, FuelEngine.eFuelType i_FuelType)
        {
            ((FuelEngine)m_Engine).PumpFuel(i_LitresToAdd, i_FuelType);
        }
    }
}
