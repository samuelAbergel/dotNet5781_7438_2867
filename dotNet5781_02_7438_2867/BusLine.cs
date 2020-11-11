using System;
using System.CodeDom.Compiler;
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
            string tostring = $"Line number: {LineNumber}, Area:{area.ToString()}, stations: \n";
            foreach (BusLineStation bus in Line)
                tostring += bus.ToString()+ "\n";
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
        public int getDistance(BusLineStation station1, BusLineStation station2)
            {
            int distance=0;
            for (int i=0; i<Line.IndexOf(station2)-Line.IndexOf(station1) ; i++ )
                {
                BusLineStation temp = Line[Line.IndexOf(station2) - i];
                distance+=temp.DistanceFromThePreviousStation;
                }
            return distance;
            }
        public int getTimeOfTraject (BusLineStation station1, BusLineStation station2)
        {
            int TimeOfTraject = 0;
            for (int i = 0; i < Line.IndexOf(station2) - Line.IndexOf(station1); i++)
            {
                BusLineStation temp = Line[Line.IndexOf(station2) - i];
                TimeOfTraject += temp.TimeFromThePreviousStation;
            }
            return TimeOfTraject;
        }
        public string getTraject(BusLineStation station1, BusLineStation station2)
        {
            int indexStation1 = Line.IndexOf(station1);
            int indexStation2 = Line.IndexOf(station2);
            string tostring = "trajet: \n";
            int i = 0;
            while (i != indexStation2-indexStation1)
            {
                tostring += Line[indexStation1 + i].ToString() + "\n";
                i++;
            }
            return tostring;
        }

    }
}
