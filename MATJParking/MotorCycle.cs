using System;

namespace MATJParking
{
    class MotorCycle : Vehicle
    {
        protected override double GetPrice()
        {
            return StandardPrice;
        }
    }
}
