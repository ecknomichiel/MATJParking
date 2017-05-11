using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATJParking
{
   abstract class Vehicle
    {
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public string RegNumber { get; set; }
        public double Price { get; }

        //methods

        protected abstract double GetPrice();
       
       
    }
}
