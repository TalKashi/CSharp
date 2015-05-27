using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal abstract class Truck : Vehicle
    {
        private bool m_IsCarryingDangerousMaterials;
        private float m_CurrentCarryingWeight;

        protected Truck(string i_LicenseNumber, string i_VehicleModel, List<Wheel> i_WheelsList, Engine i_Engine, bool i_IsCarryingDangerousMaterials, float i_CurrentCarryingWeight)
            : base(i_LicenseNumber, i_VehicleModel, i_WheelsList, i_Engine)
        {
            m_IsCarryingDangerousMaterials = i_IsCarryingDangerousMaterials;
            m_CurrentCarryingWeight = i_CurrentCarryingWeight;
        }

        protected Truck()
        {
            // For dummy object
        }

        public override List<KeyValuePair<string, Type>> GetRequiredData()
        {
            List<KeyValuePair<string, Type>> requiredData = new List<KeyValuePair<string, Type>>(2);

            requiredData.Add(new KeyValuePair<string, Type>("if carrying dangerous materials", typeof(bool)));
            requiredData.Add(new KeyValuePair<string, Type>("current cargo weight", typeof(float)));

            return requiredData;
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
