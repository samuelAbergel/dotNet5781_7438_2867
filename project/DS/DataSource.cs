using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    /// <summary>
    /// init all list 
    /// </summary>
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
            intitStation();
            initList();
        }
        private static void intitStation()
        {
            listStation = new List<Station>
            {
                new Station
                {
                    Code= 3940,
                    Name= "station 1",
                    Lattitude=31.770868.ToString(),
                    Longitude=35.173806.ToString(),

                },
                new Station
                {
                    Code= 4721,
                    Name= "station 2",
                    Lattitude=31.746961.ToString(),
                    Longitude=35.23278.ToString(),

                },
                new Station
                {
                    Code= 1902,
                    Name= "station 3",
                    Lattitude=31.746998.ToString(),
                    Longitude=35.2364.ToString(),

                },
                new Station
                {
                    Code= 9633,
                    Name= "station 4",
                    Lattitude=31.746921.ToString(),
                    Longitude=35.2167.ToString(),

                },
                new Station
                {
                    Code= 3374,
                    Name= "station 5",
                    Lattitude=31.746341.ToString(),
                    Longitude=35.2376.ToString(),

                },
                new Station
                {
                    Code= 1875,
                    Name= "station 6",
                    Lattitude=31.727231.ToString(),
                    Longitude=35.251990.ToString(),

                },
                new Station
                {
                    Code= 5586,
                    Name= "station 7",
                    Lattitude=31.746976.ToString(),
                    Longitude=35.251897.ToString(),

                },
                new Station
                {
                    Code= 2417,
                    Name= "station 8",
                    Lattitude=31.712961.ToString(),
                    Longitude=35.251721.ToString(),

                },
                new Station
                {
                    Code= 5668,
                    Name= "station 9",
                    Lattitude=31.748165.ToString(),
                    Longitude=35.251675.ToString(),

                },
                new Station
                {
                    Code= 5329,
                    Name= "station 10",
                    Lattitude=31.748098.ToString(),
                    Longitude=35.251586.ToString(),

                },
                new Station
                {
                    Code= 5900,
                    Name= "station 11",
                    Lattitude=31.748076.ToString(),
                    Longitude=35.251450.ToString(),

                },
                new Station
                {
                    Code= 1324,
                    Name= "station 12",
                    Lattitude=31.748081.ToString(),
                    Longitude=35.251365.ToString(),

                },
                new Station
                {
                    Code= 9737,
                    Name= "station 13",
                    Lattitude=31.748067.ToString(),
                    Longitude=35.251274.ToString(),

                },
                new Station
                {
                    Code= 7405,
                    Name= "station 14",
                    Lattitude=31.7480514.ToString(),
                    Longitude=35.251189.ToString(),

                },
                new Station
                {
                    Code= 7218,
                    Name= "station 15",
                    Lattitude=31.7480489.ToString(),
                    Longitude=35.192666.ToString(),

                },
                new Station
                {
                    Code= 3398,
                    Name= "station 16",
                    Lattitude=31.748034.ToString(),
                    Longitude=35.25166.ToString(),

                },
                new Station
                {
                    Code= 9280,
                    Name= "station 17",
                    Lattitude=31.780296.ToString(),
                    Longitude=35.251247.ToString(),

                },
                new Station
                {
                    Code= 5547,
                    Name= "station 18",
                    Lattitude=31.748013.ToString(),
                    Longitude=35.19529.ToString(),

                },
                new Station
                {
                    Code= 7235,
                    Name= "station 19",
                    Lattitude=31.748351.ToString(),
                    Longitude=35.19534.ToString(),

                },
                new Station
                {
                    Code= 3385,
                    Name= "station 20",
                    Lattitude=31.770868.ToString(),
                    Longitude=35.192666.ToString(),

                },
                new Station
                {
                    Code= 1289,
                    Name= "station 21",
                    Lattitude=31.748349.ToString(),
                    Longitude=35.19561.ToString(),

                },
                new Station
                {
                    Code= 9238,
                    Name= "station 22",
                    Lattitude=31.728791.ToString(),
                    Longitude=35.19573.ToString(),

                },
                new Station
                {
                    Code= 2914,
                    Name= "station 23",
                    Lattitude=31.728098.ToString(),
                    Longitude=35.195790.ToString(),

                },
                new Station
                {
                    Code= 6482,
                    Name= "station 24",
                    Lattitude=31.728091.ToString(),
                    Longitude=35.19589.ToString(),

                },
                new Station
                {
                    Code= 8428,
                    Name= "station 25",
                    Lattitude=31.728089.ToString(),
                    Longitude=35.19507.ToString(),

                },
                new Station
                {
                    Code= 2904,
                    Name= "station 26",
                    Lattitude=31.728072.ToString(),
                    Longitude=35.19509.ToString(),

                },
                new Station
                {
                    Code= 7290,
                    Name= "station 27",
                    Lattitude=31.728076.ToString(),
                    Longitude=35.195666.ToString(),

                },
                new Station
                {
                    Code= 5540,
                    Name= "station 28",
                    Lattitude=31.728062.ToString(),
                    Longitude=35.19541.ToString(),

                },
                new Station
                {
                    Code= 1532,
                    Name= "station 29",
                    Lattitude=31.728059.ToString(),
                    Longitude=35.231903.ToString(),

                },
                new Station
                {
                    Code= 4020,
                    Name= "station 30",
                    Lattitude=31.728047.ToString(),
                    Longitude=35.231894.ToString(),

                },
                new Station
                {
                    Code= 9093,
                    Name= "station 31",
                    Lattitude=31.728039.ToString(),
                    Longitude=35.231759.ToString(),

                },
                new Station
                {
                    Code= 6881,
                    Name= "station 32",
                    Lattitude=31.728028.ToString(),
                    Longitude=35.231684.ToString(),

                },
                new Station
                {
                    Code= 5623,
                    Name= "station 33",
                    Lattitude=31.728011.ToString(),
                    Longitude=35.231520.ToString(),

                },
                new Station
                {
                    Code= 5423,
                    Name= "station 34",
                    Lattitude=31.815421.ToString(),
                    Longitude=35.231387.ToString(),

                },
                new Station
                {
                    Code= 9902,
                    Name= "station 35",
                    Lattitude=31.81090.ToString(),
                    Longitude=35.23131.ToString(),

                },
                new Station
                {
                    Code= 2309,
                    Name= "station 36",
                    Lattitude=31.810822.ToString(),
                    Longitude=35.231295.ToString(),

                },
                new Station
                {
                    Code= 9834,
                    Name= "station 37",
                    Lattitude=31.810762.ToString(),
                    Longitude=35.231142.ToString(),

                },
                new Station
                {
                    Code= 2204,
                    Name= "station 38",
                    Lattitude=31.810698.ToString(),
                    Longitude=35.231094.ToString(),

                },
                new Station
                {
                    Code= 2020,
                    Name= "station 39",
                    Lattitude=31.813421.ToString(),
                    Longitude=35.231666.ToString(),

                },
                new Station
                {
                    Code= 2021,
                    Name= "station 40",
                    Lattitude=31.810386.ToString(),
                    Longitude=35.231583.ToString(),

                },
            };
            listAdjacentStations = new List<AdjacentStations>
            {
                new AdjacentStations
                {
                  Station1 = 3940,
                  Station2 = 4721,
                  Distance = 1,
                  Time = TimeSpan.FromMinutes(55),
                },
                new AdjacentStations
                {
                  Station1 = 4721,
                  Station2 = 1902,
                  Distance = 1,
                  Time = TimeSpan.FromMinutes(30),
                },
                new AdjacentStations
                {
                  Station1 = 1902,
                  Station2 = 9633,
                  Distance = 1,
                  Time = TimeSpan.FromMinutes(25),
                },
                new AdjacentStations
                {
                  Station1 = 9633,
                  Station2 = 3374,
                  Distance = 2,
                  Time = TimeSpan.FromMinutes(15),
                },
                new AdjacentStations
                {
                  Station1 = 3374,
                  Station2 = 1875,
                  Distance = 2,
                  Time = TimeSpan.FromMinutes(45),
                },
                new AdjacentStations
                {
                  Station1 = 1875,
                  Station2 = 5586,
                  Distance = 2,
                  Time = TimeSpan.FromMinutes(53),
                },
                new AdjacentStations
                {
                  Station1 = 5586,
                  Station2 = 5668,
                  Distance = 3,
                  Time = TimeSpan.FromMinutes(50),
                },
                new AdjacentStations
                {
                  Station1 = 5668,
                  Station2 = 5329,
                  Distance = 3,
                  Time = TimeSpan.FromMinutes(40),
                },
                new AdjacentStations
                {
                  Station1 = 5329,
                  Station2 = 5900,
                  Distance = 3,
                  Time = TimeSpan.FromMinutes(42),
                },
                new AdjacentStations
                {
                  Station1 = 5900,
                  Station2 = 1324,
                  Distance = 4,
                  Time = TimeSpan.FromMinutes(35),
                },
                new AdjacentStations
                {
                  Station1 = 1324,
                  Station2 = 9737,
                  Distance = 4,
                  Time = TimeSpan.FromMinutes(33),
                },
                new AdjacentStations
                {
                  Station1 = 9737,
                  Station2 = 7409,
                  Distance = 4,
                  Time = TimeSpan.FromMinutes(31),
                },
                new AdjacentStations
                {
                  Station1 = 7409,
                  Station2 = 7218,
                  Distance = 5,
                  Time = TimeSpan.FromMinutes(41),
                },
                new AdjacentStations
                {
                  Station1 = 7218,
                  Station2 = 3398,
                  Distance = 5,
                  Time = TimeSpan.FromMinutes(42),
                },
                new AdjacentStations
                {
                  Station1 = 3398,
                  Station2 = 9280,
                  Distance = 5,
                  Time = TimeSpan.FromMinutes(43),
                },
                new AdjacentStations
                {
                  Station1 = 9280,
                  Station2 = 5547,
                  Distance = 6,
                  Time = TimeSpan.FromMinutes(50),
                },
                new AdjacentStations
                {
                  Station1 = 5547,
                  Station2 = 7239,
                  Distance = 6,
                  Time = TimeSpan.FromMinutes(52),
                },
                new AdjacentStations
                {
                  Station1 = 7239,
                  Station2 = 3385,
                  Distance = 6,
                  Time = TimeSpan.FromMinutes(51),
                },
                new AdjacentStations
                {
                  Station1 = 3385,
                  Station2 = 1289,
                  Distance = 7,
                  Time = TimeSpan.FromMinutes(15),
                },
                new AdjacentStations
                {
                  Station1 = 1289,
                  Station2 = 9238,
                  Distance = 7,
                  Time = TimeSpan.FromMinutes(16),
                },
                new AdjacentStations
                {
                  Station1 = 9238,
                  Station2 = 2914,
                  Distance = 7,
                  Time = TimeSpan.FromMinutes(18),
                },
                new AdjacentStations
                {
                  Station1 = 2914,
                  Station2 = 6482,
                  Distance = 8,
                  Time = TimeSpan.FromMinutes(26),
                },
                new AdjacentStations
                {
                  Station1 = 6482,
                  Station2 = 2914,
                  Distance = 8,
                  Time = TimeSpan.FromMinutes(29),
                },
                new AdjacentStations
                {
                  Station1 = 9238,
                  Station2 = 8428,
                  Distance = 8,
                  Time = TimeSpan.FromMinutes(27),
                },
                new AdjacentStations
                {
                  Station1 = 8428,
                  Station2 = 2904,
                  Distance = 9,
                  Time = TimeSpan.FromMinutes(39),
                },
                new AdjacentStations
                {
                  Station1 = 2904,
                  Station2 = 7290,
                  Distance = 9,
                  Time = TimeSpan.FromMinutes(35),
                },
                new AdjacentStations
                {
                  Station1 = 7290,
                  Station2 = 5540,
                  Distance = 9,
                  Time = TimeSpan.FromMinutes(37),
                },
                new AdjacentStations
                {
                  Station1 = 5540,
                  Station2 = 1532,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(53),
                },
                new AdjacentStations
                {
                  Station1 = 1532,
                  Station2 = 4020,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(54),
                },
                new AdjacentStations
                {
                  Station1 = 4020,
                  Station2 = 9093,
                  Distance = 10,
                  Time = TimeSpan.FromMinutes(59),
                },
            };
        }
        private static void initList()
        {
            listBus = new List<Bus>()
            {
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-10),
                   FuelRemain = 1050,
                   LicenseNum = 12345678,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2345,
                   BusOfLine =1,
                   previewTreatmentDate = DateTime.Now.AddMonths(-9)
                   
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-20),
                   FuelRemain = 1200,
                   LicenseNum = 98765432,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 4567,
                   BusOfLine = 1,
                   previewTreatmentDate = DateTime.Now.AddMonths(-19)

               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-167),
                   FuelRemain = 1200,
                   LicenseNum = 6494,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 9876,
                   BusOfLine = 2,
                   previewTreatmentDate = DateTime.Now.AddMonths(-160)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-7890),
                   FuelRemain = 1200,
                   LicenseNum = 6756366,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 6278,
                   BusOfLine =2,
                   previewTreatmentDate = DateTime.Now.AddMonths(-7889)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-7896),
                   FuelRemain = 1200,
                   LicenseNum = 1236789,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 9278,
                   BusOfLine = 3,
                   previewTreatmentDate = DateTime.Now.AddMonths(-780)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-56),
                   FuelRemain = 1200,
                   LicenseNum = 8755342,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 8765,
                   BusOfLine = 3,
                   previewTreatmentDate = DateTime.Now.AddMonths(-9)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-526),
                   FuelRemain = 1200,
                   LicenseNum = 0985432,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2562,
                   BusOfLine = 4,
                   previewTreatmentDate = DateTime.Now.AddMonths(-15)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-98),
                   FuelRemain = 1200,
                   LicenseNum = 8766534,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2765,
                   BusOfLine = 4,
                   previewTreatmentDate = DateTime.Now.AddMonths(-12)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-257),
                   FuelRemain = 1200,
                   LicenseNum = 98765326,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 25522,
                   BusOfLine = 5,
                   previewTreatmentDate = DateTime.Now.AddMonths(-42)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-82),
                   FuelRemain = 1200,
                   LicenseNum = 09876423,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 727,
                   BusOfLine = 5,
                   previewTreatmentDate = DateTime.Now.AddMonths(-24)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-16),
                   FuelRemain = 1200,
                   LicenseNum = 09875432,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 26725,
                   BusOfLine = 6,
                   previewTreatmentDate = DateTime.Now.AddMonths(-10)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-267),
                   FuelRemain = 1200,
                   LicenseNum = 2426568,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2562,
                   BusOfLine = 6,
                   previewTreatmentDate = DateTime.Now.AddMonths(-15)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-76),
                   FuelRemain = 1200,
                   LicenseNum = 2752202,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 25790,
                   BusOfLine = 7,
                   previewTreatmentDate = DateTime.Now.AddMonths(-12)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-566),
                   FuelRemain = 1200,
                   LicenseNum = 76756463,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 6382,
                   BusOfLine = 7,
                   previewTreatmentDate = DateTime.Now.AddMonths(-23)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-209),
                   FuelRemain = 1200,
                   LicenseNum = 2867296,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 6286,
                   BusOfLine = 8,
                   previewTreatmentDate = DateTime.Now.AddMonths(-30)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-256),
                   FuelRemain = 1200,
                   LicenseNum = 7292972,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2517,
                   BusOfLine = 8,
                   previewTreatmentDate = DateTime.Now.AddMonths(-2)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-123),
                   FuelRemain = 1200,
                   LicenseNum = 9999999,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 12345,
                   BusOfLine = 9,
                   previewTreatmentDate = DateTime.Now.AddMonths(-3)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-78),
                   FuelRemain = 1200,
                   LicenseNum = 2682982,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 8079,
                   BusOfLine = 9,
                   previewTreatmentDate = DateTime.Now.AddMonths(-7)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-526),
                   FuelRemain = 1200,
                   LicenseNum = 41642462,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 897,
                   BusOfLine = 10,
                   previewTreatmentDate = DateTime.Now.AddMonths(-9)
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-567),
                   FuelRemain = 1200,
                   LicenseNum = 9786556,
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
                    FirstStation = 275267202.ToString(),
                    LastStation = 257426568.ToString(),
                    Area = Areas.center,
                   
                },
                new Line
                {
                    Id = 987654321,
                    Code = 2,
                    FirstStation = 275267202.ToString(),
                    LastStation = 098765432.ToString(),
                    Area = Areas.center,
                },
                new Line
                {
                    Id = 720752642,
                    Code = 3,
                    FirstStation = 0987654323.ToString(),
                    LastStation = 257426568.ToString(),
                    Area = Areas.east,
                },
                new Line
                {
                    Id = 1752975225,
                    Code = 4,
                    FirstStation = 987654326.ToString(),
                    LastStation = 875567342.ToString(),
                    Area = Areas.north,
                },
                new Line
                {
                    Id = 123456789,
                    Code = 5,
                    FirstStation = 123456789.ToString(),
                    LastStation = 875567342.ToString(),
                    Area = Areas.south,
                },
                new Line
                {
                    Id = 801892875,
                    Code = 6,
                    FirstStation = 987654321.ToString(),
                    LastStation = 098765432.ToString(),
                    Area = Areas.west,
                },
                new Line
                {
                    Id = 425729726,
                    Code = 7,
                    FirstStation = 098765432.ToString(),
                    LastStation = 875567342.ToString(),
                    Area = Areas.north,
                },
                new Line
                {
                    Id = 0867956688,
                    Code = 8,
                    FirstStation = 649458358.ToString(),
                    LastStation = 123456789.ToString(),
                    Area = Areas.south,
                },
                new Line
                {
                    Id = 769756444,
                    Code = 9,
                    FirstStation = 675636378.ToString(),
                    LastStation = 987654326.ToString(),
                    Area = Areas.west,
                },
                new Line
                {
                    Id = 0829687256,
                    Code = 10,
                    FirstStation = 098765432.ToString(),
                    LastStation = 257426568.ToString(),
                    Area = Areas.east,
                },
            };
            listBusOnTrip = new List<BusOnTrip>();
            listLineStation = new List<LineStation>();
            listLineTrip = new List<LineTrip>();
            listTrip = new List<Trip>();
            listUser = new List<User>();
        }
    }
}
