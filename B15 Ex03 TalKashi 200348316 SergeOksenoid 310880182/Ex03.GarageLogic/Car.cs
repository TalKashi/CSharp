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

        public enum eNumOfDoors
        {
            TwoDoors = 2,
            ThreeDoors = 3,
            FourDoors = 4,
            FiveDoors = 5
        }
        
        private eCarColor m_CarColor;
        private eNumOfDoors m_NumOfDoors;

        public Car(string i_LicenseNumber, string i_VehicleModel, List<Wheel> i_WheelsList, Engine i_Engine, eCarColor i_Color, eNumOfDoors i_NumOfDoors)
            : base(i_LicenseNumber, i_VehicleModel, i_WheelsList, i_Engine)
        {
            m_CarColor = i_Color;
            m_NumOfDoors = i_NumOfDoors;
        }

        public override string ToString()
        {
            return string.Format(
@"{0}

Color: {1}
Number of Doors: {2}",
                base.ToString(),
                m_CarColor,
                m_NumOfDoors);
        }
    }
}
