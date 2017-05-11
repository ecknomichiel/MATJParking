using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATJParking
{
    class ParkingPlace
    {
        private object vehicle;
        public Type vehicleType { get; set; }
        public string ID { get; set; }
        public bool Occupied { get {return vehicle != null;} }

        public void Park(object Avehicle)
        {
            vehicle = Avehicle;
           // Vehicle.CheckInTime = Datetime.Now;
        }
        public void Unpark()
        {
            //Vehicle.CheckOutTime = Datetime.Now;
            vehicle = null;

        }
    }

}
