using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATJParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage();

            foreach (ParkingPlace place in garage.GetAllParkingPlaces())
            {
                Console.WriteLine("{0} occupied: {1} {2}", place.ID, place.Occupied, place.VehicleRegNumber);
            }

            Console.ReadKey();

        }
    }
}
