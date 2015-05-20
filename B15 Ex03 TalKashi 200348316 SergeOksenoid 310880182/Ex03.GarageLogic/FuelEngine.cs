using System;

namespace Ex03.GarageLogic
{
    internal class FuelEngine : Engine
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private eFuelType m_FuelType;

        public float MaxFuel
        {
            get
            {
                return r_MaxEnergy;
            }
        }

        public FuelEngine(float i_MaxEnergy, float i_EnergyLeft, int i_EngineVolume, eFuelType i_FuelType)
            : base(i_MaxEnergy, i_EnergyLeft, i_EngineVolume)
        {
            m_FuelType = i_FuelType;
        }

        public void PumpFuel(float i_LitresToAdd, eFuelType i_FuelType)
        {
            if (m_EnergyLeft + i_LitresToAdd > r_MaxEnergy)
            {
                throw new ValueOutOfRangeException(r_MaxEnergy, m_EnergyLeft, i_LitresToAdd);
            }

            if (m_FuelType != i_FuelType)
            {
                throw new ArgumentException(string.Format("Not matching fuel types. Expected {0} but got {1}", m_FuelType, i_FuelType));
            }

            m_EnergyLeft += i_LitresToAdd;
        }
    }
}
