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
        public Type VehicleType { get; set; }
        public string ID { get; set; }
        public bool Occupied { get {return vehicle != null;} }
        public string VehicleRegNumber 
        { 
            get 
            {
                if (vehicle == null)
                    return "";
                else
                    return vehicle.RegNumber;
            } 
        }
        public Vehicle Vehicle { get { return vehicle; } }

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
