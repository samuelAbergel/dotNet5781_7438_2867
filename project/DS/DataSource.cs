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
            initList();
        }

        private static void initList()
        {
            listBus = new List<Bus>()
            {
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-10),
                   FuelRemain = 1200,
                   LicenseNum = 123456789,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2345,
                   BusOfLine =1,
                   previewTreatmentDate = DateTime.Now.AddMonths(-9)
                   
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-20),
                   FuelRemain = 1200,
                   LicenseNum = 987654321,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 4567,
                   BusOfLine = 1,
                   previewTreatmentDate = DateTime.Now.AddMonths(-19)

               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-167),
                   FuelRemain = 1200,
                   LicenseNum = 649458358,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 9876,
                   BusOfLine = 2,
                   previewTreatmentDate = DateTime.Now.AddMonths(-160)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-7890),
                   FuelRemain = 1200,
                   LicenseNum = 675636378,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 6278,
                   BusOfLine =2,
                   previewTreatmentDate = DateTime.Now.AddMonths(-7889)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-7896),
                   FuelRemain = 1200,
                   LicenseNum = 123456789,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 9278,
                   BusOfLine = 3,
                   previewTreatmentDate = DateTime.Now.AddMonths(-780)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-56),
                   FuelRemain = 1200,
                   LicenseNum = 875567342,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 8765,
                   BusOfLine = 3,
                   previewTreatmentDate = DateTime.Now.AddMonths(-9)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-526),
                   FuelRemain = 1200,
                   LicenseNum = 098765432,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2562,
                   BusOfLine = 4,
                   previewTreatmentDate = DateTime.Now.AddMonths(-15)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-98),
                   FuelRemain = 1200,
                   LicenseNum = 876256534,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2765,
                   BusOfLine = 4,
                   previewTreatmentDate = DateTime.Now.AddMonths(-12)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-257),
                   FuelRemain = 1200,
                   LicenseNum = 987654326,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 25522,
                   BusOfLine = 5,
                   previewTreatmentDate = DateTime.Now.AddMonths(-42)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-82),
                   FuelRemain = 1200,
                   LicenseNum = 0987654323,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 727,
                   BusOfLine = 5,
                   previewTreatmentDate = DateTime.Now.AddMonths(-24)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-16),
                   FuelRemain = 1200,
                   LicenseNum = 098765432,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 26725,
                   BusOfLine = 6,
                   previewTreatmentDate = DateTime.Now.AddMonths(-10)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-267),
                   FuelRemain = 1200,
                   LicenseNum = 257426568,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2562,
                   BusOfLine = 6,
                   previewTreatmentDate = DateTime.Now.AddMonths(-15)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-76),
                   FuelRemain = 1200,
                   LicenseNum = 275267202,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 25790,
                   BusOfLine = 7,
                   previewTreatmentDate = DateTime.Now.AddMonths(-12)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-566),
                   FuelRemain = 1200,
                   LicenseNum = 767565463,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 6382,
                   BusOfLine = 7,
                   previewTreatmentDate = DateTime.Now.AddMonths(-23)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-209),
                   FuelRemain = 1200,
                   LicenseNum = 286762962,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 6286,
                   BusOfLine = 8,
                   previewTreatmentDate = DateTime.Now.AddMonths(-30)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-256),
                   FuelRemain = 1200,
                   LicenseNum = 729872972,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2517,
                   BusOfLine = 8,
                   previewTreatmentDate = DateTime.Now.AddMonths(-2)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-123),
                   FuelRemain = 1200,
                   LicenseNum = 999999999,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 12345,
                   BusOfLine = 9,
                   previewTreatmentDate = DateTime.Now.AddMonths(-3)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-78),
                   FuelRemain = 1200,
                   LicenseNum = 268292782,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 8079,
                   BusOfLine = 9,
                   previewTreatmentDate = DateTime.Now.AddMonths(-7)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-526),
                   FuelRemain = 1200,
                   LicenseNum = 416462462,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 897,
                   BusOfLine = 10,
                   previewTreatmentDate = DateTime.Now.AddMonths(-9)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-567),
                   FuelRemain = 1200,
                   LicenseNum = 97867556,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 09878,
                   BusOfLine = 10,
                   previewTreatmentDate = DateTime.Now.AddMonths(-23)
               },
            };
            listLine = new List<Line>
            {
                new Line
                {
                    Id = 123456789,
                    Code = 1,
                    FirstStation = 275267202,
                    LastStation = 257426568,
                    Area = Areas.center,
                },
                new Line
                {
                    Id = 987654321,
                    Code = 2,
                    FirstStation = 275267202,
                    LastStation = 098765432,
                    Area = Areas.center,
                },
                new Line
                {
                    Id = 720752642,
                    Code = 3,
                    FirstStation = 0987654323,
                    LastStation = 257426568,
                    Area = Areas.east,
                },
                new Line
                {
                    Id = 1752975225,
                    Code = 4,
                    FirstStation = 987654326,
                    LastStation = 875567342,
                    Area = Areas.north,
                },
                new Line
                {
                    Id = 123456789,
                    Code = 5,
                    FirstStation = 123456789,
                    LastStation = 875567342,
                    Area = Areas.south,
                },
                new Line
                {
                    Id = 801892875,
                    Code = 6,
                    FirstStation = 987654321,
                    LastStation = 098765432,
                    Area = Areas.west,
                },
                new Line
                {
                    Id = 425729726,
                    Code = 7,
                    FirstStation = 098765432,
                    LastStation = 875567342,
                    Area = Areas.north,
                },
                new Line
                {
                    Id = 0867956688,
                    Code = 8,
                    FirstStation = 649458358,
                    LastStation = 123456789,
                    Area = Areas.south,
                },
                new Line
                {
                    Id = 769756444,
                    Code = 9,
                    FirstStation = 675636378,
                    LastStation = 987654326,
                    Area = Areas.west,
                },
                new Line
                {
                    Id = 0829687256,
                    Code = 10,
                    FirstStation = 098765432,
                    LastStation = 257426568,
                    Area = Areas.east,
                },
            };
            listBusOnTrip = new List<BusOnTrip>();
            listLineStation = new List<LineStation>();
            listLineTrip = new List<LineTrip>();
            listStation = new List<Station>
            {
                new Station
                {
                    Code= 3945,
                    Name= "station 1",
                    Lattitude=31.770868,
                    Longitude=35.173806,

                },
                new Station
                {
                    Code= 4725,
                    Name= "station 2",
                    Lattitude=31.746961,
                    Longitude=35.23278,

                },
                new Station
                {
                    Code= 1908,
                    Name= "station 3",
                    Lattitude=31.746998,
                    Longitude=35.2364,

                },
                new Station
                {
                    Code= 9634,
                    Name= "station 4",
                    Lattitude=31.746921,
                    Longitude=35.2167,

                },
                new Station
                {
                    Code= 3375,
                    Name= "station 5",
                    Lattitude=31.746341,
                    Longitude=35.2376,

                },
                new Station
                {
                    Code= 1879,
                    Name= "station 6",
                    Lattitude=31.727231,
                    Longitude=35.251990,

                },
                new Station
                {
                    Code= 5583,
                    Name= "station 7",
                    Lattitude=31.746976,
                    Longitude=35.251897,

                },
                new Station
                {
                    Code= 2411,
                    Name= "station 8",
                    Lattitude=31.712961,
                    Longitude=35.251721,

                },
                new Station
                {
                    Code= 5665,
                    Name= "station 9",
                    Lattitude=31.748165,
                    Longitude=35.251675,

                },
                new Station
                {
                    Code= 5328,
                    Name= "station 10",
                    Lattitude=31.748098,
                    Longitude=35.251586,

                },
                new Station
                {
                    Code= 5908,
                    Name= "station 11",
                    Lattitude=31.748076,
                    Longitude=35.251450,

                },
                new Station
                {
                    Code= 1324,
                    Name= "station 12",
                    Lattitude=31.748081,
                    Longitude=35.251365,

                },
                new Station
                {
                    Code= 9737,
                    Name= "station 13",
                    Lattitude=31.748067,
                    Longitude=35.251274,

                },
                new Station
                {
                    Code= 7409,
                    Name= "station 14",
                    Lattitude=31.7480514,
                    Longitude=35.251189,

                },
                new Station
                {
                    Code= 7218,
                    Name= "station 15",
                    Lattitude=31.7480489,
                    Longitude=35.192666,

                },
                new Station
                {
                    Code= 3398,
                    Name= "station 16",
                    Lattitude=31.748034,
                    Longitude=35.25166,

                },
                new Station
                {
                    Code= 9280,
                    Name= "station 17",
                    Lattitude=31.780296,
                    Longitude=35.251247,

                },
                new Station
                {
                    Code= 5547,
                    Name= "station 18",
                    Lattitude=31.748013,
                    Longitude=35.19529,

                },
                new Station
                {
                    Code= 7239,
                    Name= "station 19",
                    Lattitude=31.748351,
                    Longitude=35.19534,

                },
                new Station
                {
                    Code= 3385,
                    Name= "station 20",
                    Lattitude=31.770868,
                    Longitude=35.192666,

                },
                new Station
                {
                    Code= 1289,
                    Name= "station 21",
                    Lattitude=31.748349,
                    Longitude=35.19561,

                },
                new Station
                {
                    Code= 9238,
                    Name= "station 22",
                    Lattitude=31.728791,
                    Longitude=35.19573,

                },
                new Station
                {
                    Code= 2914,
                    Name= "station 23",
                    Lattitude=31.728098,
                    Longitude=35.195790,

                },
                new Station
                {
                    Code= 6482,
                    Name= "station 24",
                    Lattitude=31.728091,
                    Longitude=35.19589,

                },
                new Station
                {
                    Code= 8428,
                    Name= "station 25",
                    Lattitude=31.728089,
                    Longitude=35.19507,

                },
                new Station
                {
                    Code= 2904,
                    Name= "station 26",
                    Lattitude=31.728072,
                    Longitude=35.19509,

                },
                new Station
                {
                    Code= 7290,
                    Name= "station 27",
                    Lattitude=31.728076,
                    Longitude=35.195666,

                },
                new Station
                {
                    Code= 5540,
                    Name= "station 28",
                    Lattitude=31.728062,
                    Longitude=35.19541,

                },
                new Station
                {
                    Code= 1532,
                    Name= "station 29",
                    Lattitude=31.728059,
                    Longitude=35.231903,

                },
                new Station
                {
                    Code= 4020,
                    Name= "station 30",
                    Lattitude=31.728047,
                    Longitude=35.231894,

                },
                new Station
                {
                    Code= 9093,
                    Name= "station 31",
                    Lattitude=31.728039,
                    Longitude=35.231759,

                },
                new Station
                {
                    Code= 6881,
                    Name= "station 32",
                    Lattitude=31.728028,
                    Longitude=35.231684,

                },
                new Station
                {
                    Code= 5623,
                    Name= "station 33",
                    Lattitude=31.728011,
                    Longitude=35.231520,

                },
                new Station
                {
                    Code= 5423,
                    Name= "station 34",
                    Lattitude=31.815421,
                    Longitude=35.231387,

                },
                new Station
                {
                    Code= 9902,
                    Name= "station 35",
                    Lattitude=31.81090,
                    Longitude=35.23131,

                },
                new Station
                {
                    Code= 2309,
                    Name= "station 36",
                    Lattitude=31.810822,
                    Longitude=35.231295,

                },
                new Station
                {
                    Code= 9834,
                    Name= "station 37",
                    Lattitude=31.810762,
                    Longitude=35.231142,

                },
                new Station
                {
                    Code= 2204,
                    Name= "station 38",
                    Lattitude=31.810698,
                    Longitude=35.231094,

                },
                new Station
                {
                    Code= 2020,
                    Name= "station 39",
                    Lattitude=31.813421,
                    Longitude=35.231666,

                },
                new Station
                {
                    Code= 2021,
                    Name= "station 40",
                    Lattitude=31.810386,
                    Longitude=35.231583,

                },
            };
            listTrip = new List<Trip>();
            listTrip = new List<Trip>();
            listUser = new List<User>();
        }
    }
}
