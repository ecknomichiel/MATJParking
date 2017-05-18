using System;
using System.Collections;
using System.Collections.Generic;

namespace MATJParking
{
    class ParkingPlaceIndex: IPlaceObserver, IEnumerable<ParkingPlace>
    {
        private List<ParkingPlace> places = new List<ParkingPlace>();

        private bool parkedOnly; 

        public void OnPark(ParkingPlace place)
        {
            if (!parkedOnly)
            {
                places.Remove(place);
            }
            else
            {
                places.Add(place);
            }
            
        }
        public void OnUnpark(ParkingPlace place)
        {
            if (parkedOnly)
            {
                places.Remove(place);
            }
            else
            {
                places.Add(place);
            }
        }
        public void OnDelete(ParkingPlace place)
        {
            places.Remove(place);
        }
        public void Add(ParkingPlace place)
        {
            //Subscribe to changes in occupied / unoccupied
            place.Subscribe(this);
            //Add only places that should be in the index
            if (place.Occupied == parkedOnly)
            {
                places.Add(place);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return places.GetEnumerator();
        }

        IEnumerator<ParkingPlace> IEnumerable<ParkingPlace>.GetEnumerator()
        {
            return places.GetEnumerator();
        }

        public ParkingPlaceIndex(bool aParkedOnly)
        {
            parkedOnly = aParkedOnly;
        }
    }

    interface IPlaceObserver
    {
        void OnPark(ParkingPlace place);
        void OnUnpark(ParkingPlace place);
        void OnDelete(ParkingPlace place);
    }
}
