using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_IsCarryingDangerousMaterials;
        private float m_CurrentCarryingWeight;

        public Truck(string i_LicenseNumber, string i_VehicleModel, List<Wheel> i_WheelsList, Engine i_Engine, bool i_IsCarryingDangerousMaterials, float i_CurrentCarryingWeight)
            : base(i_LicenseNumber, i_VehicleModel, i_WheelsList, i_Engine)
        {
            m_IsCarryingDangerousMaterials = i_IsCarryingDangerousMaterials;
            m_CurrentCarryingWeight = i_CurrentCarryingWeight;
        }

        public override string ToString()
        {
            return string.Format(
@"{0}

Is Carrying Dangerous Materials: {1}
Current Carrying Weight: {2}",
                base.ToString(),
                m_IsCarryingDangerousMaterials,
                m_CurrentCarryingWeight);
        }
    }
}
