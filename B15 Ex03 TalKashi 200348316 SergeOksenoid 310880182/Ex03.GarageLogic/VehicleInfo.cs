using System;
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

        private const int k_NumberOfWheelsInCar = 4;
        private const float k_MaxAirPressureInCarWheels = 31;

        private const int k_NumberOfWheelsInMotorcycle = 2;

        private static readonly string[] sr_VehicleTypes = { k_FuelCar, k_ElectircCar, k_FuelMotorcycle, k_ElectricMotorcycle, k_FuelTruck };

        private static readonly FuelCar sr_FuelCarDummy = new FuelCar();
        private static readonly ElectricCar sr_ElectircCarDummy = new ElectricCar();
        private static readonly FuelMotorcycle sr_FuelMotorcycleDummy = new FuelMotorcycle();
        private static readonly ElectricMotorcycle sr_ElectricMotorcycleDummy = new ElectricMotorcycle();
        private static readonly FuelTruck sr_FuelTruckDummy = new FuelTruck();
        

        public static string[] GetVehicleList()
        {
            return sr_VehicleTypes;
        }

        public static List<KeyValuePair<string, Type>> GetRequiredDataOfSpecificVehicleType(string i_VehicleType)
        {
            List<KeyValuePair<string, Type>> requiredData = null;

            switch (i_VehicleType)
            {
                case k_FuelCar:
                    requiredData = sr_FuelCarDummy.GetRequiredData();
                    break;
                case k_ElectircCar:
                    requiredData = sr_ElectircCarDummy.GetRequiredData();
                    break;
                case k_FuelMotorcycle:
                    requiredData = sr_FuelMotorcycleDummy.GetRequiredData();
                    break;
                case k_ElectricMotorcycle:
                    requiredData = sr_ElectricMotorcycleDummy.GetRequiredData();
                    break;
                case k_FuelTruck:
                    requiredData = sr_FuelTruckDummy.GetRequiredData();
                    break;
            }

            return requiredData;
        }

        internal static Vehicle CreateVehicle(string i_VehicleType, string i_LicensePlateSrting, string i_VehicleModel, float i_EnergyLeft, string i_WheelManufacturer, float i_WheelCurrentAirPressure, string[] i_Parameters)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case k_FuelCar:
                    newVehicle = initNewFuelCar(i_LicensePlateSrting, i_VehicleModel, i_EnergyLeft, i_WheelManufacturer,
                        i_WheelCurrentAirPressure, i_Parameters);
                    break;
                case k_ElectircCar:
                    newVehicle = initNewElectricCar(i_LicensePlateSrting, i_VehicleModel, i_EnergyLeft, i_WheelManufacturer,
                        i_WheelCurrentAirPressure, i_Parameters);
                    break;
                case k_FuelMotorcycle:
                    newVehicle = initNewFuelMotorcycle(i_LicensePlateSrting, i_VehicleModel, i_EnergyLeft, i_WheelManufacturer,
                        i_WheelCurrentAirPressure, i_Parameters);
                    break;
                case k_ElectricMotorcycle:
                    newVehicle = initNewElectricMotorcycle(i_LicensePlateSrting, i_VehicleModel, i_EnergyLeft, i_WheelManufacturer,
                        i_WheelCurrentAirPressure, i_Parameters);
                    break;
                case k_FuelTruck:
                    newVehicle = initNewFuelTruck(i_LicensePlateSrting, i_VehicleModel, i_EnergyLeft, i_WheelManufacturer,
                        i_WheelCurrentAirPressure, i_Parameters);
                    break;
            }

            return newVehicle;
        }

        private static FuelTruck initNewFuelTruck(string i_LicensePlateSrting, string i_VehicleModel, float i_EnergyLeft, string i_WheelManufacturer, float i_WheelCurrentAirPressure, string[] i_Parameters)
        {
            const string k_YesString = "Y";
            const string k_NoString = "Y";
            const float k_MaxAirPressureInFuelTruckWheels = 25;
            const eFuelType k_SupportedMTruckFuelType = eFuelType.Soler;
            const float k_MaxTruckFuelTank = 170;
            const int k_NumberOfWheels = 16;

            if (i_EnergyLeft > k_MaxTruckFuelTank)
            {
                throw new ValueOutOfRangeException(k_MaxTruckFuelTank);
            }

            FuelEngine engine = new FuelEngine(k_MaxTruckFuelTank, i_EnergyLeft, null, k_SupportedMTruckFuelType);

            if (i_WheelCurrentAirPressure > k_MaxAirPressureInFuelTruckWheels)
            {
                throw new ValueOutOfRangeException(k_MaxAirPressureInFuelTruckWheels);
            }

            List<Wheel> wheels = new List<Wheel>(k_NumberOfWheels);
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                wheels.Add(new Wheel(i_WheelManufacturer, i_WheelCurrentAirPressure, k_MaxAirPressureInFuelTruckWheels));
            }

            bool isCarryingDangerousMaterials;
            string upperCaseParameter = i_Parameters[0].ToUpper();

            if (k_YesString == upperCaseParameter)
            {
                isCarryingDangerousMaterials = true;
            }
            else if (k_NoString == upperCaseParameter)
            {
                isCarryingDangerousMaterials = false;
            }
            else
            {
                throw new FormatException(string.Format("Invalid format. Expected '{0}' or '{1}'", k_YesString, k_NoString));
            }

            float currentCarryingWeight = float.Parse(i_Parameters[1]);

            return new FuelTruck(i_LicensePlateSrting, i_VehicleModel, wheels, engine, isCarryingDangerousMaterials, currentCarryingWeight);
        }

        private static ElectricMotorcycle initNewElectricMotorcycle(string i_LicensePlateSrting, string i_VehicleModel, float i_EnergyLeft, string i_WheelManufacturer, float i_WheelCurrentAirPressure, string[] i_Parameters)
        {
            const bool v_IgnoreCase = true;
            const float k_MaxAirPressureInElectricMotorcycleWheels = 31;
            const float k_MaxMotorcycleHoursInBattery = 1.2f;

            if (i_EnergyLeft > k_MaxMotorcycleHoursInBattery)
            {
                throw new ValueOutOfRangeException(k_MaxMotorcycleHoursInBattery);
            }

            int engineVolume = int.Parse(i_Parameters[1]);
            ElectricEngine engine = new ElectricEngine(k_MaxMotorcycleHoursInBattery, i_EnergyLeft, engineVolume);

            if (i_WheelCurrentAirPressure > k_MaxAirPressureInElectricMotorcycleWheels)
            {
                throw new ValueOutOfRangeException(k_MaxAirPressureInElectricMotorcycleWheels);
            }

            List<Wheel> wheels = new List<Wheel>(k_NumberOfWheelsInMotorcycle);
            for (int i = 0; i < k_NumberOfWheelsInMotorcycle; i++)
            {
                wheels.Add(new Wheel(i_WheelManufacturer, i_WheelCurrentAirPressure, k_MaxAirPressureInElectricMotorcycleWheels));
            }

            Motorcycle.eLicenseType licenseType =
                (Motorcycle.eLicenseType)Enum.Parse(typeof(Motorcycle.eLicenseType), i_Parameters[0], v_IgnoreCase);

            return new ElectricMotorcycle(i_LicensePlateSrting, i_VehicleModel, wheels, licenseType, engine);
        }

        private static FuelMotorcycle initNewFuelMotorcycle(string i_LicensePlateSrting, string i_VehicleModel, float i_EnergyLeft, string i_WheelManufacturer, float i_WheelCurrentAirPressure, string[] i_Parameters)
        {
            const bool v_IgnoreCase = true;
            const float k_MaxAirPressureInFuelMotorcycleWheels = 34;
            const eFuelType k_SupportedMotorcycleFuelType = eFuelType.Octan98;
            const float k_MaxMotorcycleFuelTank = 8;

            if (i_EnergyLeft > k_MaxMotorcycleFuelTank)
            {
                throw new ValueOutOfRangeException(k_MaxMotorcycleFuelTank);
            }

            int engineVolume = int.Parse(i_Parameters[1]);
            FuelEngine engine = new FuelEngine(k_MaxMotorcycleFuelTank, i_EnergyLeft, engineVolume, k_SupportedMotorcycleFuelType);

            if (i_WheelCurrentAirPressure > k_MaxAirPressureInFuelMotorcycleWheels)
            {
                throw new ValueOutOfRangeException(k_MaxAirPressureInFuelMotorcycleWheels);
            }

            List<Wheel> wheels = new List<Wheel>(k_NumberOfWheelsInMotorcycle);
            for (int i = 0; i < k_NumberOfWheelsInMotorcycle; i++)
            {
                wheels.Add(new Wheel(i_WheelManufacturer, i_WheelCurrentAirPressure, k_MaxAirPressureInFuelMotorcycleWheels));
            }

            Motorcycle.eLicenseType licenseType =
                (Motorcycle.eLicenseType) Enum.Parse(typeof (Motorcycle.eLicenseType), i_Parameters[0], v_IgnoreCase);

            return new FuelMotorcycle(i_LicensePlateSrting, i_VehicleModel, wheels, licenseType, engine);
        }

        private static ElectricCar initNewElectricCar(string i_LicensePlateSrting, string i_VehicleModel, float i_EnergyLeft, string i_WheelManufacturer, float i_WheelCurrentAirPressure, string[] i_Parameters)
        {
            const bool v_IgnoreCase = true;
            const float k_MaxCarHoursInBattery = 2.2f;

            if (i_EnergyLeft > k_MaxCarHoursInBattery)
            {
                throw new ValueOutOfRangeException(k_MaxCarHoursInBattery);
            }

            ElectricEngine engine = new ElectricEngine(k_MaxCarHoursInBattery, i_EnergyLeft, null);

            if (i_WheelCurrentAirPressure > k_MaxAirPressureInCarWheels)
            {
                throw new ValueOutOfRangeException(k_MaxAirPressureInCarWheels);
            }

            List<Wheel> wheels = new List<Wheel>(k_NumberOfWheelsInCar);
            for (int i = 0; i < k_NumberOfWheelsInCar; i++)
            {
                wheels.Add(new Wheel(i_WheelManufacturer, i_WheelCurrentAirPressure, k_MaxAirPressureInCarWheels));
            }

            Car.eCarColor color = (Car.eCarColor)Enum.Parse(typeof(Car.eCarColor), i_Parameters[0], v_IgnoreCase);
            Car.eNumOfDoors numOfDoors = (Car.eNumOfDoors)Enum.Parse(typeof(Car.eNumOfDoors), i_Parameters[1], v_IgnoreCase);

            return new ElectricCar(i_LicensePlateSrting, i_VehicleModel, wheels, engine, color, numOfDoors);
        }

        private static FuelCar initNewFuelCar(string i_LicensePlateSrting, string i_VehicleModel, float i_EnergyLeft, string i_WheelManufacturer, float i_WheelCurrentAirPressure, string[] i_Parameters)
        {
            const bool v_IgnoreCase = true;
            const eFuelType k_SupportedCarFuelType = eFuelType.Octan96;
            const float k_MaxCarFuelTank = 35;

            if (i_EnergyLeft > k_MaxCarFuelTank)
            {
                throw new ValueOutOfRangeException(k_MaxCarFuelTank);
            }

            FuelEngine engine = new FuelEngine(k_MaxCarFuelTank, i_EnergyLeft, null, k_SupportedCarFuelType);

            if (i_WheelCurrentAirPressure > k_MaxAirPressureInCarWheels)
            {
                throw new ValueOutOfRangeException(k_MaxAirPressureInCarWheels);
            }

            List<Wheel> wheels = new List<Wheel>(k_NumberOfWheelsInCar);
            for (int i = 0; i < k_NumberOfWheelsInCar; i++)
            {
                wheels.Add(new Wheel(i_WheelManufacturer, i_WheelCurrentAirPressure, k_MaxAirPressureInCarWheels));
            }

            Car.eCarColor color = (Car.eCarColor)Enum.Parse(typeof(Car.eCarColor), i_Parameters[0], v_IgnoreCase);
            Car.eNumOfDoors numOfDoors = (Car.eNumOfDoors)Enum.Parse(typeof(Car.eNumOfDoors), i_Parameters[1], v_IgnoreCase);

            return new FuelCar(i_LicensePlateSrting, i_VehicleModel, wheels, engine, color, numOfDoors);
        }
    }
}