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

    public enum eLicenseType
    {
        A, 
        A2, 
        AB, 
        B1
    }

    public enum eCarColor
    {
        Green,
        Black,
        White,
        Red
    }

    public abstract class Vehicle
    {
        private string m_VehicleModel;
        private string m_LicenseNumber;
        private List<Wheel> m_WheelList;
        private Engine m_Engine;

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
                return m_LicenseNumber;
            }
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
            return LicenseNumber.GetHashCode();
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
