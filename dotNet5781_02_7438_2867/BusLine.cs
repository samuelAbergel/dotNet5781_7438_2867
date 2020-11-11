using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7438_2867
{
    class BusLine
    {
        public List<BusLineStation> Line { get; set; }
        public int LineNumber { get; set; }
        public BusLineStation FirstStation { get; set; }
        public BusLineStation LastStation { get; set; }
        public Area area { get; set; }

        public BusLine(int LineNumber,BusLineStation FirstStation, BusLineStation LastStation)
        {
            Line = new List<BusLineStation>();
            this.LineNumber = LineNumber;
            this.FirstStation = FirstStation;
            this.LastStation = LastStation;
        }

        public override string ToString()
        {
            string tostring = $"Line number: {LineNumber}, Area:{area.ToString()}, stations: \n ";
            foreach (BusLineStation bus in Line)
                tostring += bus.ToString();
            return tostring;
        }
        public void AddStation(int index, BusLineStation BusLine1)
        {
            this.Line.Insert(index, BusLine1);
        }
        public void RemoveStation(BusLineStation BusLine1)
        {
            this.Line.Remove(BusLine1);
        }
        public bool isExist(BusLineStation busLine1)
        {
            return Line.Exists(s=>s.BusKey == busLine1.BusKey);
        }

    }
}
