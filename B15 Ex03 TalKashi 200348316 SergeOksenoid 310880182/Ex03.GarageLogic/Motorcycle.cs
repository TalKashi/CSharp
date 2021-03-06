﻿using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal abstract class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A,
            A2,
            AB,
            B1
        }

        private eLicenseType m_LicenseType;

        public int EngineVolume
        {
            get
            {
                return m_Engine.EngineVolume.GetValueOrDefault();
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }

        protected Motorcycle(string i_LicenseNumber, string i_VehicleModel, List<Wheel> i_WheelsList, eLicenseType i_LicenseType, Engine i_Engine)
            : base(i_LicenseNumber, i_VehicleModel, i_WheelsList, i_Engine)
        {
            m_LicenseType = i_LicenseType;
        }

        protected Motorcycle()
        {
            // For dummy object
        }

        public override List<KeyValuePair<string, Type>> GetRequiredData()
        {
            List<KeyValuePair<string, Type>> requiredData = new List<KeyValuePair<string, Type>>(2);

            requiredData.Add(new KeyValuePair<string, Type>("license type", typeof(eLicenseType)));
            requiredData.Add(new KeyValuePair<string, Type>("engine volume", typeof(int)));

            return requiredData;
        }

        public override string ToString()
        {
            return string.Format(
@"{0}

License Type: {1}
Engine Volume: {2}",
                base.ToString(),
                LicenseType,
                EngineVolume);
        }
    }
}
