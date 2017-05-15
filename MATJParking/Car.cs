using System;

namespace MATJParking
{
    class Car : Vehicle
    {
        protected override double GetPrice()
        {
            var PriceForCar = StandardPrice * 2;
            return PriceForCar;
        }
    }
}
