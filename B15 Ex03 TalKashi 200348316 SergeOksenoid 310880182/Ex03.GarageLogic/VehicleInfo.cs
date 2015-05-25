using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleInfo
    {
        private const string k_FuelCar = "Car(Fuel)";
        private const string k_ElectircCar = "Car(Electric)";
        private const string k_FuelMotorcycle = "Motorcycle(Fuel)";
        private const string k_ElectricMotorcycle = "Motorcycle(Electric)";
        private const string k_FuelTruck = "Truck(Fuel)";
        private static readonly string[] sr_VehicleTypes = { k_FuelCar, k_ElectircCar, k_FuelMotorcycle, k_ElectricMotorcycle, k_FuelTruck };

        private static readonly List<Wheel> sr_WheelsTamplate = new List<Wheel> { new Wheel("", 0, 1) };
        private static readonly FuelEngine sr_FuelEngineTamplate = new FuelEngine(1, 0, null, eFuelType.Octan95);

        private static readonly FuelCar sr_FuelCarTamplate = new FuelCar("", "", sr_WheelsTamplate, sr_FuelEngineTamplate, Car.eCarColor.Black, Car.eNumOfDoors.TwoDoors);

        private float m_FuelEngineMotorcycleMaxPressure;
        private float m_FuelEngineMotorcycleMaxTank;
        private eFuelType m_FuelTypeMotorcycle;

        private float m_ElectricEngineMotorcycleMaxPressure;
        private float m_ElectricEngineMotorcycleMaxBattery;

        private float m_FuelEngineCarMaxPressure;
        private float m_FuelEngineCareMaxTank;
        private eFuelType m_FuelTypeCar;

        private float m_ElectricEngineCarMaxPressure;
        private float m_ElectricEngineCarMaxBattery;

        private float m_FuelEngineTruckMaxPressure;
        private float m_FuelEngineTruckMaxTank;
        private eFuelType m_FuelTypeTruck;


        public static string[] GetVehicleList()
        {
            return sr_VehicleTypes;
        }

        public static List<string> GetRequiredDataOfSpecificVehicleType(string i_VehicleType)
        {
            List<string> listToReturn = new List<string>();
            if (i_VehicleType == k_FuelCar)
            {
                sr_FuelCarTamplate.GetRequiredData(listToReturn);
            }

            return listToReturn;
        } 
    }
}