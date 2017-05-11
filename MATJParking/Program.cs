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

            //Main menu
            bool runProgram = true;
            while (runProgram == true)

            {
                Console.Clear();  // Clears console
                Console.WriteLine("Welcome to the MATJParking! Please navigate through the menu: \n1.CheckIn \n2.CheckOut "
                    +"\n3.Search for your Vehicle \n4.Search for multiple Vehicles \n5.See all Vehicles at Garage \n6.Exit");
      		    Console.WriteLine("Please enter your selection: ");

                string input = Console.ReadLine();

                switch (input)  //switch statement 
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("Add a new vehicle to the grage");
                        Console.WriteLine("---------------------------------------");
                       Console.WriteLine("Please Add the Registration Number");
                       string regNumber =Console.ReadLine();
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("Please chose what vehicle Type");
                        Console.WriteLine("----------------------------------------");
                        
                        string vType = Console.ReadLine();

             
                        garage.CheckIn(regNumber, vType);
                        break;

                    case "2":

                        break;
                    case "3":
                        
                    break;
                    case "4":

                        break;
                    case "5":

                        break;

                    default:
                        break;
                }

            }
        }
    }
}
