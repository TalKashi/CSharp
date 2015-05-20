using System;
using System.Collections.Generic;
using System.Text;

public enum eLicenseType {A,A2,AB,B1}

namespace Ex03.GarageLogic
{
    class FuelMotorcycle : FuelVehicle
    {
        eLicenseType m_LicenseType;
        int m_Engine;
    }
}
