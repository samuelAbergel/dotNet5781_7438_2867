using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7438_2867
{
    internal class BusLineStation : BusStation
    {
        public BusLineStation() : base(){}

        public int DistanceFromThePreviousStation { set; get; }
        public int TimeFromThePreviousStation { set; get; }
    }
}
