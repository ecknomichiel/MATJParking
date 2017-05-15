using System;

namespace MATJParking
{
    class Bus : Vehicle
    {
        protected override double GetPrice()
        {
            var PriceForBus = StandardPrice * 4;
            return PriceForBus;
        }
    }
}
