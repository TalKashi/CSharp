using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        public enum eCarColor
        {
            Green,
            Black,
            White,
            Red
        }
        
        private eCarColor m_CarColor;
        private eNumOfDoors m_NumOfDoors;

        public Car(string i_LicenseNumber, string i_VehicleModel, List<Wheel> i_WheelsList, Engine i_Engine,
            eCarColor i_Color, eNumOfDoors i_NumOfDoors)
            : base(i_LicenseNumber, i_VehicleModel, i_WheelsList, i_Engine)
        {
            m_CarColor = i_Color;
            m_NumOfDoors = i_NumOfDoors;
        }
       
    }
}
