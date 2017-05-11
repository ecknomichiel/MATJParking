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
        #region Private Methods
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
        private void LoadParkingPlaces()
        {
            int i;
            for (i = 0; i < 1; i++ ) 
            {
                parkingplaces.Add(new ParkingPlace() {ID = "B" + i, VehicleType = new Bus().GetType()});
            }
            for (i = 0; i < 5; i++)
            {
                parkingplaces.Add(new ParkingPlace() { ID = "T" + i, VehicleType = new Truck().GetType() });
            }
            for (i = 0; i < 50; i++)
            {
                parkingplaces.Add(new ParkingPlace() { ID = "C" + i, VehicleType = new Car().GetType() });
            }
            for (i = 0; i < 20; i++)
            {
                parkingplaces.Add(new ParkingPlace() { ID = "M" + i, VehicleType = new MotorCycle().GetType() });
            }
        }
        #endregion
        #region Public Methods
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

        public void CheckOut(string RegistrationNumber)
        {
            ParkingPlace place = SearchPlaceWhereVehicleIsParked(RegistrationNumber);
            if (place == null)
                throw new EVehicleNotFound(RegistrationNumber);
            place.Unpark();
        }
        #endregion
        #region Search
        public IEnumerable<ParkingPlace> SearchAllParkingPlaces()
        {
            return parkingplaces;
        }
        public IEnumerable<ParkingPlace> SearchAllParkedVehicles()
        {
            return parkingplaces.Where(pl => pl.Occupied);
        }
        public IEnumerable<ParkingPlace> SearchAllParkedVehiclesOnPrice(double aPrice, bool greaterThan)
        {
            if (greaterThan)
                return parkingplaces.Where(pl => pl.Occupied && pl.Vehicle.Price >= aPrice);
            else
                return parkingplaces.Where(pl => pl.Occupied && pl.Vehicle.Price <= aPrice);
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
        public ParkingPlace SearchPlaceWhereVehicleIsParked(string aRegistrationNumber)
        {
            return parkingplaces.SingleOrDefault(pl => pl.VehicleRegNumber == aRegistrationNumber);
        }
        #endregion
        #region Constructor
        public Garage()
        {
            LoadParkingPlaces();
        }
        #endregion

    }
    #region Exceptions
    class EUnknownVehicleType: Exception
    {
        public EUnknownVehicleType(string vehicleType): base(String.Format("Unknows vehicle type: {0}", vehicleType))
        {
        }
    }

    class ENoPlaceForVehicle: Exception
    {
        public ENoPlaceForVehicle(string vehicleType): 
            base (String.Format("No place for vehicle of type: {0}", vehicleType))
        {
        }
    }

    class EVehicleNotFound : Exception
    {
        public EVehicleNotFound(string aRegistrationNumber) :
            base(String.Format("Vehicle with registration number '{0}' not found.", aRegistrationNumber))
        {
        }
    }
#endregion
}
