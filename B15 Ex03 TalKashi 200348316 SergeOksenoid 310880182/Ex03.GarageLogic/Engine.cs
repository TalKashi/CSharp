namespace Ex03.GarageLogic
{
    internal abstract class Engine
    {
        private readonly float r_MaxEnergy;
        private float m_EnergyLeft;
        private int m_EngineVolume;

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
        }

        public float EnergyLeftInPercentage
        {
            get
            {
                return (m_EnergyLeft / r_MaxEnergy) * 100f;
            }
        }

        protected Engine(float i_MaxEnergy, float i_EnergyLeft, int i_EngineVolume)
        {
            m_EnergyLeft = i_EnergyLeft;
            r_MaxEnergy = i_MaxEnergy;
            m_EngineVolume = i_EngineVolume;
        }
    }
}
