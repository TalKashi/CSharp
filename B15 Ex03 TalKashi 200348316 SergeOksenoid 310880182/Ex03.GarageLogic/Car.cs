﻿using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal abstract class Car : Vehicle
    {
        public enum eCarColor
        {
            Green,
            Black,
            White,
            Red
        }

        public enum eNumOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }
        
        private eCarColor m_CarColor;
        private eNumOfDoors m_NumOfDoors;

        protected Car(string i_LicenseNumber, string i_VehicleModel, List<Wheel> i_WheelsList, Engine i_Engine, eCarColor i_Color, eNumOfDoors i_NumOfDoors)
            : base(i_LicenseNumber, i_VehicleModel, i_WheelsList, i_Engine)
        {
            m_CarColor = i_Color;
            m_NumOfDoors = i_NumOfDoors;
        }

        protected Car()
        {
            // For dummy object
        }

        public override string ToString()
        {
            return string.Format(
@"{0}

Color: {1}
Number of Doors: {2}",
                base.ToString(),
                m_CarColor,
                m_NumOfDoors);
        }

        public override List<KeyValuePair<string, Type>> GetRequiredData()
        {
            List<KeyValuePair<string, Type>> requiredData = new List<KeyValuePair<string, Type>>(2);

            requiredData.Add(new KeyValuePair<string, Type>("car color", typeof(eCarColor)));
            requiredData.Add(new KeyValuePair<string, Type>("number of doors", typeof(eNumOfDoors)));

            return requiredData;
        }
    }
}
