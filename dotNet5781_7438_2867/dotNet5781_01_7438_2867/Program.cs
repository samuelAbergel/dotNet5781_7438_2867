using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace dotNet5781_01_7438_2867
{

    class Program
    {

        static void Main(string[] args)
        {
            List<Bus> buses = new List<Bus>();

            CHOICE choice;
            bool success = true;
            do
            {
                Console.WriteLine("Please, make your choce:");
                Console.WriteLine("ADD_BUS, PICK_BUS, REFUEL_BUS, MAINTENANCE_BUS,  EXIT");

                success = Enum.TryParse(Console.ReadLine(), out choice);
                if (!success)
                {
                    continue;
                }
                switch (choice)
                {
                    case CHOICE.ADD_BUS:
                        insertBus(buses);
                        break;
                    case CHOICE.PICK_BUS:
                        printall(buses);
                        string registration = Console.ReadLine();
                        Bus bus = findBuses(buses, registration);
                        Random rnd = new Random();
                        int num = rnd.Next(1, 1200);
                        if (bus != null)
                        {
                            Console.WriteLine("the bus is {0} and th km is {1}", bus, num);
                            Console.WriteLine(bus.KM);
                            if (bus.KM > num)
                            {
                                Console.WriteLine("the bus can go!!");
                                bus.KMT += num;
                                bus.KM -= num;
                            }
                            else
                                Console.WriteLine("the bus can't go!!");
                        }
                        else
                        {
                            Console.WriteLine("ein kaze!!!");
                        }
                        break;
                    case CHOICE.REFUEL_BUS:
                        printall(buses);
                        string registration1 = Console.ReadLine();
                        Bus bus1 = findBuses(buses, registration1);
                        DateTime currentDate = DateTime.Now;
                        Console.WriteLine("are you want a refueling or handling?");
                        string request = Console.ReadLine();
                        if (request == "refueling")
                        {
                            bus1.KM = 1200;
                        }
                        else if (request == "handling")
                        {
                            bus1.KMT = 0;
                            bus1.CURRENTALYA = currentDate;
                        }
                        else
                        {
                            Console.WriteLine("ERROR");
                        }
                        break;
                    case CHOICE.MAINTENANCE_BUS:
                        representation(buses);
                        break;
                    case CHOICE.EXIT:
                        break;
                    default:
                        choice = CHOICE.EXIT;
                        break;
                }

            } while (choice != CHOICE.EXIT);
        }

    

    
        public static Bus findBuses(List<Bus> buses, string registration)
        {
            registration = registration.Replace("-", string.Empty);

            Bus bus = null;
            foreach (Bus item in buses)
            {
                if (item.Registration == registration)
                {
                    bus = item;
                }
            }
            return bus;
        }

        public static void printall(List<Bus> buses)
        {
            foreach (Bus bus in buses)
            {
                Console.WriteLine(bus);
            }
        }
        public static void representation(List<Bus> buses)
        {
            foreach (Bus bus in buses)
            {
                string prefix, middle, suffix;
                if ( bus.Registration.Length == 7)
                {
                    prefix = bus.Registration.Substring(0, 2);
                    middle = bus.Registration.Substring(2, 3);
                    suffix = bus.Registration.Substring(5, 2);
                }
                else
                {
                    prefix = bus.Registration.Substring(0, 3);
                    middle = bus.Registration.Substring(3, 2);
                    suffix = bus.Registration.Substring(5, 3);
                }
                string registrationString = String.Format("{0}-{1}-{2}", prefix, middle, suffix);

                Console.WriteLine("[{0}, {1}]\n", registrationString, bus.CURRENTALYA);
            }
        }

        public static void insertBus(List<Bus> buses)
        {
            string rishuy;
            DateTime taarich;

            //taarich
            Console.WriteLine("taarich");
            bool success = DateTime.TryParse(Console.ReadLine(), out taarich);
            if (!success)
            {
                Console.WriteLine("Error");
                return;
            }

            //rishuy
            Console.WriteLine("rishuy: ");
            rishuy = Console.ReadLine();
            try
            {
                buses.Add(new Bus(rishuy, taarich));
                printall(buses);
            }
            catch (Exception baaya)
            {
                Console.WriteLine(baaya.Message);
            }

        }
    }
}

