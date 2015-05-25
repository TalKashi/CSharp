using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxEnergy, float i_EnergyLeft, int? i_EngineVolume)
            : base(i_MaxEnergy, i_EnergyLeft, i_EngineVolume)
        {
            // Do nothing
        }

        public void ChargeBattery(float i_HoursToAdd)
        {
            if (m_EnergyLeft + i_HoursToAdd > r_MaxEnergy)
            {
                throw new ValueOutOfRangeException(r_MaxEnergy, m_EnergyLeft, i_HoursToAdd);
            }

            if (i_HoursToAdd < 0)
            {
                throw new ArgumentException(string.Format("Expected a positive number. Recieved {0}", i_HoursToAdd));
            }

            m_EnergyLeft += i_HoursToAdd;
        }

        public override void GetRequiredData(List<string> i_RequiredData)
        {
            i_RequiredData.Add("Hours left in battery");
        }

        public override string EngineType()
        {
            return "Electric";
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
Hours Left In Battery: {1}
Max Hours In Battery: {2}",
                base.ToString(),
                EnergyLeft,
                MaxEnergy);
        }
    }
}
