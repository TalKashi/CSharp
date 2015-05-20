using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public enum eStatus
    {
        InProgress,
        Fixed,
        Paid
    }

    public enum eNumOfDoors
    {
        TwoDoors = 2,
        ThreeDoors = 3,
        FourDoors = 4,
        FiveDoors = 5
    }

    public enum eFuelType
    {
        Soler, 
        Octan95,
        Octan96, 
        Octan98
    }

    public enum eCarColor
    {
        Green,
        Black,
        White,
        Red
    }

    internal abstract class Vehicle
    {
        private readonly string r_LicenseNumber;
        private string m_VehicleModel;
        private List<Wheel> m_WheelsList;
        protected Engine m_Engine;

        public string Model
        {
            get
            {
                return m_VehicleModel;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public float EnergyLeftInPercentage
        {
            get
            {
                return m_Engine.EnergyLeftInPercentage;
            }
        }

        protected Vehicle(string i_LicenseNumber, string i_VehicleModel, List<Wheel> i_WheelsList, Engine i_Engine )
        {
            r_LicenseNumber = i_LicenseNumber;
            m_VehicleModel = i_VehicleModel;
            m_WheelsList = i_WheelsList;
            m_Engine = i_Engine;
        }

        public override bool Equals(object i_Object)
        {
            bool isEqual = false;

            Vehicle otherVehicle = i_Object as Vehicle;
            if (otherVehicle != null)
            {
                isEqual = LicenseNumber == otherVehicle.LicenseNumber;
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            return r_LicenseNumber.GetHashCode();
        }

        public override string ToString()
        {
            // TODO: Impelement something
            return base.ToString();
        }

        public static bool operator ==(Vehicle i_VehicleA, Vehicle i_VehicleB)
        {
            bool isEquals;

            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(i_VehicleA, i_VehicleB))
            {
                isEquals = true;
            }
            else if (i_VehicleA == null || i_VehicleB == null) // If one is null, but not both, return false.
            {
                isEquals = false;
            }
            else
            {
                isEquals = i_VehicleA.Equals(i_VehicleB);
            }

            return isEquals;
        }

        public static bool operator !=(Vehicle i_VehicleA, Vehicle i_VehicleB)
        {
            return !(i_VehicleA == i_VehicleB);
        }
    }
}
