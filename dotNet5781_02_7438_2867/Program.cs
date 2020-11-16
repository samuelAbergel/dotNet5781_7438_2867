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
            Random rnd = new Random();
            CollectionOfBusLines collection = new CollectionOfBusLines();
            for (int i = 0; i < 3; i++)
                collection.AddLine(new BusLine(i + 10, Area.CENTER));
            for (int i = 3; i < 6; i++)
                collection.AddLine(new BusLine(i + 10, Area.GENERAL));
            for (int i = 6; i < 10; i++)
                collection.AddLine(new BusLine(i + 10, Area.NORTH));


            BusLineStation[] busStations = new BusLineStation[40];
            for (int i = 0; i < 40; i++)
            {
                busStations[i] = new BusLineStation(i + 100000);
                collection.lines[0].AddStation(i, busStations[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                collection.lines[1].AddStation(i, busStations[i]);
                collection.lines[2].AddStation(i, busStations[i]);
                collection.lines[3].AddStation(i, busStations[i]);
                collection.lines[4].AddStation(i, busStations[i]);
                collection.lines[5].AddStation(i, busStations[i]);
            }
            for (int i = 30; i < 40; i++)
            {
                collection.lines[6].AddStation(i - 30, busStations[i]);
                collection.lines[7].AddStation(i - 30, busStations[i]);
                collection.lines[8].AddStation(i - 30, busStations[i]);
                collection.lines[9].AddStation(i - 30, busStations[i]);
            }
            for (int i = 10; i < 30; i++)
            {
                collection.lines[2].AddStation(i, busStations[i]);
                collection.lines[3].AddStation(i, busStations[i]);
                collection.lines[7].AddStation(i, busStations[i]);
                collection.lines[8].AddStation(i, busStations[i]);
                collection.lines[9].AddStation(i, busStations[i]);
                collection.lines[5].AddStation(i, busStations[i]);
            }
            for (int i = 15; i < 25; i++)
            {
                collection.lines[4].AddStation(i - 5, busStations[i]);
                collection.lines[6].AddStation(i - 5, busStations[i]);
                collection.lines[1].AddStation(i - 5, busStations[i]);
            }
           
            CHOICE choice;
            bool success = true;

            string choix;
            bool isOk;
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
                        choix = Console.ReadLine();
                        if (choix == "station")
                        {
                            Console.WriteLine("enter the station's number ! ");
                            int numberStation;
                            string toInt = Console.ReadLine();
                             isOk = int.TryParse(toInt, out numberStation);
                            Console.WriteLine("in which lines do you want to add your station ? ");
                            int numberLines;
                            toInt = Console.ReadLine();
                            isOk = int.TryParse(toInt, out numberLines);
                            try
                            {
                                BusLineStation newLine = new BusLineStation(numberStation);
                                if (!collection[numberLines].isExist(newLine))
                                    collection[numberLines].AddStation(collection[numberLines].Line.Count, newLine);
                                else
                                {
                                    Console.WriteLine("this station already exists in this line");
                                    continue;
                                }
                            }
                            catch (ArgumentException msg)
                            {

                                Console.WriteLine(msg);
                            }
                        }
                        else if (choix == "line")
                        {
                            Console.WriteLine("what is the line number?");
                            bool flag = true;
                            int numberLines;
                            string toInt = Console.ReadLine();
                             isOk = int.TryParse(toInt, out numberLines);
                            foreach (BusLine busLine in collection.lines)
                                if (busLine.LineNumber == numberLines)
                                    flag = false;
                            if (flag)
                                collection.AddLine(new BusLine(numberLines, Area.SOUTH));
                            else
                                Console.WriteLine("this line already exists");
                        }
                        else
                        {
                            Console.WriteLine("you did not mean or want to add");
                        }
                        break;
                    case CHOICE.REMOVE:
                        Console.WriteLine("station or line ?");
                        choix = Console.ReadLine();
                        if (choix == "station")
                        {
                            Console.WriteLine("enter the station's number ! ");
                            int numberStation;
                            string toInt = Console.ReadLine();
                            isOk = int.TryParse(toInt, out numberStation);
                            Console.WriteLine("in which lines do you want to remove your station ? ");
                            int numberLines;
                            toInt = Console.ReadLine();
                            isOk = int.TryParse(toInt, out numberLines);
                            bool flag = true;
                            foreach (BusLine line in collection.lines)
                                if (line.LineNumber == numberLines)
                                    flag = false;
                            if (flag)
                            {
                                Console.WriteLine("this line does not exist");
                                break;
                            }
                            if (collection[numberLines].GetStation(numberStation) != null)
                            {
                                if (collection[numberLines].isExist(collection[numberLines].GetStation(numberStation)))
                                    collection[numberLines].RemoveStation(collection[numberLines].GetStation(numberStation));
                            }
                            else
                            {
                                Console.WriteLine("this station does not exist");
                                break;
                            }
                        }
                        else if (choix == "line")
                        {
                            Console.WriteLine("what is the line number?");
                            bool flag = false;
                            int numberLines;
                            string toInt = Console.ReadLine();
                            isOk = int.TryParse(toInt, out numberLines);
                            foreach (BusLine busLine in collection.lines)
                                if (busLine.LineNumber == numberLines)
                                    flag = true;
                            if (flag)
                                collection.RemoveLine(numberLines);
                            else
                                Console.WriteLine("this line does not exist");
                        }
                        else
                        {
                            Console.WriteLine("you did not mean or want to remove");
                        }
                        break;
                    case CHOICE.SEARCH:
                        Console.WriteLine("line or trajectory ?");
                        choix = Console.ReadLine();
                        if(choix == "line")
                        {
                            Console.WriteLine("what is the number of the station?");
                            int numberLines;
                            string toInt = Console.ReadLine();
                            isOk = int.TryParse(toInt, out numberLines);
                            try
                            {
                                collection.displayLine(numberLines);
                            }
                            catch (ArgumentException msg)
                            {
                                Console.WriteLine(msg);
                            }
                        }
                        else if(choix == "trajectory")
                        {
                            Console.WriteLine("what is the number of the 2 stations ?");
                            int numberStation;
                            string toInt = Console.ReadLine();
                            isOk = int.TryParse(toInt, out numberStation);
                            int numberStation1;
                            toInt = Console.ReadLine();
                            isOk = int.TryParse(toInt, out numberStation1);
                            int time = 0;
                            BusLine temp = null;
                            foreach(BusLine bus in collection.lines)
                            {
                                if (bus.GetStation(numberStation) != null && bus.GetStation(numberStation1) != null)
                                    time = bus.getTimeOfTraject(bus.GetStation(numberStation), bus.GetStation(numberStation1));
                            }
                            if (time == 0)
                            {
                                Console.WriteLine("no line runs through its 2 stations");
                                break;
                            }
                            foreach (BusLine bus in collection.lines)
                            {
                                if (bus.GetStation(numberStation) != null && bus.GetStation(numberStation1) != null)
                                {
                                    if (time > bus.getTimeOfTraject(bus.GetStation(numberStation), bus.GetStation(numberStation1)))
                                        time = bus.getTimeOfTraject(bus.GetStation(numberStation), bus.GetStation(numberStation1));
                                    temp = bus;
                                }
                            }
                            if(temp != null && time!= 0)
                            Console.WriteLine("line " + temp.LineNumber +"  " + time + " min");
                            else
                                Console.WriteLine("no line runs through its 2 stations");
                        }
                        else
                        {
                            Console.WriteLine("you did not mean or want to remove");
                        }
                        break;
                    case CHOICE.PRINT:
                        Console.WriteLine("all or justline ?");
                        choix = Console.ReadLine();
                        if(choix == "all")
                            Console.WriteLine(collection.displayAllLine());
                        else if (choix == "justline")
                        {
                          foreach(BusLine bus in collection.lines)
                                Console.WriteLine("line " + bus.LineNumber + "\n");
                        }
                        else
                        {
                            Console.WriteLine("you did not mean or want to print");
                        }
                        break;
                    case CHOICE.EXIT:
                        break;
                    default:
                        Console.WriteLine("you cannot perform this action");
                        break;
                }
       
            }
            while (choice != CHOICE.EXIT);
            Console.WriteLine("press any key to continue...");
            Console.ReadLine();
        }
    }
}
