using DLAPI;
using DO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

        #region DS XML Files

        string BusPath = @"BusXml.xml"; //XMLSerializer
        string LinePath = @"LineXml.xml"; //XElement
        string StationPath = @"StationXml.xml"; //XElement
        string AdjacentStationPath = @"AdjacentStationXml.xml"; //XMLSerializer
        string UserPath = @"UsersXml.xml";

        #endregion

        #region adjacent station
        public void addAdjacentStation(AdjacentStations adjacentStations)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdjacentStations> getAdjacentStation()
        {
            throw new NotImplementedException();
        }

        public AdjacentStations getAdjacentStations(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Station> GetAdjacentStationsOfStation(Station station)
        {
              XElement AdjacentStationRootElem = XMLTools.LoadListFromXMLElement(AdjacentStationPath);
              XElement StationRootElem = XMLTools.LoadListFromXMLElement(StationPath);

            var num = from item in AdjacentStationRootElem.Elements()
                      where station.Code == int.Parse(item.Element("Station1").Value)
                      select int.Parse(item.Element("Station2").Value);

            var num1 = from item in AdjacentStationRootElem.Elements()
                       where station.Code == int.Parse(item.Element("Station2").Value)
                       select int.Parse(item.Element("Station1").Value);

            if (num.Count() == 0 && num1.Count() == 0)
                return null;
            num = num.Concat(num1);
            var lst = from item in StationRootElem.Elements()
                      from item1 in num
                      where int.Parse(item.Element("Code").Value) == item1
                      select new Station
                      {
                          Code = Int32.Parse(item.Element("Code").Value),
                          Lattitude = double.Parse(item.Element("Lattitude").Value, CultureInfo.InvariantCulture),
                          Longitude = double.Parse(item.Element("Longitude").Value, CultureInfo.InvariantCulture),
                          Name = item.Element("Name").Value,
                      };

            if (lst.Count() == 0)
                return null;
            return lst.Distinct();
        }
        public void removeAdjacentStation(int id)
        {
            throw new NotImplementedException();
        }
        public void updateAdjacentStation(AdjacentStations adjacentStations)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region bus
        public void addBus(Bus bus)
        {
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);

            XElement bus1 = (from p in BusRootElem.Elements()
                             where int.Parse(p.Element("LicenseNum").Value) == bus.LicenseNum
                             select p).FirstOrDefault();

            if (bus1 != null)
                throw new DO.badIdBusexeption(bus);

            XElement busElem = new XElement("Bus", new XElement("LicenseNum", bus.LicenseNum.ToString()),
                                  new XElement("FromDate", bus.FromDate.ToShortDateString()),
                                  new XElement("TotalTrip", bus.TotalTrip.ToString()),
                                  new XElement("FuelRemain", bus.FuelRemain.ToString()),
                                  new XElement("previewTreatmentDate", bus.previewTreatmentDate.ToShortDateString()),
                                  new XElement("BusOfLine", bus.BusOfLine.ToString()),
                                  new XElement("Status", bus.Status.ToString()));

            BusRootElem.Add(busElem);

            XMLTools.SaveListToXMLElement(BusRootElem, BusPath);
        }
        public IEnumerable<Bus> GetAllBus()
        {
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);

            return (from p in BusRootElem.Elements()
                    select new Bus()
                    {
                        BusOfLine = Int32.Parse(p.Element("BusOfLine").Value),
                        FromDate = DateTime.Parse(p.Element("FromDate").Value),
                        FuelRemain = double.Parse(p.Element("FuelRemain").Value, CultureInfo.InvariantCulture),
                        LicenseNum = Int32.Parse(p.Element("LicenseNum").Value),
                        previewTreatmentDate = DateTime.Parse(p.Element("previewTreatmentDate").Value),
                        Status = (BusStatus)Enum.Parse(typeof(BusStatus),p.Element("Status").Value),
                        TotalTrip = double.Parse(p.Element("TotalTrip").Value, CultureInfo.InvariantCulture),
                    }
                   );
        }
        public Bus GetBus(int id)
        {
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);

            Bus bus = (from p in BusRootElem.Elements()
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

            if (bus == null)
                throw new DO.badIdBusexeption(id);
            return bus;
        }
        public void refuelling(int fuel, Bus bus)
        {
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);

            Bus realBus = (from p in BusRootElem.Elements()
                       where int.Parse(p.Element("LicenseNum").Value) == bus.LicenseNum
                       select new Bus()
                       {
                           BusOfLine = Int32.Parse(p.Element("BusOfLine").Value),
                           FromDate = DateTime.Parse(p.Element("FromDate").Value),
                           FuelRemain = double.Parse(p.Element("FuelRemain").Value, CultureInfo.InvariantCulture) + fuel,
                           LicenseNum = Int32.Parse(p.Element("LicenseNum").Value),
                           previewTreatmentDate = DateTime.Parse(p.Element("previewTreatmentDate").Value),
                           Status = (BusStatus)Enum.Parse(typeof(BusStatus), p.Element("Status").Value),
                           TotalTrip = double.Parse(p.Element("TotalTrip").Value, CultureInfo.InvariantCulture),
                       }
                        ).FirstOrDefault();

            if (realBus == null)
                throw new DO.badIdBusexeption(bus.LicenseNum);
            updateBus(realBus);
        }
        public void removeBus(int id)
        {
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);

            XElement bus = (from p in BusRootElem.Elements()
                            where int.Parse(p.Element("LicenseNum").Value) == id
                            select p).FirstOrDefault();

            if (bus != null)
            {
                bus.Remove(); //<==>   Remove per from personsRootElem

                XMLTools.SaveListToXMLElement(BusRootElem, BusPath);
            }
            else
                throw new DO.badIdBusexeption(id);
        }
        public IEnumerable<Bus> searchBus(string item)
        {
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);
            IEnumerable<Bus> listStart = (from p in BusRootElem.Elements()
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
            
            if (listStart != null)
                return listStart;
            return null;
        }
        public void treatment(Bus bus)
        {
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);

            Bus realBus = (from p in BusRootElem.Elements()
                           where int.Parse(p.Element("LicenseNum").Value) == bus.LicenseNum
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

            if (realBus == null)
                throw new DO.badIdBusexeption(bus.LicenseNum);
           // realBus.Status = BusStatus.inTreatment;
            realBus.previewTreatmentDate = DateTime.Now;
            updateBus(realBus);
        }
        public void updateBus(Bus bus)
        {
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);

            XElement bus1 = (from p in BusRootElem.Elements()
                            where int.Parse(p.Element("LicenseNum").Value) == bus.LicenseNum
                            select p).FirstOrDefault();

            if (bus1 != null)
            {
                bus1.Element("LicenseNum").Value = bus.LicenseNum.ToString();
                bus1.Element("FromDate").Value = bus.FromDate.ToShortDateString();
                bus1.Element("TotalTrip").Value = bus.TotalTrip.ToString();
                bus1.Element("FuelRemain").Value = bus.FuelRemain.ToString();
                bus1.Element("previewTreatmentDate").Value = bus.previewTreatmentDate.ToShortDateString();
                bus1.Element("BusOfLine").Value = bus.BusOfLine.ToString();
                bus1.Element("Status").Value = bus.Status.ToString();

                XMLTools.SaveListToXMLElement(BusRootElem, BusPath);
            }
            else
                throw new DO.badIdBusexeption(bus.LicenseNum);
        }
        public bool isBusExisting(int liscenceNumber)
        {
            XElement BusRootElem = XMLTools.LoadListFromXMLElement(BusPath);
            Bus busVerif = (from p in BusRootElem.Elements()
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
            if (busVerif != null)
                return false;
            return true;
        }
        #endregion

        #region line
        public void addLine(Line line)
        {
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);

            XElement line1 = (from p in LineRootElem.Elements()
                             where int.Parse(p.Element("Id").Value) == line.Id
                             select p).FirstOrDefault();

            if (line1 != null)
                throw new DO.badIdLineexeption(line);

            XElement lineElem = new XElement("Line", new XElement("Id", line.Id.ToString()),
                                  new XElement("Code", line.Code.ToString()),
                                  new XElement("Area", line.Area.ToString()),
                                  new XElement("FirstStation", line.FirstStation),
                                  new XElement("LastStation", line.LastStation),
                                  new XElement("listOfStationInLine",
                                  from item in line.listOfStationInLine
                                  select
                                      new XElement("Station", 
                                                 new XElement("Code", item.Code.ToString()),
                                                 new XElement("Name", item.Name),
                                                 new XElement("Longitude", item.Longitude.ToString()),
                                                 new XElement("Lattitude", item.Lattitude.ToString())
                                                  )
                                              )
                                            );

            LineRootElem.Add(lineElem);

            XMLTools.SaveListToXMLElement(LineRootElem, LinePath);
        }
        public IEnumerable<Line> getAllLine()
        {
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);

            return (from p in LineRootElem.Elements()
                    select new Line()
                    {
                        Id = Int32.Parse(p.Element("Id").Value),
                        Area = (Areas)Enum.Parse(typeof(Areas), p.Element("Area").Value),
                        Code = Int32.Parse(p.Element("Code").Value),
                        FirstStation = p.Element("FirstStation").Value,
                        LastStation = p.Element("LastStation").Value,
                        listOfStationInLine = from item in p.Element("listOfStationInLine").Elements()
                                              select new Station
                                              {
                                                  Code = Int32.Parse(item.Element("Code").Value),
                                                  Lattitude = double.Parse(item.Element("Lattitude").Value, CultureInfo.InvariantCulture),
                                                  Longitude = double.Parse(item.Element("Longitude").Value, CultureInfo.InvariantCulture),
                                                  Name = item.Element("Name").Value,
                                              },
                    }
                   ); 
        }
        public Line getLine(int id)
        {
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);

            Line line = (from p in LineRootElem.Elements()
                       where int.Parse(p.Element("Id").Value) == id
                       select new Line()
                       {
                           Id = Int32.Parse(p.Element("Id").Value),
                           Area = (Areas)Enum.Parse(typeof(Areas), p.Element("Area").Value),
                           Code = Int32.Parse(p.Element("Code").Value),
                           FirstStation = p.Element("FirstStation").Value,
                           LastStation = p.Element("LastStation").Value,
                           listOfStationInLine = from item in p.Element("listOfStationInLine").Elements()
                                                 select new Station
                                                 {
                                                     Code = Int32.Parse(p.Element("Code").Value),
                                                     Lattitude = double.Parse(p.Element("Lattitude").Value, CultureInfo.InvariantCulture),
                                                     Longitude = double.Parse(p.Element("Longitude").Value, CultureInfo.InvariantCulture),
                                                     Name = p.Element("Name").Value,
                                                 },
                       }
                        ).FirstOrDefault();

            if (line == null)
                throw new DO.badIdLineexeption(id);
            return line;
        }
        public IEnumerable<Station> getStationOfLine(Line line)
        {
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);

            return from item in line.listOfStationInLine
                   select item;
        }
        public bool isLineExisting(Line line)
        {
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);
            var lineVerif = (from p in LineRootElem.Elements()
                            where int.Parse(p.Element("Id").Value) == line.Id
                            select new Line()
                            {
                                Id = Int32.Parse(p.Element("Id").Value),
                                Area = (Areas)Enum.Parse(typeof(Areas), p.Element("Area").Value),
                                Code = Int32.Parse(p.Element("Code").Value),
                                FirstStation = p.Element("FirstStation").Value,
                                LastStation = p.Element("LastStation").Value,
                                listOfStationInLine = from item in p.Element("listOfStationInLine").Elements()
                                                      select new Station
                                                      {
                                                          Code = Int32.Parse(item.Element("Code").Value),
                                                          Lattitude = double.Parse(item.Element("Lattitude").Value, CultureInfo.InvariantCulture),
                                                          Longitude = double.Parse(item.Element("Longitude").Value, CultureInfo.InvariantCulture),
                                                          Name = item.Element("Name").Value,
                                                      },
                            }
                        );
            if (lineVerif.Count() != 0)
                return false;
            var verifStation = from item in LineRootElem.Elements()
                               from item1 in item.Element("listOfStationInLine").Elements()
                               from item2 in line.listOfStationInLine
                               where item.Element("listOfStationInLine").Elements().Count() == line.listOfStationInLine.Count()
                               where int.Parse(item1.Element("Code").Value) == item2.Code
                               select new Station
                               {

                                   Code = Int32.Parse(item1.Element("Code").Value),
                                   Lattitude = double.Parse(item1.Element("Lattitude").Value, CultureInfo.InvariantCulture),
                                   Longitude = double.Parse(item1.Element("Longitude").Value, CultureInfo.InvariantCulture),
                                   Name = item1.Element("Name").Value,
                               };
           

            if (verifStation.Count() == line.listOfStationInLine.Count())
                return false;
            return true;
        }
        public void removeLine(int id)
        {
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);

            XElement line = (from p in LineRootElem.Elements()
                            where int.Parse(p.Element("Id").Value) == id
                            select p).FirstOrDefault();

            if (line != null)
            {
                line.Remove(); //<==>   Remove per from personsRootElem

                XMLTools.SaveListToXMLElement(LineRootElem, LinePath);
            }
            else
                throw new DO.badIdBusexeption(id);
        }
        public IEnumerable<Line> searchLine(string item)
        {
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);
            IEnumerable<Line> listStart = (from p in LineRootElem.Elements()
                                          where p.Element("Id").Value.ToString().StartsWith(item)
                                          select new Line()
                                          {
                                              Id = Int32.Parse(p.Element("Id").Value),
                                              Area = (Areas)Enum.Parse(typeof(Areas), p.Element("Area").Value),
                                              Code = Int32.Parse(p.Element("Code").Value),
                                              FirstStation = p.Element("FirstStation").Value,
                                              LastStation = p.Element("LastStation").Value,
                                              listOfStationInLine = from item1 in p.Element("listOfStationInLine").Elements()
                                                                    select new Station
                                                                    {
                                                                        Code = Int32.Parse(item1.Element("Code").Value),
                                                                        Lattitude = double.Parse(item1.Element("Lattitude").Value, CultureInfo.InvariantCulture),
                                                                        Longitude = double.Parse(item1.Element("Longitude").Value, CultureInfo.InvariantCulture),
                                                                        Name = item1.Element("Name").Value,
                                                                    },
                                          }
                                  );

            if (listStart != null)
                return listStart;
            return null;
        }
        public void updateLine(Line line)
        {
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);

            XElement line1 = (from p in LineRootElem.Elements()
                                 where int.Parse(p.Element("Id").Value) == line.Id
                                 select p).FirstOrDefault();

            if (line1 != null)
            {
                line1.Element("Id").Value = line.Id.ToString();
                line1.Element("Code").Value = line.Code.ToString();
                line1.Element("Area").Value = line.Area.ToString();
                line1.Element("FirstStation").Value = line.FirstStation;
                line1.Element("LastStation").Value = line.LastStation;
                line1.Element("listOfStationInLine").Add(from item in line.listOfStationInLine
                                                                  select new XElement("Station",
                                                                         new XElement("Code", item.Code.ToString()),
                                                                         new XElement("Name", item.Name),
                                                                         new XElement("Longitude", item.Longitude.ToString()),
                                                                         new XElement("Lattitude", item.Lattitude.ToString())
                                                                                     ));
                XMLTools.SaveListToXMLElement(LineRootElem, LinePath);
            }
            else
                throw new DO.badIdLineexeption(line.Id);
        }
        #endregion

        #region station
        public void addStation(Station station)
        {
            XElement StationRootElem = XMLTools.LoadListFromXMLElement(StationPath);

            XElement station1 = (from p in StationRootElem.Elements()
                             where int.Parse(p.Element("Code").Value) == station.Code
                             select p).FirstOrDefault();

            if (station1 != null)
                throw new DO.badIDStationexeption(station);

            XElement stationElem = new XElement("Station", new XElement("Code", station.Code.ToString()),
                                  new XElement("Name", station.Name),
                                  new XElement("Longitude",station.Longitude.ToString()),
                                  new XElement("Lattitude", station.Lattitude.ToString()));

            StationRootElem.Add(stationElem);

            XMLTools.SaveListToXMLElement(StationRootElem, StationPath);
        }
        public IEnumerable<Station> getAllStation()
        {
            XElement StationRootElem = XMLTools.LoadListFromXMLElement(StationPath);

            return (from p in StationRootElem.Elements()
                    select new Station()
                    {
                        Code = Int32.Parse(p.Element("Code").Value),
                        Lattitude = double.Parse(p.Element("Lattitude").Value, CultureInfo.InvariantCulture),
                        Longitude = double.Parse(p.Element("Longitude").Value, CultureInfo.InvariantCulture),
                        Name = p.Element("Name").Value,
                    }
                   );
        }
        public IEnumerable<Line> getLineOfStation(Station station)
        {
            XElement LineRootElem = XMLTools.LoadListFromXMLElement(LinePath);

            return from item in LineRootElem.Elements()
                   from stu in item.Element("listOfStationInLine").Elements()
                   where int.Parse(stu.Element("Code").Value) == station.Code
                   select new Line
                   {
                       Id = Int32.Parse(item.Element("Id").Value),
                       Area = (Areas)Enum.Parse(typeof(Areas), item.Element("Area").Value),
                       Code = Int32.Parse(item.Element("Code").Value),
                       FirstStation = item.Element("FirstStation").Value,
                       LastStation = item.Element("LastStation").Value,
                       listOfStationInLine = from item1 in item.Element("listOfStationInLine").Elements()
                                             select new Station
                                             {
                                                 Code = Int32.Parse(item1.Element("Code").Value),
                                                 Lattitude = double.Parse(item1.Element("Lattitude").Value, CultureInfo.InvariantCulture),
                                                 Longitude = double.Parse(item1.Element("Longitude").Value, CultureInfo.InvariantCulture),
                                                 Name = item1.Element("Name").Value,
                                             },
                   };

        }
        public Station getStation(int id)
        {
            XElement StationRootElem = XMLTools.LoadListFromXMLElement(StationPath);

            Station station = (from p in StationRootElem.Elements()
                       where int.Parse(p.Element("Code").Value) == id
                       select new Station()
                       {
                           Code = Int32.Parse(p.Element("Code").Value),
                           Lattitude = double.Parse(p.Element("Lattitude").Value, CultureInfo.InvariantCulture),
                           Longitude = double.Parse(p.Element("Longitude").Value, CultureInfo.InvariantCulture),
                           Name = p.Element("Name").Value,
                       }
                        ).FirstOrDefault();

            if (station == null)
                throw new DO.badIDStationexeption(id);
            return station;
        }
        public void removeStation(int id)
        {
            XElement StationRootElem = XMLTools.LoadListFromXMLElement(StationPath);

            XElement station = (from p in StationRootElem.Elements()
                            where int.Parse(p.Element("Code").Value) == id
                            select p).FirstOrDefault();

            if (station != null)
            {
                station.Remove(); //<==>   Remove per from personsRootElem

                XMLTools.SaveListToXMLElement(StationRootElem, StationPath);
            }
            else
                throw new DO.badIdBusexeption(id);
        }
        public IEnumerable<Station> searchStation(string item)
        {

            XElement StationRootElem = XMLTools.LoadListFromXMLElement(StationPath);

            IEnumerable<Station> listStation = (from p in StationRootElem.Elements()
                    where p.Element("Code").Value.ToString().StartsWith(item)
                    select new Station()
                    {
                        Code = Int32.Parse(p.Element("Code").Value),
                        Lattitude = double.Parse(p.Element("Lattitude").Value, CultureInfo.InvariantCulture),
                        Longitude = double.Parse(p.Element("Longitude").Value, CultureInfo.InvariantCulture),
                        Name = p.Element("Name").Value,
                    }
                   );
            if (listStation != null)
                return listStation;
            return null;
        }
        public void updateStation(Station station)
        {
            XElement StationRootElem = XMLTools.LoadListFromXMLElement(StationPath);

            XElement station1 = (from p in StationRootElem.Elements()
                             where int.Parse(p.Element("Code").Value) == station.Code
                             select p).FirstOrDefault();

            if (station1 != null)
            {
                station1.Element("Code").Value = station.Code.ToString();
                station1.Element("Name").Value = station.Name;
                station1.Element("Lattitude").Value = station.Lattitude.ToString();
                station1.Element("Longitude").Value = station.Longitude.ToString();

                XMLTools.SaveListToXMLElement(StationRootElem, StationPath);
            }
            else
                throw new DO.badIDStationexeption(station.Code);
        }
        public bool isStationExisting(int code)
        {
            XElement StationRootElem = XMLTools.LoadListFromXMLElement(StationPath);

            Station stationVerif = (from p in StationRootElem.Elements()
                               where int.Parse(p.Element("Code").Value) == code
                               select new Station()
                               {
                                   Code = Int32.Parse(p.Element("Code").Value),
                                   Lattitude = double.Parse(p.Element("Lattitude").Value),
                                   Longitude = double.Parse(p.Element("Longitude").Value),
                                   Name = p.Element("Name").Value.ToString(),
                               }
                        ).FirstOrDefault();
            if (stationVerif != null)
                return false;
            return true;
        }
        #endregion

        #region user
        public bool getUser(string username, string password)
        {
            XElement UserRootElem = XMLTools.LoadListFromXMLElement(UserPath);

            User verif = (from p in UserRootElem.Elements()
                          where p.Element("UserName").Value == username && p.Element("Password").Value == password
                          select new User
                          {
                              Password = p.Element("Password").Value,
                              UserName = p.Element("UserName").Value,
                          }).FirstOrDefault();
            if (verif != null)
                return true;
            return false;

        }
        #endregion
    }
}
