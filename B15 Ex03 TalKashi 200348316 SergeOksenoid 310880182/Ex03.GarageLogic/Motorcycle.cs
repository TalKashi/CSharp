using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A,
            A2,
            AB,
            B1
        }

        private eLicenseType m_LicenseType;

        public int EngineVolume
        {
            get
            {
                return m_Engine.EngineVolume;
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }

        public Motorcycle(string i_LicenseNumber, string i_VehicleModel, List<Wheel> i_WheelsList, Engine i_Engine,
            eLicenseType i_LicenseType)
            : base(i_LicenseNumber, i_VehicleModel, i_WheelsList, i_Engine)
        {
            m_LicenseType = i_LicenseType;
        }
    }
}
