namespace Ex03.GarageLogic
{
    public enum eStatus
    {
        InProgress,
        Repaired,
        Paid
    }

    internal class VehicleCard
    {
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

        public override string ToString()
        {
            return string.Format(
@"Owner Name: {0}
Owner Phone Nuber: {1}

Vehicle Details
----------------
{2}

Status: {3}", 
            m_OwnerName, 
            m_OwnerPhone, 
            m_Vehicle, 
            m_VehicleStatus);
        }
    }
}
