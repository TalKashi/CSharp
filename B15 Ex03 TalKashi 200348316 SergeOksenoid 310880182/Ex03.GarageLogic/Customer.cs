using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Customer
    {
        private string m_OwnerName;
        private string m_OwnerPhone;
        private Vehicle m_Vehicle;
        private eStatus m_VehicleStatus;

        public Customer(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle) 
        {
            m_VehicleStatus = eStatus.InProgress;
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;
            m_Vehicle = i_Vehicle;
        }

        public void UpdateStatus(eStatus i_Status)
        {
            m_VehicleStatus = i_Status;
        }

        public Vehicle GetVehicle()
        {
            return m_Vehicle;
        }
        
    }
}
