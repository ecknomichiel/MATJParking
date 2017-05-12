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
        public VehicleType VehicleType { get; set; }
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

        public void Park(Vehicle aVehicle)
        {
            vehicle = aVehicle;
            vehicle.CheckInTime = DateTime.Now;
        }
        public void Unpark()
        {
            vehicle.CheckOutTime = DateTime.Now;
            vehicle = null;
        }
        public override string ToString()
        {
            if (Occupied)
                return String.Format("{0} parking place {1}, occupied by '{2}'. Current price at checkout: {3}", VehicleType, ID, vehicle.RegNumber, vehicle.Price);
            else
                return String.Format("{0} parking place {1}, empty", VehicleType, ID);
        }
    }

}
