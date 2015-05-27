using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, Exception i_InnerException)
            : base(
            string.Format("Value out of range. Max value is {0}. Min value is {1}", i_MaxValue, i_MinValue),
            i_InnerException)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(float i_MaxValue)
            : this(i_MaxValue, 0, null)
        {
            // All init being done in other constructor
        }
    }
}
