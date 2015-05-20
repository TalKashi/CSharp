﻿using System;

namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxEnergy, float i_EnergyLeft, int i_EngineVolume)
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
    }
}
