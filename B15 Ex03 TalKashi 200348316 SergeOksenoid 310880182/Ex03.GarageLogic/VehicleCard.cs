namespace Ex03.GarageLogic
{
    internal class VehicleCard
    {
        public enum eStatus
        {
            InProgress,
            Repaired,
            Paid
        }

        private string m_OwnerName;
        private string m_OwnerPhone;
        private Vehicle m_Vehicle;
        private eStatus m_VehicleStatus;

        public VehicleCard(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle) 
        {
            m_VehicleStatus = eStatus.InProgress;
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;
            m_Vehicle = i_Vehicle;
        }

        public eStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }
    }
}
