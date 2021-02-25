using DLAPI;
using DO;
using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
            if (bus.TotalTrip > 20000)
                throw new DLExeption("this total trip is not valid");
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
            if (bus.FuelRemain > 1200)
                throw new DLExeption("this fuel is not valid");
            if (bus.TotalTrip > 20000)
                throw new DLExeption("this total trip is not valid");
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
            bus.Status = BusStatus.inTreatment;
            bus.previewTreatmentDate = DateTime.Now;

        }
        public IEnumerable<Bus> searchBus(string item)
        {
            //search bus that start with same item
            IEnumerable<Bus> listStart = from bus in DataSource.listBus
                                         where bus.LicenseNum.ToString().StartsWith(item)
                                         select bus;
           
            if(listStart != null)//if existing return true
            return listStart;
            return null;
        }
        public bool isBusExisting(int liscenceNumber)
        {
            //search if existing
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
            if ((DataSource.listLine.FirstOrDefault(p => p.Code == line.Code) != null))
                throw new DLExeption("this line already exist");
            IEnumerable<LineStation> lst = GetLineStationsFromLine(line);
            line.FirstStation = lst.First().Station.ToString();
            line.LastStation = lst.Last().Station.ToString();
            //if it exist add this line in list of line
            DataSource.listLine.Add(line.Clone());
        }
        public void updateLine(Line line)
        {
            //to verify its existence
            Line sLine = DataSource.listLine.Find(p => p.Code == line.Code);
            // if it exist update all field of the bus
            if (sLine != null)
            {
                sLine.Area = line.Area;
                sLine.Code = line.Code;
                IEnumerable<LineStation> lst = GetLineStationsFromLine(line);
                sLine.FirstStation = lst.First().Station.ToString();
                sLine.LastStation = lst.Last().Station.ToString();
            }
            else // else throw an error
                throw new DLExeption("this line dosn't exist");
           

        }
        public void removeLine(int id)
        {
            //to verify existence
            if ((DataSource.listLine.FirstOrDefault(p => p.Code == id) == null))
                throw new DLExeption("this line dosn't exist");
            //if it exist we remove this bus
            DataSource.listLine.RemoveAll(p => p.Code == id);
        }
        public Line getLine(int id)
        {
            //to verify its existence
            Line sLine = DataSource.listLine.Find(p => p.Code == id);
            if (sLine != null)
                return sLine.Clone();//if it exist return the bus
            else
                throw new DLExeption("this line dosn't exist");
        }

        public IEnumerable<Line> searchLine(string item)
        {
            //search if there is a line that start start with the same item
            IEnumerable<Line> listStart = from line in DataSource.listLine
                                          where line.Code.ToString().StartsWith(item)
                                          select line;
            //return true if existing
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
            //search if there is a line that start start with the same item
            var line1 = (from item in DataSource.listLine
                       where item.Code == line.Code
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
            if (station.Name == string.Empty)
                throw new DO.DLExeption("this name is not valid");
            if (station.Lattitude == null)
                station.Lattitude = "0";
            if (!double.TryParse(station.Lattitude, out double a))
                throw new DLExeption("this lattitude is not valid");
            if (station.Longitude == null)
                station.Longitude = "0";
            if (!double.TryParse(station.Longitude, out double b))
                throw new DLExeption("this Longitude is not valid");
            if (a > 90 || a < -90)
                throw new DO.DLExeption("this lattitude dosn't valid");
            if (b > 180 || b < -180)
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
           IEnumerable<LineStation> linestation = from item in DataSource.listLineStation
                                                  where item.Station == station.Code
                                                  select item;
            if (linestation != null)
                return from item in linestation
                       select getLine(item.LineId);
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
                     where item.Code == lineStation.LineId && item1.Station== lineStation.Station
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
            if ((DataSource.listLineStation.FirstOrDefault(p => p.id == id) == null))
                throw new DLExeption("this linestation dosn't exist");
            var lineStation = (from item in DataSource.listLineStation
                               where item.id == id
                               select item).FirstOrDefault();
            DataSource.listLineStation.Remove(lineStation);
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
            //get all linestation of line 
            var lst = from item in DataSource.listLineStation
                      where item.LineId == line.Code
                      select item;
            return lst;
        }

        public bool isLineStationExisting(LineStation lineStation)
        {
            //search if there is a station with start with the same item
            LineStation lineStation1 = (from item in DataSource.listLineStation
                                        where item.LineId == lineStation.LineId
                                        select item).FirstOrDefault();
            if (lineStation1 != null)
                return false;
            return true;
        }

        public void removeAllLineStationOfLine(int id)
        {
            //remove all line station one after one
            foreach (var item in DataSource.listLineStation.ToList())
                if (item.LineId == id)
                    DataSource.listLineStation.Remove(item);
        }
        public IEnumerable<LineStation> getAllLineStation()
        {
            return from linetrip in DataSource.listLineStation //search line in list of line                                                                    
                   select linetrip.Clone(); //return all line
        }

        #endregion

        #region line trip
        public void addLineTrip(int id)
        {
            //to verify its existence
            if ((DataSource.listLineTrip.FirstOrDefault(p => p.LineId == id) != null))
                throw new DLExeption("this line trip already exist");
            //if it exist add this line in list of line
            DataSource.listLineTrip.Add((new LineTrip { LineId = id,FinishAt = new TimeSpan(22,0,0),StartAt = new TimeSpan(6,0,0),Frequency = new TimeSpan(0,new Random().Next(30),0)}).Clone());
        }

        public void updateLineTrip(LineTrip LineTrip)
        {
            //to verify its existence
            LineTrip sLineTrip = DataSource.listLineTrip.Find(p => p.LineId == LineTrip.LineId);
            // if it exist update all field of the bus
            if (sLineTrip != null)
            {
                sLineTrip.FinishAt = LineTrip.FinishAt;
                sLineTrip.StartAt = LineTrip.StartAt;
                sLineTrip.Frequency = LineTrip.Frequency;
                sLineTrip.LineId = LineTrip.LineId;
            }
            else // else throw an error
                throw new DLExeption("this line trip dosn't exist");
        }

        public void removeLineTrip(int id)
        {
            //to verify existence
            if ((DataSource.listLineTrip.FirstOrDefault(p => p.LineId == id) == null))
                throw new DLExeption("this line trip dosn't exist");
            //if it exist we remove this bus
            DataSource.listLineTrip.RemoveAll(p => p.LineId == id);
        }

        public LineTrip getLineTrip(int id)
        {
            //to verify its existence
            LineTrip sLineTrip = DataSource.listLineTrip.Find(p => p.LineId == id);
            if (sLineTrip != null)
                return sLineTrip.Clone();//if it exist return the bus
            else
                throw new DLExeption("this line trip dosn't exist");
        }
        #endregion

        #region user
        public bool getUser(string username)
        {
            User verif = (from p in DataSource.listUser//verif it existing
                          where p.UserName == username
                          select p).FirstOrDefault();
            if (verif != null)
                return true;
            return false;
        }
        public void addUser(string name, string password)
        {
            //to verify its existence
            if ((DataSource.listUser.FirstOrDefault(p => p.Password == password && p.UserName ==name) != null))
                throw new DLExeption("this user already exist");
            //if it exist add this line in list of line
            DataSource.listUser.Add(new User { UserName = name,Password = password}.Clone());
        }
        public void SignIn(string mail1)
        {
            //verify if existing
            if (getUser(mail1))
                throw new DLExeption("this mail already exist please login");
            //create a password
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            //and send to mail
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("myprojectdotnet10@gmail.com");
                mail.Subject = "test to eyal";
                mail.To.Add(mail1);
                mail.Subject = "receive your password";
                mail.Body = $"your password is {res.ToString()}";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("myprojectdotnet10@gmail.com", "A12345678b");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (DO.DLExeption ex)
            {
                throw new DLExeption(ex.Message);
            }
            //add the user and password to datasource
            addUser(mail1, res.ToString());

        }
        public bool getLogin(string mail, string password)
        {
             User verif = (from p in DataSource.listUser//verif it existing
                            where p.UserName == mail && p.Password == password
                            select p).FirstOrDefault();
            if (verif != null)
                return true;
            return false;
        }
        #endregion

        #region implemented just in XML

        public void verif()
        {
            return;
        }

        public TimeSpan getTime(Line line)
        {
            return default;
        }
        #endregion

    }
}
