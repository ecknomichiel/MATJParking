using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATJParking
{
    class Car : Vehicle
    {
        protected override double GetPrice()
        {
            return StandardPrice * 2;
        }
    }
}
