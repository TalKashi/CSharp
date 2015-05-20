namespace Ex03.GarageLogic
{
    abstract class Engine
    {
        private float m_EnergyLeft;
        private float m_MaxEnergy;

        public virtual float EnergyLeft
        {
            get
            {
                return (m_EnergyLeft / m_MaxEnergy) * 100f;
            }
        }
    }
}
