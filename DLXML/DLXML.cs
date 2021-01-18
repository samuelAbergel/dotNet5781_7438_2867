using DLAPI;
using DO;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
                        FuelRemain = double.Parse(p.Element("FuelRemain").Value),
                        LicenseNum = Int32.Parse(p.Element("LicenseNum").Value),
                        previewTreatmentDate = DateTime.Parse(p.Element("previewTreatmentDate").Value),
                        Status = (BusStatus)Enum.Parse(typeof(BusStatus),p.Element("Status").Value),
                        TotalTrip = double.Parse(p.Element("TotalTrip").Value),
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
                           FuelRemain = double.Parse(p.Element("FuelRemain").Value),
                           LicenseNum = Int32.Parse(p.Element("LicenseNum").Value),
                           previewTreatmentDate = DateTime.Parse(p.Element("previewTreatmentDate").Value),
                           Status = (BusStatus)Enum.Parse(typeof(BusStatus), p.Element("Status").Value),
                           TotalTrip = double.Parse(p.Element("TotalTrip").Value),
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
                           FuelRemain = double.Parse(p.Element("FuelRemain").Value),
                           LicenseNum = Int32.Parse(p.Element("LicenseNum").Value),
                           previewTreatmentDate = DateTime.Parse(p.Element("previewTreatmentDate").Value),
                           Status = (BusStatus)Enum.Parse(typeof(BusStatus), p.Element("Status").Value),
                           TotalTrip = double.Parse(p.Element("TotalTrip").Value),
                       }
                        ).FirstOrDefault();

            if (realBus == null)
                throw new DO.badIdBusexeption(bus.LicenseNum);
            realBus.FuelRemain += fuel;
            bus.FuelRemain = realBus.FuelRemain;
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
                           FuelRemain = double.Parse(p.Element("FuelRemain").Value),
                           LicenseNum = Int32.Parse(p.Element("LicenseNum").Value),
                           previewTreatmentDate = DateTime.Parse(p.Element("previewTreatmentDate").Value),
                           Status = (BusStatus)Enum.Parse(typeof(BusStatus), p.Element("Status").Value),
                           TotalTrip = double.Parse(p.Element("TotalTrip").Value),
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
                               FuelRemain = double.Parse(p.Element("FuelRemain").Value),
                               LicenseNum = Int32.Parse(p.Element("LicenseNum").Value),
                               previewTreatmentDate = DateTime.Parse(p.Element("previewTreatmentDate").Value),
                               Status = (BusStatus)Enum.Parse(typeof(BusStatus), p.Element("Status").Value),
                               TotalTrip = double.Parse(p.Element("TotalTrip").Value),
                           }
                        ).FirstOrDefault();

            if (realBus == null)
                throw new DO.badIdBusexeption(bus.LicenseNum);
            realBus.Status = BusStatus.inTreatment;
            realBus.previewTreatmentDate = DateTime.Now;
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
            throw new NotImplementedException();
        }
        #endregion

        #region line
        public void addLine(Line line)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Line> getAllLine()
        {
            throw new NotImplementedException();
        }
        public Line getLine(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Station> getStationOfLine(Line line)
        {
            throw new NotImplementedException();
        }
        public bool isLineExisting(Line line)
        {
            throw new NotImplementedException();
        }
        public void removeLine(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Line> searchLine(string item)
        {
            throw new NotImplementedException();
        }
        public void updateLine(Line line)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region station
        public void addStation(Station station)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Station> getAllStation()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Line> getLineOfStation(Station station)
        {
            throw new NotImplementedException();
        }
        public Station getStation(int id)
        {
            throw new NotImplementedException();
        }
        public void removeStation(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Station> searchStation(string item)
        {
            throw new NotImplementedException();
        }
        public void updateStation(Station station)
        {
            throw new NotImplementedException();
        }
        public bool isStationExisting(int code)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
