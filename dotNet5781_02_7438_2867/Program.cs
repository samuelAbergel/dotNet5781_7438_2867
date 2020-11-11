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
            BusLineStation FirstStation = new BusLineStation();
            BusLineStation LastStation = new BusLineStation();
            BusLineStation b = new BusLineStation();
            BusLine ligne1 = new BusLine(new Random().Next(0, 50), FirstStation, LastStation);
            int i = 0;
            ligne1.AddStation(0, FirstStation);
            ligne1.AddStation(1, new BusLineStation());
            ligne1.AddStation(2, new BusLineStation());
            ligne1.AddStation(3, new BusLineStation()); 
            ligne1.AddStation(4, b);
            ligne1.AddStation(5, new BusLineStation());
            ligne1.AddStation(6, new BusLineStation());
            ligne1.AddStation(7, new BusLineStation());
            ligne1.AddStation(8, LastStation);
            Console.WriteLine(ligne1.ToString());
            //Console.WriteLine(ligne1.isExist(FirstStation) ? true:false);
            //Console.WriteLine(ligne1.getDistance(FirstStation,LastStation));
            //Console.WriteLine(ligne1.getTimeOfTraject(FirstStation, LastStation));
            Console.WriteLine(ligne1.getTraject(b, LastStation));
            Console.ReadKey();
        }
    }
}
