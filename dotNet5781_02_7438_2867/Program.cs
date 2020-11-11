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
            BusLine ligne1 = new BusLine(new Random().Next(0, 50), FirstStation, LastStation);
            for (int i=0;i<5;i++)
            {
                ligne1.AddStation(i, new BusLineStation());
            }
            Console.WriteLine(ligne1.ToString());
            Console.WriteLine(ligne1.isExist(FirstStation) ? true:false);
            Console.ReadKey();
        }
    }
}
