using System;

namespace MATJParking
{
    class Truck : Vehicle
    {
        protected override double GetPrice()
        {
            var PriceForTruck = StandardPrice * 3;
            return PriceForTruck;
        }
    }
}
