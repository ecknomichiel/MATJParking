using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATJParking
{
   abstract class Vehicle
    {
        protected double StandardPrice
        { 
            get 
            { 
                DateTime endTime = CheckOutTime;
                if (CheckOutTime == null)
                {
                    endTime = DateTime.Now;
                }
                return (endTime - CheckInTime).Hours * 15;
            }
        }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public string RegNumber { get; set; }
        public double Price 
        {
            get { return GetPrice(); } 
        }

        //methods

        protected abstract double GetPrice();
       
       
    }
}
