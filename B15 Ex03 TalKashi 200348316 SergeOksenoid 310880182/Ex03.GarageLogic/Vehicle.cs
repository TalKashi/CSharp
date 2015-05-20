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

    public class Vehicle
    {
        private string m_VehicleModel;
        private string m_LicenseType;
        private float m_EnergyLetfInPrecentage;
        private List<Wheel> m_WheelList;
    }
}
