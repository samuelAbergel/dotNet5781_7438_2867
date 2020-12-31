using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public static class DataSource
    {
        public static List<Bus> listBus;
        public static List<Line> listLine;
        public static List<Station> listStation;
        public static List<AdjacentStations> listAdjacentStations;
        public static List<BusOnTrip> listBusOnTrip;
        public static List<LineStation> listLineStation;
        public static List<LineTrip> listLineTrip;
        public static List<Trip> listTrip;
        public static List<User> listUser;


        static DataSource()
        {
            listBus = new List<Bus>();
            listBusOnTrip = new List<BusOnTrip>();
            listLine = new List<Line>();
            listLineStation = new List<LineStation>();
            listLineTrip = new List<LineTrip>();
            listStation = new List<Station>();
            listTrip = new List<Trip>();
            listTrip = new List<Trip>();
            listUser = new List<User>();
        }
    }
}
