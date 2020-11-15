using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7438_2867
{
    class BusStation
    {
        static Random rnd = new Random();
        public int BusKey { get; set; }
        public float Latitude { get; set; }
        public float Longitude {get;set; }
        public string address { get; set; }

        public BusStation( int BusKey)
        {
            this.BusKey = BusKey;
            Latitude = rnd.Next(-90,90);
            Longitude = rnd.Next(-180, 180);
        }
        public override string ToString()
        {
            return string.Format($"Bus Staion Code: {BusKey}, {Latitude}°N {Longitude}°E");
        }
    }
}
