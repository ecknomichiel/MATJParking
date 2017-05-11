using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATJParking
{
    class ParkingPlace
    {
        private Vehicle vehicle;
        public Type vehicleType { get; set; }
        public string ID { get; set; }
        public bool Occupied { get {return vehicle != null;} }

        public void Park(Vehicle Avehicle)
        {
            vehicle = Avehicle;
            vehicle.CheckInTime = DateTime.Now;
        }
        public void Unpark()
        {
            vehicle.CheckOutTime = DateTime.Now;
            vehicle = null;

        }
    }

}
