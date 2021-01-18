using DLAPI;
using DO;
using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    sealed class DLObject : IDL
    {
        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }// static ctor to ensure instance init is done just before first usage
        DLObject() { } // default => private
        public static DLObject Instance { get => instance; }// The public Instance property to use
        #endregion

        #region bus
        public void addBus(Bus bus)
        {
            //to verify its existence
            if ((DataSource.listBus.FirstOrDefault(p => p.LicenseNum == bus.LicenseNum) != null))
                throw new badIdBusexeption(bus);
            //to add in list of bus
            DataSource.listBus.Add(bus.Clone());
        }
        public void updateBus(Bus bus)
        {
            //to verify its existence 
            Bus sBus = DataSource.listBus.Find(p => p.LicenseNum == bus.LicenseNum);
            // if this bus exist we update the bus
            if (sBus != null)
            {
                sBus.BusOfLine = bus.BusOfLine;
                sBus.LicenseNum = bus.LicenseNum;
                sBus.FromDate = bus.FromDate;
                sBus.FuelRemain = bus.FuelRemain;
                sBus.previewTreatmentDate = bus.previewTreatmentDate;
                sBus.Status = bus.Status;
                sBus.TotalTrip = bus.TotalTrip;
            }
            else //if the bus does not exist, an error is returned 
                throw new badIdBusexeption(bus.LicenseNum);
        }
        public void removeBus(int id)
        {
            //to verify its existence
            if ((DataSource.listBus.FirstOrDefault(p => p.LicenseNum == id) == null))
                throw new badIdBusexeption(id);
            DataSource.listBus.RemoveAll(p => p.LicenseNum == id);
        }
        public Bus GetBus(int id)
        {
            //to vrify its existence
            Bus sBus = DataSource.listBus.Find(p => p.LicenseNum == id);
            if (sBus != null)
                return sBus.Clone();// return clone of this bus if existing
            else
                throw new badIdBusexeption(id);
        }
        public IEnumerable<Bus> GetAllBus()
        {
            return from bus in DataSource.listBus // search all bus in list of bus
                   select bus.Clone();
        }
        public void refuelling(int fuel,Bus bus)
        {
            //to verify its existence
            DO.Bus realBus = (from item in DataSource.listBus
                              where item.LicenseNum == bus.LicenseNum
                              select item).FirstOrDefault();
            //if it doesn't exist throw error
            if (realBus == null)
                throw new Exception("not exist");
            //if it exist we refuelling the bus
            realBus.FuelRemain += fuel;
            bus.FuelRemain = realBus.FuelRemain;
        }
        public void treatment(Bus bus)
        {
            //to verify its existence
            DO.Bus realBus = (from item in DataSource.listBus //in list of bus
                              where item.LicenseNum == bus.LicenseNum // if we find the real bus
                              select item).FirstOrDefault();//select it
            //mif itt doesn't exist throw an error
            if (realBus == null)
                throw new badIdBusexeption(bus);
            // if it exist we do a treatment of the bus
            realBus.Status = BusStatus.inTreatment;
            realBus.previewTreatmentDate = DateTime.Now;

        }
        public IEnumerable<Bus> searchBus(string item)
        {
            IEnumerable<Bus> listStart = from bus in DataSource.listBus
                                         where bus.LicenseNum.ToString().StartsWith(item)
                                         select bus;
           
            if(listStart != null)
            return listStart;
            return null;
        }
        public bool isBusExisting(int liscenceNumber)
        {
            Bus bus = (from item in DataSource.listBus
                       where item.LicenseNum == liscenceNumber
                       select item).FirstOrDefault();
            if (bus != null)
                return false;
            return true;
        }

        #endregion

        #region line
        public void addLine(Line line)
        {
            //to verify its existence
            if ((DataSource.listLine.FirstOrDefault(p => p.Id == line.Id) != null))
                throw new badIdLineexeption(line);
            //if it exist add this line in list of line
            DataSource.listLine.Add(line.Clone());
        }
        public void updateLine(Line line)
        {
            //to verify its existence
            Line sLine = DataSource.listLine.Find(p => p.Id == line.Id);
            // if it exist update all field of the bus
            if (sLine != null)
            {
                sLine.Area = line.Area;
                sLine.Code = line.Code;
                sLine.FirstStation = line.FirstStation;
                sLine.Id = line.Id;
                sLine.LastStation = line.LastStation;
                sLine.listOfStationInLine = line.listOfStationInLine;
            }
            else // else throw an error
                throw new badIdLineexeption(line.Id);

        }
        public void removeLine(int id)
        {
            //to verify existence
            if ((DataSource.listLine.FirstOrDefault(p => p.Id == id) == null))
                throw new badIdLineexeption(id);
            //if it exist we remove this bus
            DataSource.listLine.RemoveAll(p => p.Id == id);
        }
        public Line getLine(int id)
        {
            //to verify its existence
            Line sLine = DataSource.listLine.Find(p => p.Id == id);
            if (sLine != null)
                return sLine.Clone();//if it exist return the bus
            else
                throw new badIdLineexeption(id);
        }

        public IEnumerable<Line> searchLine(string item)
        {
            IEnumerable<Line> listStart = from line in DataSource.listLine
                                          where line.Id.ToString().StartsWith(item)
                                          select line;

            if (listStart != null)
                return listStart;
            return null;
        }

        public IEnumerable<Line> getAllLine()
        {
            return from line in DataSource.listLine //search line in list of line                                                                    
                   select line.Clone(); //return all line
        }
        public IEnumerable<Station> getStationOfLine(Line line)
        {
            return from item in line.listOfStationInLine // search in line list of station
                   select item.Clone();//return this list of station of line
        }

        public bool isLineExisting(Line line)
        {
            var verif = from item in DataSource.listLine
                              where line.Id == item.Id
                              select item;
            if (verif.Count() != 0)
                return false;
            var listStation = from item in DataSource.listLine
                              from item1 in item.listOfStationInLine
                              from item2 in line.listOfStationInLine
                              where item.listOfStationInLine.Count() == line.listOfStationInLine.Count()
                              where item1.Code == item2.Code 
                              select item1;

            if (listStation.Count() == line.listOfStationInLine.Count())
                return false;
            return true;
        }

        #endregion

        #region station
        public void addStation(Station station)
        {
            //to verify its existence
            if ((DataSource.listStation.FirstOrDefault(p => p.Code == station.Code) != null))
                throw new badIDStationexeption(station);
            //if it exist we add this station
            DataSource.listStation.Add(station.Clone());
        }
        public void updateStation(Station station)
        {
            //to verify its existence
            Station sStation = DataSource.listStation.Find(p => p.Code == station.Code);
            //if the station exist update it
            if (sStation != null)
            {
                sStation.Code = station.Code;
                sStation.Lattitude = station.Lattitude;
                sStation.Longitude = station.Longitude;
                sStation.Name = station.Name;
            }
            else //else throw an error
                throw new badIDStationexeption(station.Code);
        }
        public void removeStation(int id)
        {
            //to verify its existence
            if ((DataSource.listStation.FirstOrDefault(p => p.Code == id) == null))
                throw new badIDStationexeption(id);
            //if it exist we remove this station
            DataSource.listStation.RemoveAll(p => p.Code == id);
        }
        public Station getStation(int id)
        {
            //to verify its existence
            Station sStation = DataSource.listStation.Find(p => p.Code == id);
            if (sStation != null)
                return sStation.Clone();//if it exist return this station
            else
                throw new badIDStationexeption(id);
        }

        public IEnumerable<Station> searchStation(string item)
        {
            IEnumerable<Station> listStart = from station in DataSource.listStation
                                         where station.Code.ToString().StartsWith(item)
                                         select station;

            if (listStart != null)
                return listStart;
            return null;
        }

        public IEnumerable<Station> getAllStation()
        {
            return from station in DataSource.listStation // search station in list of station
                   select station.Clone();//select all station
        }

        public IEnumerable<Line> getLineOfStation(Station station)
        {
            return from item in DataSource.listLine
                    from stu in item.listOfStationInLine
                     where stu.Code == station.Code
                      select item;
        }
        public bool isStationExisting(int code)
        {
            Station station = (from item in DataSource.listStation
                               where item.Code == code
                               select item).FirstOrDefault();
            if (station != null)
                return false;
            return true;
        }

        #endregion

        #region adjacent station
        public IEnumerable<AdjacentStations> getAdjacentStation()
        {
            return from item in DataSource.listAdjacentStations //search adjacent station in list
                   select item.Clone(); // select it 
        }

        public void removeAdjacentStation(int id)
        {
            //to verify its existence
            if(DataSource.listAdjacentStations.FirstOrDefault(p => p.Station1 == id) == null)
                throw new ArgumentException("this adjacent station doesn't exist");
            //if it exist remove it
            DataSource.listAdjacentStations.RemoveAll(p => p.Station1 == id);
        }

        public void updateAdjacentStation(AdjacentStations adjacentStations)
        {
            //to verify it existence
            if (DataSource.listAdjacentStations.FirstOrDefault(p => p.Station1 == adjacentStations.Station1) == null)
                throw new ArgumentException("this adjacent station doesn't exist");
            //if it exist update it 
                DataSource.listAdjacentStations.RemoveAll(p => p.Station1 == adjacentStations.Station1);
        }

        public AdjacentStations getAdjacentStations(int id)
        {
            //to verify its existence
            AdjacentStations sStation = DataSource.listAdjacentStations.Find(p => p.Station1 == id);
            if (sStation != null)
                return sStation.Clone(); //return it 
            else
                throw new badIDStationexeption(id);//else throw exeption
        }

        public void addAdjacentStation(AdjacentStations adjacentStations)
        {
            //to verify its existence
            if (DataSource.listAdjacentStations.FirstOrDefault(p => p.Station1 == adjacentStations.Station1) != null)
                throw new ArgumentException("this adjacent station already exist");
            //if it existe add it
            DataSource.listAdjacentStations.Add(adjacentStations.Clone());
        }

        public IEnumerable<Station> GetAdjacentStationsOfStation(Station station)
        {
            var num = from item in DataSource.listAdjacentStations
                       where station.Code == item.Station1
                       select item.Station2;
            var num1 = from item in DataSource.listAdjacentStations
                       where station.Code == item.Station2
                       select item.Station1;

            if(num.Count() == 0 && num1.Count() == 0)
            return null;
            num = num.Concat(num1);
            var lst = from item in DataSource.listStation
                      from item1 in num
                      where item.Code == item1
                      select item;
          
            if (lst.Count() == 0)
                return null;
            return lst.Distinct();
        }
    
        #endregion
    }
}
