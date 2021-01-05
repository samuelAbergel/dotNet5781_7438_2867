﻿using DO;
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
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-20),
                   FuelRemain = 1200,
                   LicenseNum = 987654321,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 4567,

               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-167),
                   FuelRemain = 1200,
                   LicenseNum = 649458358,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 9876,
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-7890),
                   FuelRemain = 1200,
                   LicenseNum = 675636378,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 6278,
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-7896),
                   FuelRemain = 1200,
                   LicenseNum = 123456789,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 9278,
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-56),
                   FuelRemain = 1200,
                   LicenseNum = 875567342,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 8765,
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-526),
                   FuelRemain = 1200,
                   LicenseNum = 098765432,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2562,
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-98),
                   FuelRemain = 1200,
                   LicenseNum = 876256534,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2765,
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-257),
                   FuelRemain = 1200,
                   LicenseNum = 987654326,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 25522,
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-82),
                   FuelRemain = 1200,
                   LicenseNum = 0987654323,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 727,
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-16),
                   FuelRemain = 1200,
                   LicenseNum = 098765432,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 26725,
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(-267),
                   FuelRemain = 1200,
                   LicenseNum = 257426568,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 2562,
               },
               new Bus
               {
                   FromDate = DateTime.Now.AddMonths(76),
                   FuelRemain = 1200,
                   LicenseNum = 275267202,
                   Status = BusStatus.ReadyToGo,
                   TotalTrip = 25790,
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
            listStation = new List<Station>();
            listTrip = new List<Trip>();
            listTrip = new List<Trip>();
            listUser = new List<User>();
        }
    }
}
