using System;
using System.Collections.Generic;
using System.Linq;

namespace MATJParking
{
    class ParkingPlace
    {
        private Vehicle vehicle;
        private List<Type> vehicleTypes = new List<Type>();
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

        public string VehicleTypeString()
        {
            string result = "";
            bool first = true;
            foreach (Type t in vehicleTypes)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    result += ", ";
                }
                result += t.Name;
            }
            return result;
        }

        public bool IsCompatibleWith(Vehicle aVehicle)
        {
            return vehicleTypes.Contains(aVehicle.GetType());
        }

        public void AddVehicleType(Type aVehicleType)
        {
            if (aVehicleType == typeof(Vehicle))
            {
                vehicleTypes.Add(aVehicleType);
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
                return String.Format("{0} parking place {1}, occupied by '{2}'. Parking time: {4} hours Current price: SEK {3}", 
                        VehicleTypeString(), ID, vehicle.RegNumber);
            else
                return String.Format("{0} parking place {1}, empty", VehicleTypeString(), ID);
        }
    }

}
