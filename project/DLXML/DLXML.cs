using DLAPI;
using DO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DL
{
    sealed class DLXML : IDL
    {
        #region singelton
        static readonly DLXML instance = new DLXML();
        static DLXML() { }// static ctor to ensure instance init is done just before first usage
        DLXML() { } // default => private
        public static DLXML Instance { get => instance; }// The public Instance property to use
        #endregion
        static int id1 = 0;
        #region DS XML Files

        string BusPath = @"BusXml.xml"; //XMLSerializer
        string LinePath = @"LineXml.xml"; //XElement
        string StationPath = @"StationXml.xml"; //XElement
        string AdjacentStationPath = @"AdjacentStationXml.xml"; //XMLSerializer
        string UserPath = @"UsersXml.xml";
        string LineStationPath = @"LineStationXml.xml";
        string LineTripPath = @"LineTripXml.xml";

        #endregion

        #region adjacent station
        public void addAdjacentStation(int station1, int station2)
        {
            XElement AdjacentStationRootElem = XMLTools.LoadListFromXMLElement(AdjacentStationPath);//load the file xml
            Random rd = new Random();
            int distance = rd.Next(100);//create ramdom distance
            TimeSpan time = TimeSpan.FromMinutes(rd.Next(100));//create ransom time
            XElement adjacentStation1 = (from p in AdjacentStationRootElem.Elements()
                                         where int.Parse(p.Element("Station1").Value) == station1 && int.Parse(p.Element("Station2").Value) == station2
                                         select p).FirstOrDefault();
            //creat it
            if (adjacentStation1 == null)
            {
                XElement adjacentStation = new XElement("AdjacentStations",
                                                              new XElement("Station1", station1.ToString()),
                                                              new XElement("Station2", station2.ToString()),
                                                              new XElement("Distance", distance.ToString()),
                                                              new XElement("Time", time.ToString()));
                AdjacentStationRootElem.Add(adjacentStation);//add it

                XMLTools.SaveListToXMLElement(AdjacentStationRootElem, AdjacentStationPath);//and save it
            }
        }
        public IEnumerable<AdjacentStations> getAllAdjacentStation()
        {
            XElement AdjacentStationRootElem = XMLTools.LoadListFromXMLElement(AdjacentStationPath);//load xml file


            return from p in AdjacentStationRootElem.Elements() //return all adjacent station
                   select new AdjacentStations()
                   {
                       Distance = Int32.Parse(p.Element("Distance").Value),
                       Station1 = Int32.Parse(p.Element("Station1").Value),
                       Station2 = Int32.Parse(p.Element("Station2").Value),
                       Time = TimeSpan.ParseExact(p.Element("Time").Value, "hh\\:mm\\:ss", CultureInfo.InvariantCulture)
                   };
        }
        public AdjacentStations getAdjacentStations(int id)
        {
            XElement AdjacentStationRootElem = XMLTools.LoadListFromXMLElement(AdjacentStationPath);//load file xml

            AdjacentStations adjacentStations = (from p in AdjacentStationRootElem.Elements()//get first station with this id
                                                 where int.Parse(p.Element("Station1").Value) == id
                                                 select new AdjacentStations()
                                                 {
                                                     Distance = Int32.Parse(p.Element("Distance").Value),
                                                     Station1 = Int32.Parse(p.Element("Station1").Value),
                                                     Station2 = Int32.Parse(p.Element("Station2").Value),
                                                     Time = TimeSpan.ParseExact(p.Element("Time").Value, "hh\\:mm\\:ss", CultureInfo.InvariantCulture)
                                                 }
                        ).FirstOrDefault();

            if (adjacentStations == null)//and return it
                throw new DO.DLExeption("this adjacent station dosn't exist");
            return adjacentStations;
        }
        public IEnumerable<Station> GetAdjacentStationsOfStation(Station station)
        {
            XElement AdjacentStationRootElem = XMLTools.LoadListFromXMLElement(AdjacentStationPath);//load file xml
            XElement StationRootElem = XMLTools.LoadListFromXMLElement(StationPath);

            var num = from item in AdjacentStationRootElem.Elements()//search all adj station with this code of station
                      where station.Code == int.Parse(item.Element("Station1").Value)
                      select int.Parse(item.Element("Station2").Value);

            var num1 = from item in AdjacentStationRootElem.Elements()
                       where station.Code == int.Parse(item.Element("Station2").Value)
                       select int.Parse(item.Element("Station1").Value);

            num = num.Concat(num1);//group in one list
            num = num.Distinct();
            var lst = from item in num//get al station with code 
                      from item1 in StationRootElem.Elements()
                      where int.Parse(item1.Element("Code").Value) == item
                      select new Station
                      {
                          Code = Int32.Parse(item1.Element("Code").Value),
                          Lattitude = item1.Element("Lattitude").Value,
                          Longitude = item1.Element("Longitude").Value,
                          Name = item1.Element("Name").Value,
                      };

            return lst;
        }
        public void removeAdjacentStation(int id)
        {
            XElement AdjacentStationRootElem = XMLTools.LoadListFromXMLElement(AdjacentStationPath);//load xml file 

            XElement adjacentstation = (from p in AdjacentStationRootElem.Elements()//search thi sstation
                                        where int.Parse(p.Element("Station1").Value) == id
                                        select p).FirstOrDefault();

            if (adjacentstation != null)//if it existind
            {
                adjacentstation.Remove(); //remove it

                XMLTools.SaveListToXMLElement(AdjacentStationRootElem, AdjacentStationPath);//and save it
            }
            else
                throw new DO.DLExeption("this adjacent station dosn't exist");
        }
        public void updateAdjacentStation(AdjacentStations adjacentStations)
        {
            XElement AdjacentStationRootElem = XMLTools.LoadListFromXMLElement(AdjacentStationPath);//load xml file

            XElement adjacentstation1 = (from p in AdjacentStationRootElem.Elements()//search this station
                                         where int.Parse(p.Element("Station1").Value) == adjacentStations.Station1
                                         select p).FirstOrDefault();

            if (adjacentstation1 != null)//if existing update all fiels of adj station
            {
                adjacentstation1.Element("Station1").Value = adjacentStations.Station1.ToString();
                adjacentstation1.Element("Station2").Value = adjacentStations.Station2.ToString();
                adjacentstation1.Element("Distance").Value = adjacentStations.Distance.ToString();
                adjacentstation1.Element("Time").Value = adjacentStations.Time.ToString();

                XMLTools.SaveListToXMLElement(AdjacentStationRootElem, AdjacentStationPath);//and save it
            }
            else
                throw new DO.DLExeption("this adjacent station dosn't exist");
        }
        #endregion

        #region bus
        public void addBus(Bus bus)
        {
            if (bus.LicenseNum.ToString().Length != 7 && bus.LicenseNum.ToString().Length != 8)
                throw new DLExeption($"this id bus not valid {bus.LicenseNum}");
            if (bus.FuelRemain > 1200)
                throw new DLExeption("this fuel is not valid");
            if (bus.TotalTrip > 20000)
                throw new DLExeption("this total trip is not valid");
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);//load xml file

            XElement bus1 = (from p in BusRootElem.Elements()//search it
                             where int.Parse(p.Element("LicenseNum").Value) == bus.LicenseNum
                             select p).FirstOrDefault();

            if (bus1 != null)
                throw new DO.DLExeption("this bus already exist");
            //create it
            XElement busElem = new XElement("Bus", new XElement("LicenseNum", bus.LicenseNum.ToString()),
                                  new XElement("FromDate", bus.FromDate.ToShortDateString()),
                                  new XElement("TotalTrip", bus.TotalTrip.ToString()),
                                  new XElement("FuelRemain", bus.FuelRemain.ToString()),
                                  new XElement("previewTreatmentDate", bus.previewTreatmentDate.ToShortDateString()),
                                  new XElement("BusOfLine", bus.BusOfLine.ToString()),
                                  new XElement("Status", bus.Status.ToString()));

            BusRootElem.Add(busElem);//add to the file

            XMLTools.SaveListToXMLElement(BusRootElem, BusPath);//and save it
        }
        public IEnumerable<Bus> GetAllBus()
        {
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);//load xml file

            return (from p in BusRootElem.Elements()//return all bus of file
                    select new Bus()
                    {
                        BusOfLine = Int32.Parse(p.Element("BusOfLine").Value),
                        FromDate = DateTime.Parse(p.Element("FromDate").Value),
                        FuelRemain = double.Parse(p.Element("FuelRemain").Value, CultureInfo.InvariantCulture),
                        LicenseNum = Int32.Parse(p.Element("LicenseNum").Value),
                        previewTreatmentDate = DateTime.Parse(p.Element("previewTreatmentDate").Value),
                        Status = (BusStatus)Enum.Parse(typeof(BusStatus), p.Element("Status").Value),
                        TotalTrip = double.Parse(p.Element("TotalTrip").Value, CultureInfo.InvariantCulture),
                    }
                   );
        }
        public Bus GetBus(int id)
        {
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);//load xml file

            Bus bus = (from p in BusRootElem.Elements()//search it in file
                       where int.Parse(p.Element("LicenseNum").Value) == id
                       select new Bus()
                       {
                           BusOfLine = Int32.Parse(p.Element("BusOfLine").Value),
                           FromDate = DateTime.Parse(p.Element("FromDate").Value),
                           FuelRemain = double.Parse(p.Element("FuelRemain").Value, CultureInfo.InvariantCulture),
                           LicenseNum = Int32.Parse(p.Element("LicenseNum").Value),
                           previewTreatmentDate = DateTime.Parse(p.Element("previewTreatmentDate").Value),
                           Status = (BusStatus)Enum.Parse(typeof(BusStatus), p.Element("Status").Value),
                           TotalTrip = double.Parse(p.Element("TotalTrip").Value, CultureInfo.InvariantCulture),
                       }
                        ).FirstOrDefault();

            if (bus == null)//and return it if existing
                throw new DO.DLExeption("this bus dosn't exist");
            return bus;
        }
        public void refuelling(int fuel, Bus bus)
        {
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);//load xml file

            Bus realBus = (from p in BusRootElem.Elements()//search the bus
                           where int.Parse(p.Element("LicenseNum").Value) == bus.LicenseNum
                           select new Bus()
                           {
                               BusOfLine = Int32.Parse(p.Element("BusOfLine").Value),
                               FromDate = DateTime.Parse(p.Element("FromDate").Value),
                               FuelRemain = double.Parse(p.Element("FuelRemain").Value, CultureInfo.InvariantCulture) + fuel,//add the fuel
                               LicenseNum = Int32.Parse(p.Element("LicenseNum").Value),
                               previewTreatmentDate = DateTime.Parse(p.Element("previewTreatmentDate").Value),
                               Status = (BusStatus)Enum.Parse(typeof(BusStatus), p.Element("Status").Value),
                               TotalTrip = double.Parse(p.Element("TotalTrip").Value, CultureInfo.InvariantCulture),
                           }
                        ).FirstOrDefault();

            if (realBus == null)//and update the changed bus
                throw new DO.DLExeption("this bus dosn't exist");
            if (realBus.Status != BusStatus.ReadyToGo)
                throw new DO.DLExeption("you can refuel because the statue");
            updateBus(realBus);
        }
        public void removeBus(int id)
        {
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);//load xml file

            XElement bus = (from p in BusRootElem.Elements()//search the bus
                            where int.Parse(p.Element("LicenseNum").Value) == id
                            select p).FirstOrDefault();

            if (bus != null)//and remove it if existing
            {
                bus.Remove();

                XMLTools.SaveListToXMLElement(BusRootElem, BusPath);
            }
            else
                throw new DO.DLExeption("this bus dosn't exist");
        }
        public IEnumerable<Bus> searchBus(string item)
        {
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);//load xml file
            IEnumerable<Bus> listStart = (from p in BusRootElem.Elements()//search all bus that liscence num start with this item
                                          where p.Element("LicenseNum").Value.ToString().StartsWith(item)
                                          select new Bus()
                                          {
                                              BusOfLine = Int32.Parse(p.Element("BusOfLine").Value),
                                              FromDate = DateTime.Parse(p.Element("FromDate").Value),
                                              FuelRemain = double.Parse(p.Element("FuelRemain").Value, CultureInfo.InvariantCulture),
                                              LicenseNum = Int32.Parse(p.Element("LicenseNum").Value),
                                              previewTreatmentDate = DateTime.Parse(p.Element("previewTreatmentDate").Value),
                                              Status = (BusStatus)Enum.Parse(typeof(BusStatus), p.Element("Status").Value),
                                              TotalTrip = double.Parse(p.Element("TotalTrip").Value, CultureInfo.InvariantCulture),
                                          }
                                  );

            if (listStart != null)//and return all
                return listStart;
            throw new DO.DLExeption("there is no such bus"); ;
        }
        public void treatment(Bus bus)
        {
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);//load xml file

            Bus realBus = (from p in BusRootElem.Elements()//search this bus 
                           where int.Parse(p.Element("LicenseNum").Value) == bus.LicenseNum
                           select new Bus()
                           {
                               BusOfLine = Int32.Parse(p.Element("BusOfLine").Value),
                               FromDate = DateTime.Parse(p.Element("FromDate").Value),
                               FuelRemain = double.Parse(p.Element("FuelRemain").Value, CultureInfo.InvariantCulture),
                               LicenseNum = Int32.Parse(p.Element("LicenseNum").Value),
                               previewTreatmentDate = DateTime.Parse(p.Element("previewTreatmentDate").Value),
                               Status = (BusStatus)Enum.Parse(typeof(BusStatus), p.Element("Status").Value),
                               TotalTrip = 0,
                           }
                        ).FirstOrDefault();
            if (realBus == null)
                throw new DO.DLExeption("this bus dosn't exist");
            if (realBus.Status != BusStatus.ReadyToGo)
                throw new DO.DLExeption("you can't treat because the statue");
            // realBus.Status = BusStatus.inTreatment;
            realBus.previewTreatmentDate = DateTime.Now;//chang ethe date of treatment
            updateBus(realBus);//and update it
        }
        public void updateBus(Bus bus)
        {
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);//load xml file

            XElement bus1 = (from p in BusRootElem.Elements()//search it
                             where int.Parse(p.Element("LicenseNum").Value) == bus.LicenseNum
                             select p).FirstOrDefault();

            if (bus.FuelRemain > 1200)
                throw new DLExeption("this fuel is not valid");
            if (bus.TotalTrip > 20000)
                throw new DLExeption("this total trip is not valid");

            if (bus1 != null)//and update all field
            {
                bus1.Element("LicenseNum").Value = bus.LicenseNum.ToString();
                bus1.Element("FromDate").Value = bus.FromDate.ToShortDateString();
                bus1.Element("TotalTrip").Value = bus.TotalTrip.ToString();
                bus1.Element("FuelRemain").Value = bus.FuelRemain.ToString();
                bus1.Element("previewTreatmentDate").Value = bus.previewTreatmentDate.ToShortDateString();
                bus1.Element("BusOfLine").Value = bus.BusOfLine.ToString();
                bus1.Element("Status").Value = bus.Status.ToString();

                XMLTools.SaveListToXMLElement(BusRootElem, BusPath);//and save it
            }
            else
                throw new DO.DLExeption("this bus dosn't exist");
        }
        public bool isBusExisting(int liscenceNumber)
        {
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);//load xml file
            Bus busVerif = (from p in BusRootElem.Elements()//search it
                            where int.Parse(p.Element("LicenseNum").Value) == liscenceNumber
                            select new Bus()
                            {
                                BusOfLine = Int32.Parse(p.Element("BusOfLine").Value),
                                FromDate = DateTime.Parse(p.Element("FromDate").Value),
                                FuelRemain = double.Parse(p.Element("FuelRemain").Value, CultureInfo.InvariantCulture),
                                LicenseNum = Int32.Parse(p.Element("LicenseNum").Value),
                                previewTreatmentDate = DateTime.Parse(p.Element("previewTreatmentDate").Value),
                                Status = (BusStatus)Enum.Parse(typeof(BusStatus), p.Element("Status").Value),
                                TotalTrip = double.Parse(p.Element("TotalTrip").Value, CultureInfo.InvariantCulture),
                            }
                        ).FirstOrDefault();
            if (busVerif != null)//return true if it not existing
                return false;
            throw new DO.DLExeption("this bus dosn't exist"); ;
        }
        #endregion

        #region line
        public void addLine(Line line)
        {
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);//load xml file

            XElement line1 = (from p in LineRootElem.Elements()//search it
                              where int.Parse(p.Element("Code").Value) == line.Id
                              select p).FirstOrDefault();

            if (line1 != null)
                throw new DO.DLExeption("this line already exist");
            IEnumerable<LineStation> lst = GetLineStationsFromLine(line);
            line.FirstStation = lst.First().Station.ToString();
            line.LastStation = lst.Last().Station.ToString();
            //create it
            XElement lineElem = new XElement("Line", new XElement("Id", line.Id.ToString()),
                                  new XElement("Code", line.Code.ToString()),
                                  new XElement("Area", line.Area.ToString()),
                                  new XElement("FirstStation", line.FirstStation),
                                  new XElement("LastStation", line.LastStation)

                                            );
            //add in file
            LineRootElem.Add(lineElem);
            //and save it
            XMLTools.SaveListToXMLElement(LineRootElem, LinePath);
        }
        public IEnumerable<Line> getAllLine()
        {
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);//load xml file

            return (from p in LineRootElem.Elements()//return all line of file
                    select new Line()
                    {
                        Id = Int32.Parse(p.Element("Id").Value),
                        Area = (Areas)Enum.Parse(typeof(Areas), p.Element("Area").Value),
                        Code = Int32.Parse(p.Element("Code").Value),
                        FirstStation = p.Element("FirstStation").Value,
                        LastStation = p.Element("LastStation").Value,
                    }
                   );
        }
        public Line getLine(int id)
        {
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);//load xml file

            Line line = (from p in LineRootElem.Elements()//select the first line with this id
                         where int.Parse(p.Element("Code").Value) == id
                         select new Line()
                         {
                             Id = Int32.Parse(p.Element("Id").Value),
                             Area = (Areas)Enum.Parse(typeof(Areas), p.Element("Area").Value),
                             Code = Int32.Parse(p.Element("Code").Value),
                             FirstStation = p.Element("FirstStation").Value,
                             LastStation = p.Element("LastStation").Value,
                         }
                        ).FirstOrDefault();

            if (line == null)//and return it
                throw new DO.DLExeption("this line dosn't exist");
            return line;
        }
        public bool isLineExisting(Line line)
        {
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);//load xml file
            XElement LineStationRootElem = XMLTools.LoadListFromXMLElement(LineStationPath);//load xml file

            var lineVerif = (from p in LineRootElem.Elements()//verif if this line exist
                             where int.Parse(p.Element("Code").Value) == line.Code
                             select new Line()
                             {
                                 Id = Int32.Parse(p.Element("Id").Value),
                                 Area = (Areas)Enum.Parse(typeof(Areas), p.Element("Area").Value),
                                 Code = Int32.Parse(p.Element("Code").Value),
                                 FirstStation = p.Element("FirstStation").Value,
                                 LastStation = p.Element("LastStation").Value,

                             }
                        ).FirstOrDefault();
            if (lineVerif != null)
                return false;
            return true;
        }
        public void removeLine(int id)
        {
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);//load xml file
            XElement LineStationRootElem = XMLTools.LoadListFromXMLElement(LineStationPath);//load xml file


            XElement line = (from p in LineRootElem.Elements()//search this line
                             where int.Parse(p.Element("Id").Value) == id
                             select p).FirstOrDefault();
            var linestations = from p in LineStationRootElem.Elements()
                               where int.Parse(p.Element("LineId").Value) == id
                               select p;
            if (line != null)
            {
                line.Remove(); //and remove it
                linestations.Remove();

                XMLTools.SaveListToXMLElement(LineRootElem, LinePath);
                XMLTools.SaveListToXMLElement(LineStationRootElem, LineStationPath);

            }
            else
                throw new DO.DLExeption("this line dosn't exist");
        }
        public IEnumerable<Line> searchLine(string item)
        {
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);//load xml file
            IEnumerable<Line> listStart = (from p in LineRootElem.Elements()//search all line thant start with item
                                           where p.Element("Id").Value.ToString().StartsWith(item)
                                           select new Line()
                                           {
                                               Id = Int32.Parse(p.Element("Id").Value),
                                               Area = (Areas)Enum.Parse(typeof(Areas), p.Element("Area").Value),
                                               Code = Int32.Parse(p.Element("Code").Value),
                                               FirstStation = p.Element("FirstStation").Value,
                                               LastStation = p.Element("LastStation").Value,

                                           }
                                  );

            if (listStart != null)//and return it
                return listStart;
            throw new DO.DLExeption("there is no line like that"); ;
        }
        public void updateLine(Line line)
        {
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);//load xml file

            XElement line1 = (from p in LineRootElem.Elements()//search this line
                              where int.Parse(p.Element("Id").Value) == line.Id
                              select p).FirstOrDefault();

            IEnumerable<LineStation> lst = GetLineStationsFromLine(line);
            line.FirstStation = lst.First().Station.ToString();
            line.LastStation = lst.Last().Station.ToString();
            if (line1 != null)// and update all the field
            {
                line1.Element("Id").Value = line.Id.ToString();
                line1.Element("Code").Value = line.Code.ToString();
                line1.Element("Area").Value = line.Area.ToString();
                line1.Element("FirstStation").Value = line.FirstStation;
                line1.Element("LastStation").Value = line.LastStation;

                XMLTools.SaveListToXMLElement(LineRootElem, LinePath);//and save it
            }
            else
                throw new DO.DLExeption("this line dosn't exist");
        }
        #endregion

        #region station
        public void addStation(Station station)
        {
            XElement StationRootElem = XMLTools.LoadListFromXMLElement(StationPath);//load xml file

            XElement station1 = (from p in StationRootElem.Elements()//search if already existing
                                 where int.Parse(p.Element("Code").Value) == station.Code
                                 select p).FirstOrDefault();
            if (station1 != null)
                throw new DO.DLExeption("this station already exist");
            if (station.Name == string.Empty)
                throw new DO.DLExeption("this name is not valid");
            if (station.Lattitude == null)
                station.Lattitude = "0";
            if (double.TryParse(station.Lattitude.ToString(), out double a))
                throw new DLExeption("this lattitude is not valid");
            if (station.Longitude == null)
                station.Longitude = "0";
            if (double.TryParse(station.Longitude.ToString(), out double b))
                throw new DLExeption("this Longitude is not valid");
            if (a > 90 || a < -90)
                throw new DO.DLExeption("this lattitude dosn't valid");
            if (b > 180 || b < -180)
                throw new DO.DLExeption("this Longitude dosn't valid");
            if (station.Code < 0)
                throw new DO.DLExeption("this code is not valid");

            // create it
            XElement stationElem = new XElement("Station", new XElement("Code", station.Code.ToString()),
                                  new XElement("Name", station.Name),
                                  new XElement("Longitude", station.Longitude.ToString().Replace(",", ".")),
                                  new XElement("Lattitude", station.Lattitude.ToString().Replace(",", ".")));
            //add in the file
            StationRootElem.Add(stationElem);

            XMLTools.SaveListToXMLElement(StationRootElem, StationPath);//and save it
        }
        public IEnumerable<Station> getAllStation()
        {
            XElement StationRootElem = XMLTools.LoadListFromXMLElement(StationPath);//load xml file

            return (from p in StationRootElem.Elements()//return all station from the file
                    select new Station()
                    {
                        Code = Int32.Parse(p.Element("Code").Value),
                        Lattitude = p.Element("Lattitude").Value,
                        Longitude = p.Element("Longitude").Value,
                        Name = p.Element("Name").Value,
                    }
                   );
        }
        public IEnumerable<Line> getLineOfStation(Station station)
        {
            XElement LineStationRootElem = XMLTools.LoadListFromXMLElement(LineStationPath);//load xml file
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);//load xml file

            var lst = from item in LineStationRootElem.Elements()//search all line station with the same code
                      where int.Parse(item.Element("Station").Value) == station.Code
                      select item;
            if (lst == null)
                throw new DO.DLExeption("there is not line station in this station");
            IEnumerable<Line> lst1 = from item in lst//and get all
                                     from item1 in LineRootElem.Elements()
                                     where item.Element("LineId").Value.ToString() == item1.Element("Code").Value.ToString()
                                     select new Line
                                     {
                                         Id = Int32.Parse(item1.Element("Id").Value),
                                         Area = (Areas)Enum.Parse(typeof(Areas), item1.Element("Area").Value),
                                         Code = Int32.Parse(item1.Element("Code").Value),
                                         FirstStation = item1.Element("FirstStation").Value,
                                         LastStation = item1.Element("LastStation").Value,
                                     };

            return lst1;

        }
        public Station getStation(int id)
        {
            XElement StationRootElem = XMLTools.LoadListFromXMLElement(StationPath);//load xml file

            Station station = (from p in StationRootElem.Elements()//search it
                               where int.Parse(p.Element("Code").Value) == id
                               select new Station()
                               {
                                   Code = Int32.Parse(p.Element("Code").Value),
                                   Lattitude = p.Element("Lattitude").Value,
                                   Longitude = p.Element("Longitude").Value,
                                   Name = p.Element("Name").Value,
                               }
                        ).FirstOrDefault();

            if (station == null)//and return it
                throw new DO.DLExeption("this station dosn't exist");
            return station;
        }
        public void removeStation(int id)
        {
            XElement StationRootElem = XMLTools.LoadListFromXMLElement(StationPath);//load xml file

            XElement station = (from p in StationRootElem.Elements()//search it
                                where int.Parse(p.Element("Code").Value) == id
                                select p).FirstOrDefault();

            if (station != null)
            {
                station.Remove(); //and remove it

                XMLTools.SaveListToXMLElement(StationRootElem, StationPath);
            }
            else
                throw new DO.DLExeption("this station dosn't exist");
        }
        public IEnumerable<Station> searchStation(string item)
        {

            XElement StationRootElem = XMLTools.LoadListFromXMLElement(StationPath);//load xml file

            IEnumerable<Station> listStation = (from p in StationRootElem.Elements()//search all station that start with item
                                                where p.Element("Code").Value.ToString().StartsWith(item)
                                                select new Station()
                                                {
                                                    Code = Int32.Parse(p.Element("Code").Value),
                                                    Lattitude = p.Element("Lattitude").Value,
                                                    Longitude = p.Element("Longitude").Value,
                                                    Name = p.Element("Name").Value,
                                                }
                   );
            if (listStation != null)
                return listStation;//and return it
            throw new DO.DLExeption("there is no station like this");
        }
        public void updateStation(Station station)
        {
            XElement StationRootElem = XMLTools.LoadListFromXMLElement(StationPath);//load xml file

            XElement station1 = (from p in StationRootElem.Elements()//search it
                                 where int.Parse(p.Element("Code").Value) == station.Code
                                 select p).FirstOrDefault();

            if (station1 != null)//and update all file
            {
                station1.Element("Code").Value = station.Code.ToString();
                station1.Element("Name").Value = station.Name;
                station1.Element("Lattitude").Value = station.Lattitude.ToString();
                station1.Element("Longitude").Value = station.Longitude.ToString();

                XMLTools.SaveListToXMLElement(StationRootElem, StationPath);//and save it
            }
            else
                throw new DO.DLExeption("this station dosn't exist");
        }
        public bool isStationExisting(int code)
        {
            XElement StationRootElem = XMLTools.LoadListFromXMLElement(StationPath);//load xml file

            Station stationVerif = (from p in StationRootElem.Elements()//search if it existing
                                    where int.Parse(p.Element("Code").Value) == code
                                    select new Station()
                                    {
                                        Code = Int32.Parse(p.Element("Code").Value),
                                        Lattitude = p.Element("Lattitude").Value,
                                        Longitude = p.Element("Longitude").Value,
                                        Name = p.Element("Name").Value.ToString(),
                                    }
                        ).FirstOrDefault();
            if (stationVerif != null)//and return it
                return false;
            return true;
        }
        #endregion

        #region user
        public bool getUser(string username)
        {
            XElement UserRootElem = XMLTools.LoadListFromXMLElement(UserPath);//load xml file

            User verif = (from p in UserRootElem.Elements()//verif it existing
                          where p.Element("UserName").Value == username
                          select new User
                          {
                              Password = p.Element("Password").Value,
                              UserName = p.Element("UserName").Value,
                          }).FirstOrDefault();
            if (verif != null)
                return true;
            return false;

        }

        public bool getLogin(string mail, string password)
        {
            XElement UserRootElem = XMLTools.LoadListFromXMLElement(UserPath);//load xml file

            User verif = (from p in UserRootElem.Elements()//verif it existing
                          where p.Element("UserName").Value == mail && p.Element("Password").Value == password
                          select new User
                          {
                              Password = p.Element("Password").Value,
                              UserName = p.Element("UserName").Value,
                          }).FirstOrDefault();
            if (verif != null)
                return true;
            return false;
        }

        public void addUser(string name, string password)
        {
            XElement UserRootElem = XMLTools.LoadListFromXMLElement(UserPath);//load xml file

            XElement userElem = new XElement("User", new XElement("UserName", name), new XElement("Password", password));
            UserRootElem.Add(userElem);
            XMLTools.SaveListToXMLElement(UserRootElem, UserPath);
        }

        public void SignIn(string mail1)
        {
            if (getUser(mail1))
                throw new DLExeption("this mail already exist please login");

            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
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

            addUser(mail1, res.ToString());
        }
        #endregion

        #region line station
        public void AddLineStation(LineStation lineStation)
        {
            if (lineStation == null)
            {
                throw new DO.DLExeption("this line station is null");
            }
            XElement LineStationRootElem = XMLTools.LoadListFromXMLElement(LineStationPath);//load xml file

            XElement linestation1 = (from p in LineStationRootElem.Elements()
                                     where int.Parse(p.Element("Station").Value) == lineStation.Station && int.Parse(p.Element("LineId").Value) == lineStation.LineId
                                     select p).FirstOrDefault();
            if (linestation1 != null)
                throw new DO.DLExeption("this line station already exist");
            if (linestation1 != null)
            {
                LineStationRootElem.Add(linestation1);
                XMLTools.SaveListToXMLElement(LineStationRootElem, LineStationPath);
                return;
            }
            //else create it and add and save
            XElement linestationElem = new XElement("LineStation",
                                  new XElement("id",id1++.ToString()),
                                  new XElement("LineId", lineStation.LineId.ToString()),
                                  new XElement("Station", lineStation.Station.ToString()),
                                  new XElement("LineStationIndex", lineStation.LineStationIndex.ToString()));

            LineStationRootElem.Add(linestationElem);

            XMLTools.SaveListToXMLElement(LineStationRootElem, LineStationPath);
        }
        public void updateLineStation(LineStation lineStation)
        {
            XElement LineStationRootElem = XMLTools.LoadListFromXMLElement(LineStationPath);//load xml file

            XElement linestation1 = (from p in LineStationRootElem.Elements()//search it
                                     where int.Parse(p.Element("Station").Value) == lineStation.Station && int.Parse(p.Element("LineId").Value) == lineStation.LineId
                                     select p).FirstOrDefault();

            if (linestation1 != null)//and update all field
            {
                linestation1.Element("Station").Value = lineStation.Station.ToString();
                linestation1.Element("LineId").Value = lineStation.LineId.ToString();
                linestation1.Element("LineStationIndex").Value = lineStation.LineStationIndex.ToString();

                XMLTools.SaveListToXMLElement(LineStationRootElem, LineStationPath);
                //and save the file
            }
            else
                throw new DO.DLExeption("this line station dosn't exist");
        }
        public void removeLineStation(int id)
        {
            XElement LineStationRootElem = XMLTools.LoadListFromXMLElement(LineStationPath);//load xml file

            var linestation = (from p in LineStationRootElem.Elements()//search it
                               where int.Parse(p.Element("Station").Value) == id
                               select p);

            if (linestation != null)
            {
                linestation.Remove();
                XMLTools.SaveListToXMLElement(LineStationRootElem, LineStationPath);
            }
            else
                throw new DO.DLExeption("this line station dosn't exist");
        }
        public LineStation getLineStation(int id)
        {
            XElement LineStationRootElem = XMLTools.LoadListFromXMLElement(LineStationPath);//load xml file

            LineStation linestation = (from p in LineStationRootElem.Elements()//and search it
                                       where int.Parse(p.Element("Code").Value) == id
                                       select new LineStation()
                                       {
                                           id= Int32.Parse(p.Element("id").Value),
                                           LineId = Int32.Parse(p.Element("LineId").Value),
                                           Station = Int32.Parse(p.Element("Station").Value),
                                           LineStationIndex = Int32.Parse(p.Element("LineStationIndex").Value),
                                       }
                        ).FirstOrDefault();

            if (linestation == null)//and remove it
                throw new DO.DLExeption("this line station dosn't exist");
            return linestation;
        }
        public IEnumerable<LineStation> getAllLineStation()
        {
            XElement LineStationRootElem = XMLTools.LoadListFromXMLElement(LineStationPath);//load xml file

            return from p in LineStationRootElem.Elements()//and search it
                   select new LineStation()
                   {
                       id = Int32.Parse(p.Element("id").Value),
                       LineId = Int32.Parse(p.Element("LineId").Value),
                       Station = Int32.Parse(p.Element("Station").Value),
                       LineStationIndex = Int32.Parse(p.Element("LineStationIndex").Value),
                   };
           
        }
        public IEnumerable<LineStation> GetLineStationsFromLine(Line line)
        {
            XElement LineStationRootElem = XMLTools.LoadListFromXMLElement(LineStationPath);//load xml file

            return from p in LineStationRootElem.Elements()//and get all stationfrom file
                   where int.Parse(p.Element("LineId").Value) == line.Code
                   select new LineStation
                   {
                       id= Int32.Parse(p.Element("id").Value),
                       LineId = Int32.Parse(p.Element("LineId").Value),
                       Station = Int32.Parse(p.Element("Station").Value),
                       LineStationIndex = Int32.Parse(p.Element("LineStationIndex").Value),
                   };
        }
        public bool isLineStationExisting(LineStation lineStation)
        {
            XElement LineStationRootElem = XMLTools.LoadListFromXMLElement(LineStationPath);//load xml file
            LineStation linestationVerif = (from p in LineStationRootElem.Elements()//search it
                                            where int.Parse(p.Element("LineId").Value) == lineStation.LineId && int.Parse(p.Element("Station").Value) == lineStation.Station
                                            select new LineStation()
                                            {
                                                id = Int32.Parse(p.Element("id").Value),
                                                LineId = Int32.Parse(p.Element("LineId").Value),
                                                Station = Int32.Parse(p.Element("Station").Value),
                                                LineStationIndex = Int32.Parse(p.Element("LineStationIndex").Value),
                                            }
                       ).FirstOrDefault();
            if (linestationVerif != null)//and return if existing 
                return false;
            return true;

        }
        public void removeAllLineStationOfLine(int id)
        {
            XElement LineStationRootElem = XMLTools.LoadListFromXMLElement(LineStationPath);//load xml file
            var lst = from item in LineStationRootElem.Elements()//put all line station in ienumerable
                      where int.Parse(item.Element("LineId").Value) == id
                      select item;
            lst.Remove();//and remove from file and save
            XMLTools.SaveListToXMLElement(LineStationRootElem, LineStationPath);
        }
        /// <summary>
        /// checks if all line stations are deleted after deleting the line due to a bug where if the user turns off the program before adding a line line stations were added anyway
        /// </summary>
        public void verif()
        {
            XElement LineStationRootElem = XMLTools.LoadListFromXMLElement(LineStationPath);
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);
            List<XElement> r = new List<XElement>();
            IEnumerable<int> lst = from item in LineRootElem.Elements()
                                   select int.Parse(item.Element("Code").Value);
            int lstNum = lst.Count();
            foreach (var item in LineStationRootElem.Elements())
            {
                if (!lst.Contains(int.Parse(item.Element("LineId").Value)))
                {
                    r.Add(item);
                }
            }
            IEnumerable<XElement> remove = r;
            remove.Remove();
            XMLTools.SaveListToXMLElement(LineStationRootElem, LineStationPath);

        }
        public TimeSpan getTime(Line line)
        {
            XElement AdjacentStationRootElem = XMLTools.LoadListFromXMLElement(AdjacentStationPath);//load the file xml
            XElement LineStationRootElem = XMLTools.LoadListFromXMLElement(LineStationPath);
            TimeSpan time = new TimeSpan();
            int i = 0;
            List<LineStation> lst = GetLineStationsFromLine(line).ToList();
            List<AdjacentStations> lst1 = new List<AdjacentStations>();
            foreach (var p in AdjacentStationRootElem.Elements())
            {

                if (lst[i].Station == int.Parse(p.Element("Station1").Value) && lst[i + 1].Station == int.Parse(p.Element("Station2").Value))
                {
                    lst1.Add(new AdjacentStations
                    {
                        Distance = Int32.Parse(p.Element("Distance").Value),
                        Station1 = Int32.Parse(p.Element("Station1").Value),
                        Station2 = Int32.Parse(p.Element("Station2").Value),
                        Time = TimeSpan.ParseExact(p.Element("Time").Value, "hh\\:mm\\:ss", CultureInfo.InvariantCulture)
                    });
                    i++;
                }
                if (lst[i].LineStationIndex == lst.Last().LineStationIndex)
                    break;
            }
            List<AdjacentStations> lst2 = lst1.ToList();
            for (int k = 0; k < lst2.Count(); k++)
                time += lst2[k].Time;

            return time;
        }


        #endregion

        #region linetrip
        public void addLineTrip(int id)
        {
            XElement LineTripRootElem = XMLTools.LoadListFromXMLElement(LineTripPath);//load xml file

            XElement linetrip = (from p in LineTripRootElem.Elements()//search it
                                 where int.Parse(p.Element("LineId").Value) == id
                                 select p).FirstOrDefault();

            if (linetrip != null)
                throw new DO.DLExeption("this linetrip already exist");

            //create it
            XElement lineTripElem = new XElement("LineId", new XElement("LineId", id.ToString()),
                                  new XElement("StartAt", (new TimeSpan(6,0,0).ToString())),
                                  new XElement("FinishAt", (new TimeSpan(22, 0, 0).ToString())),
                                  new XElement("Frequency", (new TimeSpan(0,(new Random().Next(25)),0).ToString()))
                                            );
            //add in file
            LineTripRootElem.Add(lineTripElem);
            //and save it
            XMLTools.SaveListToXMLElement(LineTripRootElem, LineTripPath);
        }


        public void updateLineTrip(LineTrip LineTrip)
        {
            XElement LineTripRootElem = XMLTools.LoadListFromXMLElement(LineTripPath);//load xml file

            XElement linetrip = (from p in LineTripRootElem.Elements()//search this line
                              where int.Parse(p.Element("LineId").Value) == LineTrip.LineId
                              select p).FirstOrDefault();

            
            if (linetrip != null)// and update all the field
            {
                linetrip.Element("lineId").Value = LineTrip.LineId.ToString();
                linetrip.Element("StartAt").Value = LineTrip.StartAt.ToString();
                linetrip.Element("FinishAt").Value = LineTrip.FinishAt.ToString();
                linetrip.Element("Frequency").Value = LineTrip.Frequency.ToString();
                XMLTools.SaveListToXMLElement(LineTripRootElem, LineTripPath);//and save it
            }
            else
                throw new DO.DLExeption("this line trip dosn't exist");
        }

        public void removeLineTrip(int id)
        {
            XElement LineTripRootElem = XMLTools.LoadListFromXMLElement(LineTripPath);//load xml file


            XElement lineTrip = (from p in LineTripRootElem.Elements()//search this line
                             where int.Parse(p.Element("LineId").Value) == id
                             select p).FirstOrDefault();
           
            if (lineTrip != null)
            {
                lineTrip.Remove(); //and remove it

                XMLTools.SaveListToXMLElement(LineTripRootElem, LineTripPath);

            }
            else
                throw new DO.DLExeption("this line trip dosn't exist");
        }

        public LineTrip getLineTrip(int id)
        {
            XElement LineTripRootElem = XMLTools.LoadListFromXMLElement(LineTripPath);//load xml file


            LineTrip linetrip = (from p in LineTripRootElem.Elements()//select the first line with this id
                                 where int.Parse(p.Element("LineId").Value) == id
                                 select new LineTrip()
                                 {
                                     LineId = Int32.Parse(p.Element("LineId").Value),
                                     StartAt = TimeSpan.Parse(p.Element("StartAt").Value, CultureInfo.InvariantCulture),
                                     FinishAt = TimeSpan.Parse(p.Element("FinishAt").Value, CultureInfo.InvariantCulture),
                                     Frequency = TimeSpan.Parse(p.Element("Frequency").Value, CultureInfo.InvariantCulture),
                                 }
                        ).FirstOrDefault();

            if (linetrip == null)//and return it
                throw new DO.DLExeption("this line trip dosn't exist");
            return linetrip;
        }

        #endregion
    }
}
