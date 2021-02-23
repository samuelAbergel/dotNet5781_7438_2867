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
                throw new DLExeption ("this bus already exist");
            if (bus.LicenseNum.ToString().Length != 7 && bus.LicenseNum.ToString().Length != 8)
                throw new DLExeption($"this id bus not valid {bus.LicenseNum}");
            if (bus.FuelRemain > 1200)
                throw new DLExeption("this fuel is not valid");
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
                throw new DLExeption("this bus dosn't exist");
        }
        public void removeBus(int id)
        {
            //to verify its existence
            if ((DataSource.listBus.FirstOrDefault(p => p.LicenseNum == id) == null))
                throw new DLExeption("this bus dosn't exist");
            DataSource.listBus.RemoveAll(p => p.LicenseNum == id);
        }
        public Bus GetBus(int id)
        {
            //to vrify its existence
            Bus sBus = DataSource.listBus.Find(p => p.LicenseNum == id);
            if (sBus != null)
                return sBus.Clone();// return clone of this bus if existing
            else
                throw new DLExeption("this bus dosn't exist");
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
            if (realBus == null)//and update the changed bus
                throw new DO.DLExeption("this bus dosn't exist");
            if (realBus.FuelRemain < 1200)
                throw new DO.DLExeption("this fuel is too high");
            if (realBus.Status != BusStatus.ReadyToGo)
                throw new DO.DLExeption("you can refuel because the statue");
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
                throw new DLExeption("this bus dosn't exist");
            if (realBus == null)
                throw new DO.DLExeption("this bus dosn't exist");
            if (realBus.Status != BusStatus.ReadyToGo)
                throw new DO.DLExeption("you can't treat because the statue");
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
                throw new DLExeption("this line already exist");
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
            }
            else // else throw an error
                throw new DLExeption("this line dosn't exist");

        }
        public void removeLine(int id)
        {
            //to verify existence
            if ((DataSource.listLine.FirstOrDefault(p => p.Id == id) == null))
                throw new DLExeption("this line dosn't exist");
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
                throw new DLExeption("this line dosn't exist");
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
      //prb

        public bool isLineExisting(Line line)
        {
            var line1 = (from item in DataSource.listLineStation
                       where item.LineId == line.Id
                       select item).FirstOrDefault();
            if (line1 != null)
                return false;
            return true;
        }

        #endregion

        #region station
        public void addStation(Station station)
        {
            //to verify its existence
            if ((DataSource.listStation.FirstOrDefault(p => p.Code == station.Code) != null))
                throw new DLExeption("this station already exist");
            if (station.Name == null)
                throw new DO.DLExeption("this name is not valid");
            if (station.Lattitude == null)
                station.Lattitude = "0";
            if (!double.TryParse(station.Lattitude.ToString(), out double a))
                throw new DLExeption("this lattitude is not valid");
            if (station.Longitude == null)
                station.Longitude = "0";
            if (!double.TryParse(station.Longitude.ToString(), out double b))
                throw new DLExeption("this Longitude is not valid");
            if (int.Parse(station.Lattitude) > 90 || int.Parse(station.Lattitude) < -90)
                throw new DO.DLExeption("this lattitude dosn't valid");
            if (int.Parse(station.Longitude) > 180 || int.Parse(station.Longitude) < -180)
                throw new DO.DLExeption("this Longitude dosn't valid");
            if (station.Code < 0)
                throw new DO.DLExeption("this code is not valid");

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
                throw new DLExeption("this station dosn't exist");
        }
        public void removeStation(int id)
        {
            //to verify its existence
            if ((DataSource.listStation.FirstOrDefault(p => p.Code == id) == null))
                throw new DLExeption("this station dosn't exist");
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
                throw new DLExeption("this station dosn't exist");
        }

        public IEnumerable<Station> searchStation(string item)
        {
            //create ienumerable of station with all station that start with item
            IEnumerable<Station> listStart = from station in DataSource.listStation
                                         where station.Code.ToString().StartsWith(item)
                                         select station;
            //return it if there are linestation like this
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
            //return from item in DataSource.listLine
            //        from stu in item.listOfStationInLine
            //         where stu.Code == station.Code
            //          select item;
            return null;
        }
        public bool isStationExisting(int code)
        {
            //search in data source if there is a station like this
            Station station = (from item in DataSource.listStation
                               where item.Code == code
                               select item).FirstOrDefault();
            if (station != null)
                return false;
            return true;
        }

        #endregion

        #region adjacent station
        public IEnumerable<AdjacentStations> getAllAdjacentStation()
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
                throw new DLExeption("this adjacent station dosn't exist");
        }

        public void addAdjacentStation(int station1,int station2)
        {
            Random rd = new Random();
            //add adj station with this setting 
            DataSource.listAdjacentStations.Add(new AdjacentStations { Distance =rd.Next(100),Time =TimeSpan.FromMinutes(rd.Next(100)),Station1 =station1,Station2 =station2});
        }

        public IEnumerable<Station> GetAdjacentStationsOfStation(Station station)
        {
            //search adj station with code of specific station
            var num = from item in DataSource.listAdjacentStations
                       where station.Code == item.Station1
                       select item.Station2;
            var num1 = from item in DataSource.listAdjacentStations
                       where station.Code == item.Station2
                       select item.Station1;
            //if not existing
            if(num.Count() == 0 && num1.Count() == 0)
            return null;
            //else group in one list
            num = num.Concat(num1);
            //return all
            var lst = from item in DataSource.listStation
                      from item1 in num
                      where item.Code == item1
                      select item;
          
            if (lst.Count() == 0)
                return null;
            return lst.Distinct();
        }
        #endregion

        #region Line station
        public void AddLineStation(LineStation lineStation)
        {
            //to verify its existence
           var lst = (from item in DataSource.listLine
                      from item1 in DataSource.listLineStation
                     where item.Id == lineStation.LineId && item1.Station== lineStation.Station
                     select item1).FirstOrDefault();
            if(lst != null)
                throw new DLExeption("this lineStation already exist");
            //to add in list of linestation
            DataSource.listLineStation.Add(lineStation.Clone());
        }

        public void updateLineStation(LineStation lineStation)
        {
            //to verify its existence 
            LineStation sLine = DataSource.listLineStation.Find(p => p.LineId == lineStation.LineId);
            // if this bus exist we update the bus
            if (sLine != null)
            {
                sLine.Station = lineStation.Station;
                sLine.LineId = lineStation.LineId;
                sLine.LineStationIndex = lineStation.LineStationIndex;
            }
            else //if the bus does not exist, an error is returned 
                throw new DLExeption("this linestation dosn't exist");
        }

        public void removeLineStation(int id)
        {
            //to verify its existence
            if ((DataSource.listLineStation.FirstOrDefault(p => p.LineId == id) == null))
                throw new DLExeption("this linestation dosn't exist");
            DataSource.listLineStation.RemoveAll(p => p.LineId == id);
        }

        public LineStation getLineStation(int id)
        {
            //to vrify its existence
            LineStation sLineStation = DataSource.listLineStation.Find(p => p.LineId == id);
            if (sLineStation != null)
                return sLineStation.Clone();// return clone of this bus if existing
            else
                throw new DLExeption("this linestation dosn't exist");
        }

        public IEnumerable<LineStation> GetLineStationsFromLine(Line line)
        {
            var lst = from item in DataSource.listLineStation
                      where item.LineId == line.Code
                      select item;
            return lst;
        }

        public bool isLineStationExisting(LineStation lineStation)
        {
            LineStation lineStation1 = (from item in DataSource.listLineStation
                                        where item.LineId == lineStation.LineId
                                        select item).FirstOrDefault();
            if (lineStation1 != null)
                return false;
            return true;
        }

        public void removeAllLineStationOfLine(int id)
        {
            foreach (var item in DataSource.listLineStation)
                if (item.LineId == id)
                    DataSource.listLineStation.Remove(item);
        }


        #endregion

        #region implemented just in XML
        public bool getUser(string username)
        {
            throw new DLExeption("this not implement in DLObject");
        }
        public void verif()
        {
            return;
        }

        public void addUser(string name, string password)
        {
            throw new DLExeption("this not implement in DLObject");
        }

        public TimeSpan getTime(Line line)
        {
            return default;
        }

        public void SignIn(string mail)
        {
            throw new NotImplementedException();
        }

        public bool getLogin(string mail, string password)
        {
            throw new NotImplementedException();
        }

        public void addLineTrip(int id)
        {
            throw new NotImplementedException();
        }

        public void updateLineTrip(LineTrip LineTrip)
        {
            throw new NotImplementedException();
        }

        public void removeLineTrip(int id)
        {
            throw new NotImplementedException();
        }

        public LineTrip getLineTrip(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineStation> getAllLineStation()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
