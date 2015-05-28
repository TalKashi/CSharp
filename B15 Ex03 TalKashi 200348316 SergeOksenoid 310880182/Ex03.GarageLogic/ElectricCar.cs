using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : Car
    {
        public ElectricCar(string i_LicenseNumber, string i_VehicleModel, List<Wheel> i_WheelsList, ElectricEngine i_ElectircEngine, eCarColor i_Color, eNumOfDoors i_NumOfDoors)
            : base(i_LicenseNumber, i_VehicleModel, i_WheelsList, i_ElectircEngine, i_Color, i_NumOfDoors)
        {
            // Nothing to do.
        }

        internal ElectricCar()
        {
            // For dummy object
        }

        public void ChargeBattery(float i_HoursToAdd)
        {
            ((ElectricEngine) m_Engine).ChargeBattery(i_HoursToAdd);
        }
    }
}
