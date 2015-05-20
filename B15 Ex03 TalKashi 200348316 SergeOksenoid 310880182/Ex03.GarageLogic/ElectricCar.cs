using System;
using System.Collections.Generic;
using System.Text;

public enum eNumOfDoors {Doors_2,Doors_3,Doors_4,Doors_5};

namespace Ex03.GarageLogic
{
    class ElectricCar :ElectricVehicle
    {
        eCarColor m_CarColor;
        eNumOfDoors m_NumOfDoors;
    }
}
