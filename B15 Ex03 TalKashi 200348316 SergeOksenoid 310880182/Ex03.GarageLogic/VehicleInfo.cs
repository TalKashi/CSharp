namespace Ex03.GarageLogic
{
    internal class VehicleInfo
    {
        string[] vehicleTypes = { "Car(Fuel)", "Car(Electric)", "Motorcycle(Fuel)", "Motorcycle(Electric)", "Truck" };

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


        private string[] GetVehicleList()
        {
            return vehicleTypes;
        }
    }
}