using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7438_2867
{
    class BusStation
    {
        public int BusKey { get; set; }
        public float Latitude { get; set; }
        public float Longitude {get;set; }
        public string address { get; set; }

        public BusStation()
        {
            this.BusKey = new Random().Next(100000,999999);
            this.Latitude = new Random().Next(-90,90);
            this.Longitude = new Random().Next(-180, 180);
        }
        public override string ToString()
        {
            return string.Format($"Bus Staion Code: {BusKey}, {Latitude}°N {Longitude}°E");
        }
    }
}
