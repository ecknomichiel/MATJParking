﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATJParking
{
    class Garage
    {
        private List<ParkingPlace> parkingplaces = new List<ParkingPlace>();

        private Vehicle CreateVehicle(string VehicleType)
        {
            switch (VehicleType)
            {
                case "motorcycle":
                    return new MotorCycle();
                case "car":
                    return new Car();
                case "bus":
                    return new Bus();
                case "truck":
                    return new Truck();
                default:
                    throw new EUnknownVehicleType(VehicleType);
            }
        }

        public Vehicle SearchVehicle(string aRegistrationNumber)
        {
            ParkingPlace park = SearchPlaceWhereVehicleIsParked(aRegistrationNumber);
            if (park == null)
            {
                return null;
            }
            else
            {
                return park.Vehicle;
            }
        }

        private ParkingPlace SearchPlaceWhereVehicleIsParked(string aRegistrationNumber)
        {
            return parkingplaces.SingleOrDefault(pl => pl.VehicleRegNumber == aRegistrationNumber);
        }
      
        public string CheckIn(string RegistrationNumber, string VehicleType)
        {
            Vehicle vehicle = CreateVehicle(VehicleType);
            vehicle.RegNumber = RegistrationNumber;
            ParkingPlace place = parkingplaces.Where(pl => pl.VehicleType == vehicle.GetType())
                                                .First();
            if (place == null)
            {
                throw new ENoPlaceForVehicle(VehicleType);
            }
            place.Park(vehicle);

            return place.ID;
        }


    }
    class EUnknownVehicleType: Exception
    {
        public EUnknownVehicleType(string vehicleType)
            : base(String.Format("Unknows vehicle type: {0}", vehicleType)) { }
 
    }

    class ENoPlaceForVehicle: Exception
    {
        public ENoPlaceForVehicle(string vehicleType): base (String.Format("No place for vehicle of type: {0}", vehicleType))
        {
          
        }
    }
}
