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
                Console.Clear();  // Clears console
                Console.WriteLine("Welcome to the MATJParking! Please navigate through the menu: \n1.CheckIn \n2.CheckOut "
                    +"\n3.Search for your Vehicle \n4.Search for multiple Vehicles \n5.See all Vehicles at Garage \n6.Exit");
      		    Console.WriteLine("Please enter your selection: ");

                switch (Console.ReadLine())  //switch statement 
                {
                    case "1":
                        break;
                    case "2":
                        CheckOut();
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        runProgram = false;
                        break;
                }
            }
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
                    Console.WriteLine("The vehicle is parked at {0}. Price is SEK {1}\nDo you want to checkout y/n?", place.ID, place.Vehicle.Price);
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
