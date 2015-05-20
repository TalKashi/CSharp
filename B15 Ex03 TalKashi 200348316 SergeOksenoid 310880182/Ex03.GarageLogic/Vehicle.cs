using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public enum eNumOfDoors
    {
        TwoDoors = 2,
        ThreeDoors = 3,
        FourDoors = 4,
        FiveDoors = 5
    }

    public enum eFuelType
    {
        Soler, 
        Octan95,
        Octan96, 
        Octan98
    }

    public enum eLicenseType
    {
        A, 
        A2, 
        AB, 
        B1
    }

    public enum eCarColor
    {
        Green,
        Black,
        White,
        Red
    }

    public abstract class Vehicle
    {
        private string m_VehicleModel;
        private string m_LicenseNumber;
        private float m_EnergyLeft;
        private float m_MaxEnergy;
        private List<Wheel> m_WheelList;

        public string Model
        {
            get
            {
                return m_VehicleModel;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        }

        public float EnergyLeftPercentage
        {
            get
            {
                return (m_EnergyLeft / m_MaxEnergy) * 100f;
            }
        }
    }
}
