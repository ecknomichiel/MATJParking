using System;
using System.Collections.Generic;
using System.Linq;

namespace MATJParking
{
    class Garage
    {
        private List<ParkingPlace> parkingPlaces = new List<ParkingPlace>();
        #region Private Methods
        private ParkingPlace CreateParkingPlace(string aID, Type aVehicleType)
        {
            ParkingPlace result = new ParkingPlace() {ID = aID};
            result.AddVehicleType(aVehicleType);
            return result;
        }
        private Vehicle CreateVehicle(string aVehicleType)
        {
            switch (aVehicleType)
            {
                case "Motorcycle":
                    return new MotorCycle();
                case "Car":
                    return new Car();
                case "Bus":
                    return new Bus();
                case "Truck":
                    return new Truck();
                default:
                    throw new EUnknownVehicleType(aVehicleType);
            }
        }
        private void LoadParkingPlaces()
        {
            int i, nextID;
            nextID = 1;
            for (i = 0; i < 1; i++ ) 
            {
                parkingPlaces.Add(CreateParkingPlace("B" + nextID++, typeof(Bus)));
            }
            for (i = 0; i < 3; i++)
            {
                parkingPlaces.Add(CreateParkingPlace("T" + nextID++, typeof(Truck)));
            }
            for (i = 0; i < 10; i++)
            {
                parkingPlaces.Add(CreateParkingPlace("C" + nextID++, typeof(Car)));
            }
            for (i = 0; i < 5; i++)
            {
                parkingPlaces.Add(CreateParkingPlace("B" + nextID++, typeof(MotorCycle)));
            }
            //Add the first 10 spaces are suited for motorcycles as well
            for (i = 0; i < 10; i++)
            {
                parkingPlaces[i].AddVehicleType(typeof(MotorCycle));
            }
        }
        #endregion
        #region Public Methods
        public string CheckIn(string RegistrationNumber, string aVehicleType)
        {
            Vehicle vehicle = CreateVehicle(aVehicleType);
            vehicle.RegNumber = RegistrationNumber;
            ParkingPlace place = SearchPlaceWhereVehicleIsParked(RegistrationNumber);
            if (place != null)
                throw new EVehicleAlreadyCheckedIn(RegistrationNumber, place.ID);
            try
            { //If there is no available space for this type of car, an exception is raised (sequence contains no elements)
                place = parkingPlaces.Where(pl => pl.IsCompatibleWith(vehicle))
                                                .Where(pl => !pl.Occupied)
                                                .First();
            }
            catch (Exception)
            {// Throw our own exception with a custom message text
                throw new ENoPlaceForVehicle(vehicle.GetType().Name);
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
            return parkingPlaces;
        }
        public IEnumerable<ParkingPlace> SearchAllParkedVehicles()
        {
            return parkingPlaces.Where(pl => pl.Occupied);
        }
        public IEnumerable<ParkingPlace> SearchAllParkedVehiclesOnPrice(double aPrice, bool greaterThan)
        {
            if (greaterThan)
                return parkingPlaces.Where(pl => pl.Occupied && pl.Vehicle.Price >= aPrice);
            else
                return parkingPlaces.Where(pl => pl.Occupied && pl.Vehicle.Price <= aPrice);
        }

        public IEnumerable<ParkingPlace> SearchAllParkedVehiclesOnParkingTime(double hours, bool greaterThan)
        {
            if (greaterThan)
                return parkingPlaces.Where(pl => pl.Occupied && pl.Vehicle.ParkingTime >= hours);
            else
                return parkingPlaces.Where(pl => pl.Occupied && pl.Vehicle.ParkingTime <= hours);
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
        {// Can throw an exception if a programmer bypassed the checkin function to park a car
            return parkingPlaces.SingleOrDefault(pl => pl.Occupied && pl.VehicleRegNumber == aRegistrationNumber);
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
            base (String.Format("No place available for a {0}", vehicleType.ToString().ToLower()))
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

    class EVehicleAlreadyCheckedIn : Exception
    {
        public EVehicleAlreadyCheckedIn(string aRegistrationNumber, string aParkingID) :
            base(String.Format("Vehicle with registration number '{0}' is already checked in at place {1}.", aRegistrationNumber, aParkingID))
        {
        }
    }
#endregion
}
