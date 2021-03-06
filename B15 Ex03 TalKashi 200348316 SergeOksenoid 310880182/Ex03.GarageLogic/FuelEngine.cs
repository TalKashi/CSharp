﻿using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class FuelEngine : Engine
    {
        public enum eFuelType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4
        }

        private eFuelType m_FuelType;

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }

        public FuelEngine(float i_MaxEnergy, float i_EnergyLeft, int? i_EngineVolume, eFuelType i_FuelType)
            : base(i_MaxEnergy, i_EnergyLeft, i_EngineVolume)
        {
            m_FuelType = i_FuelType;
        }

        public void PumpFuel(float i_LitresToAdd, eFuelType i_FuelType)
        {
            if (m_EnergyLeft + i_LitresToAdd > r_MaxEnergy)
            {
                throw new ValueOutOfRangeException(r_MaxEnergy);
            }

            if (m_FuelType != i_FuelType)
            {
                throw new ArgumentException(string.Format("Not matching fuel types. Expected {0} but got {1}", m_FuelType, i_FuelType));
            }

            if (i_LitresToAdd < 0)
            {
                throw new ArgumentException(string.Format("Expected a positive number. Recieved {0}", i_LitresToAdd));
            }

            m_EnergyLeft += i_LitresToAdd;
        }

        public override string EngineType()
        {
            return "Fuel";
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
Fuel Type: {1}
Litres Left: {2}
Max Litres: {3}",
                base.ToString(),
                m_FuelType,
                EnergyLeft,
                MaxEnergy);
        }
    }
}
