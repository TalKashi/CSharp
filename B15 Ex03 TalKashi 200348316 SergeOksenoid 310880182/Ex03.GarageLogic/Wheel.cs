﻿using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private string m_Manufacturer;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public void PumpAir(float i_AirToAdd)
        {
            if (m_CurrentAirPressure + i_AirToAdd > m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(m_MaxAirPressure);
            }

            if (i_AirToAdd < 0)
            {
                throw new ArgumentException(string.Format("Expected a positive number. Recieved {0}", i_AirToAdd));
            }

            m_CurrentAirPressure += i_AirToAdd;
        }

        public override string ToString()
        {
            return string.Format(
@"Manufacturer: {0}
Current Air Pressure: {1}
Max Air Pressure: {2}",
                m_Manufacturer,
                m_CurrentAirPressure,
                m_MaxAirPressure);
        }

        public void GetRequiredData(List<string> i_RequiredData)
        {
            i_RequiredData.Add("Wheel manufacturer");
            i_RequiredData.Add("Current air pressure");
        } 
    }
}
