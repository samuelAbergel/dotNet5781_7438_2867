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
           List<BusLine> busLines = new List<BusLine>();
            for (int i = 0; i < 10; i++)
            {
                Area area = returnArea();
                busLines.Add(new BusLine(rnd.Next(100), area));
                for (int j = 0; j < 4; j++)
                {
                    busLines[i].AddStation(j, new BusLineStation(rnd.Next(999999)));
                }
            }
        }
        foreach(BusLine bus in busLines)
            Console.WriteLine( bus);
    }
}
