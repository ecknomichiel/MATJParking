using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATJParking
{
    class Bus : Vehicle
    {
        protected override double GetPrice()
        {
            return Price;
        }
    }
}
