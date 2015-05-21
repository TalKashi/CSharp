namespace Ex03.GarageLogic
{
    internal abstract class Engine
    {
        protected readonly float r_MaxEnergy;
        protected float m_EnergyLeft;
        private int? m_EngineVolume;

        public int? EngineVolume
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

        public float EnergyLeft
        {
            get
            {
                return m_EnergyLeft;
            }
        }

        public float MaxEnergy
        {
            get
            {
                return r_MaxEnergy;
            }
        }

        protected Engine(float i_MaxEnergy, float i_EnergyLeft, int i_EngineVolume)
        {
            m_EnergyLeft = i_EnergyLeft;
            r_MaxEnergy = i_MaxEnergy;
            m_EngineVolume = i_EngineVolume;
        }

        public override string ToString()
        {
            return string.Format("Percentage Left: {0}", EnergyLeftInPercentage);
        }

        public abstract string EngineType();
    }
}
