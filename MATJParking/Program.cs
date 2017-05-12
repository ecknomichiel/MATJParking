using System;
using System.Collections.Generic;

namespace MATJParking
{
    class Program
    {
        private static Garage garage = new Garage();
        static void Main(string[] args)
        {
            //Main menu
            bool runProgram = true;
            while (runProgram)

            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Welcome to the MATJParking! Please navigate through the menu: \n1.CheckIn \n2.CheckOut "
              + "\n3.Search for your Vehicle \n4.Search for multiple Vehicles \n5.See all the Vehicles parked in the Garage \n6.Exit");
                Console.WriteLine("Please enter your selection: ");

                switch (Console.ReadLine())  
                {
                    case "1":
                        Checkin();
                        break;
                    case "2":
                        CheckOut();
                        break;
                    case "3":
                        SearchVehicle();
                        break;
                    case "4":
                        SearchForMultipleVehicles();
                        break;
                    case "5":
                        ViewAllParkedVehicles();
                        break;
                    case "6":
                        runProgram = false;
                        break;
                }
            }
        }
        private static void ViewAllParkedVehicles()
        {
            //Console.WriteLine(garage.SearchAllParkedVehicles());
            foreach (ParkingPlace place in garage.SearchAllParkedVehicles())
            {
                Console.WriteLine(place.ToString());
            }
            Console.ReadKey();
        }
        private static void SearchVehicle()
        {
            Console.WriteLine("Please enter your vehicle's registration number.");
            string regNr = Console.ReadLine();
            try
            {
                ParkingPlace place = garage.SearchPlaceWhereVehicleIsParked(regNr);
                if (place == null)
                {
                    Console.WriteLine("Cannot find the vehicle with registration number '{0}'", regNr);
                }
                else
                {
                    Console.WriteLine("The vehicle is parked at {0}.\n{1}", place.ID, place.Vehicle.ToString());
                }
            }
            catch (EVehicleNotFound e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        private static void SearchForMultipleVehicles()
        {
            Console.WriteLine("Search vehicles: \n1) All parking places\n2) Search vehicles on parking price.\n3) Search vehicles on parking time");
            string input = ConstrainInput("", new string[]{"1", "2", "3"});
            IEnumerable<ParkingPlace> query;
            string reportTitle;
            bool greaterThan;
            switch(input)
            {
                case "1":
                    reportTitle = "All parking places";
                    query = garage.SearchAllParkingPlaces();
                    break;
                case "2":
                    reportTitle = "Search vehicles on parking price.";
                    Console.WriteLine(reportTitle);
                    double aPrice = AskForNumberToCompare("price", out greaterThan);
                    query = garage.SearchAllParkedVehiclesOnPrice(aPrice, greaterThan);
                    break;
                case "3":
                    reportTitle = "Search vehicles on parking time. (hours)";
                    Console.WriteLine(reportTitle);
                    double hours = AskForNumberToCompare("parking time", out greaterThan);
                    query = garage.SearchAllParkedVehiclesOnParkingTime(hours, greaterThan);
                    break;
                default: return;
            }
            Console.Clear();
            Console.WriteLine(reportTitle);
            foreach (ParkingPlace place in query)
            {
                Console.WriteLine(place.ToString());
            }
            Console.ReadKey();
        }

        public static double AskForNumberToCompare(string aName, out bool greaterThan)
        {
            double result;
            do //Ask for price again and again untill a number is entered
                Console.Write("Please enter the {0}: ", aName);
            while (!double.TryParse(Console.ReadLine(), out result));
            greaterThan = ">" == ConstrainInput(String.Format("Choose '<' to search for items with a {0} smaller than the {0} you entered or '>' to search for item with a greater {0} ", aName), 
                                                new string[] { "<", ">" });
            return result;
        }

        private static void CheckOut()
        {
            Console.WriteLine("Check out\nWhat is the registration number of the car you want to check out?");
            string regNr = Console.ReadLine();
            try
            {
                ParkingPlace place = garage.SearchPlaceWhereVehicleIsParked(regNr);
                if (place == null)
                {
                    Console.WriteLine("Cannot find the vehicle with registration numner '{0}'", regNr);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("The vehicle is parked at {0}. Price is SEK {1}", place.ID, place.Vehicle.Price);
                    switch (ConstrainInput("Do you want to checkout y/n?", new string[] { "y", "n" }))
                    {
                        case "y":
                            garage.CheckOut(regNr);
                            break;
                        case "n":
                            return;
                    }
                }
            }

            catch (EVehicleNotFound e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void Checkin()
        {
            Console.WriteLine();
            Console.WriteLine("Park your vehicle in the garage");
            Console.WriteLine("Please enter the registration Number");
            string regNumber = Console.ReadLine();
            Console.WriteLine("Please choose what vehicle Type");
            Console.WriteLine("1) Motorcycle\n2) Car\n3) Bus\n4) Truck");

            string input = ConstrainInput("Type: ", new string[] { "1", "2", "3", "4" });

            VehicleType vt;
            switch (input)
            {
                case "1":
                    vt = VehicleType.Motorcycle;
                    break;
                case "2":
                    vt = VehicleType.Car;
                    break;
                case "3":
                    vt = VehicleType.Bus;
                    break;
                default:
                    vt = VehicleType.Truck;
                    break;
                
            }

            try
            {
                Console.WriteLine("{0} with registration number {1} is now checked in at place {2}.", vt, regNumber, garage.CheckIn(regNumber, vt));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
        private static string ConstrainInput(string question, string[] allowedValues)
        {
            string input;
            while (true)
            {
                Console.Write(question);
                input = Console.ReadLine();
                foreach(string s in allowedValues)
                {
                    if (input == s)
                        return input;
                }

            }
        }
    }
}
