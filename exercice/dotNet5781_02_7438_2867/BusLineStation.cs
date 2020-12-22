using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7438_2867
{
    internal class BusLineStation : BusStation
    {
        public static Random rnd1 = new Random();
        public BusLineStation(int busKey) : base(busKey)
        {
            DistanceFromThePreviousStation = rnd1.Next(500);
            TimeFromThePreviousStation = rnd1.Next(200);
        }

        public int DistanceFromThePreviousStation { set; get; }
        public int TimeFromThePreviousStation { set; get; }
    }
}
