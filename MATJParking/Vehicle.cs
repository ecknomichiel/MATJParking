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
        public VehicleType VehicleType { get { return GetVehicleType(); } }
        public string RegNumber { get; set; }
        public double Price 
        {
            get { return GetPrice(); } 
        }

        //methods

        protected abstract double GetPrice();
        protected abstract VehicleType GetVehicleType();
        
    }

    enum VehicleType
    {
        Motorcycle,
        Car,
        Bus,
        Truck
    }
}
