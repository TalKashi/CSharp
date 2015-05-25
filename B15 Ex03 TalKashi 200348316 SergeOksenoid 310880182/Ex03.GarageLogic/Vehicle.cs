using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
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

        public List<Wheel> Wheels
        {
            get
            {
                return m_WheelsList;
            }
        }

        public static bool operator ==(Vehicle i_VehicleA, Vehicle i_VehicleB)
        {
            bool isEquals;
            
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(i_VehicleA, i_VehicleB))
            {
                isEquals = true;
            }
            else if (i_VehicleA == null || i_VehicleB == null)
            {
                // If one is null, but not both, return false.
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

        protected Vehicle(string i_LicenseNumber, string i_VehicleModel, List<Wheel> i_WheelsList, Engine i_Engine)
        {
            r_LicenseNumber = i_LicenseNumber;
            m_VehicleModel = i_VehicleModel;
            m_WheelsList = i_WheelsList;
            m_Engine = i_Engine;
        }

        public virtual void GetRequiredData(List<string> i_RequiredData)
        {
            i_RequiredData.Add("Vehicle model");
            m_Engine.GetRequiredData(i_RequiredData);
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
            return string.Format(
@"License Number: {0}
Model Name: {1}

{2}

{3}
----------------
{4}", 
    r_LicenseNumber, 
    m_VehicleModel,
    generateWheelsInfoString(), 
    m_Engine.EngineType(),
    m_Engine);
        }

        private string generateWheelsInfoString()
        {
            int wheelNumber = 1;
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Wheel wheel in m_WheelsList)
            {
                stringBuilder.AppendFormat(
@"Wheel #{0}
----------------
{1}
{2}", 
    wheelNumber, 
    wheel, 
    System.Environment.NewLine);

                wheelNumber++;
            }

            return stringBuilder.ToString();
        }
    }
}
