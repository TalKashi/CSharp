using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_CurrentValue;
        private float m_ValueToAdd;

        public float ValueToAdd
        {
            get
            {
                return m_ValueToAdd;
            }
        }

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }

        public float CurrentValue
        {
            get
            {
                return m_CurrentValue;
            }
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_CurrentValue, float i_ValueToAdd, Exception i_InnerException)
            : base(
            string.Format("An error occured while trying to increment {0} by {1} and max value is {2}", i_CurrentValue, i_ValueToAdd, i_MaxValue),
            i_InnerException)
        {
            m_MaxValue = i_MaxValue;
            m_CurrentValue = i_CurrentValue;
            m_ValueToAdd = i_ValueToAdd;
        }
    }
}
