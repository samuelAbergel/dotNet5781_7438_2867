using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7438_2867
{
    class Program
    {


        static void Main(string[] args)
        {
            List<BusLine> busLines = new List<BusLine>();
            for (int i = 0; i < 3; i++)
                busLines[i] = new BusLine(i + 10, Area.CENTER);
            for (int i = 3; i < 6; i++)
                busLines[i] = new BusLine(i + 10, Area.GENERAL);
            for (int i = 6; i < 10; i++)
                busLines[i] = new BusLine(i + 10, Area.NORTH);


            List<BusLineStation> busStations = new List<BusLineStation>();
            for (int i = 0; i < 40; i++)
            {
                busStations[i] = new BusLineStation(i + 100000);
                busLines[0].AddStation(i, busStations[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                busLines[1].AddStation(i, busStations[i]);
                busLines[2].AddStation(i, busStations[i]);
                busLines[3].AddStation(i, busStations[i]);
                busLines[4].AddStation(i, busStations[i]);
                busLines[5].AddStation(i, busStations[i]);
            }
            for (int i = 30; i < 40; i++)
            {
                busLines[6].AddStation(i - 30, busStations[i]);
                busLines[7].AddStation(i - 30, busStations[i]);
                busLines[8].AddStation(i - 30, busStations[i]);
                busLines[9].AddStation(i - 30, busStations[i]);
            }
            for (int i = 10; i < 30; i++)
            {
                busLines[2].AddStation(i, busStations[i]);
                busLines[3].AddStation(i, busStations[i]);
                busLines[7].AddStation(i, busStations[i]);
                busLines[8].AddStation(i, busStations[i]);
                busLines[9].AddStation(i, busStations[i]);
                busLines[5].AddStation(i, busStations[i]);
            }
            for (int i = 15; i < 25; i++)
            {
                busLines[4].AddStation(i - 5, busStations[i]);
                busLines[6].AddStation(i - 5, busStations[i]);
                busLines[1].AddStation(i - 5, busStations[i]);
            }

            CHOICE choice;
            bool success = true;


            do
            {
                Console.WriteLine("Please, make your choce:");
                Console.WriteLine("ADD, REMOVE, SEARCH, PRINT,  EXIT");

                success = Enum.TryParse(Console.ReadLine(), out choice);
                if (!success)
                {
                    continue;
                }
                switch (choice)
                {
                    case CHOICE.ADD:
                        Console.WriteLine("station or line ?");
                        string choix;
                        choix = Console.ReadLine();
                        if (choix == "station")
                        {
                            Console.WriteLine("enter the station's number ! ");
                            int numberStation;
                            string toInt = Console.ReadLine();
                            bool isOk = int.TryParse(toInt, out numberStation);
                            Console.WriteLine("in which lines do you want to add your station ? ");
                            int numberLines;
                            toInt = Console.ReadLine();
                            isOk = int.TryParse(toInt, out numberLines);
                            if(busLines[numberLines].isExist(busStations[numberStation])


                        }
                        break;
                    default:
                        break;
                }
       
            }
            while (choice != CHOICE.EXIT);
            Console.ReadKey();

        }
    }
}
