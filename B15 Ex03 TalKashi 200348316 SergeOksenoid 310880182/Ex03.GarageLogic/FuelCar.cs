using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class FuelCar : Car
    {
        public FuelEngine.eFuelType FuelType
        {
            get
            {
                return ((FuelEngine)m_Engine).FuelType;
            }
        }

        public FuelCar(string i_LicenseNumber, string i_VehicleModel, List<Wheel> i_WheelsList, FuelEngine i_FuelEngine, eCarColor i_Color, eNumOfDoors i_NumOfDoors)
            : base(i_LicenseNumber, i_VehicleModel, i_WheelsList, i_FuelEngine, i_Color, i_NumOfDoors)
        {
            // Do nothing
        }

        internal FuelCar()
        {
            // For dummy object
        }

        public void PumpFuel(float i_LitresToAdd, FuelEngine.eFuelType i_FuelType)
        {
            ((FuelEngine)m_Engine).PumpFuel(i_LitresToAdd, i_FuelType);
        }
    }
}
