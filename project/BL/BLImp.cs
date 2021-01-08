using BLAPI;
using BO;
using DLAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
     class BLImp : IBL
    {
        IDL dl = DLFactory.GetDL();

        #region bus
        BO.Bus busDoBoAdapter(DO.Bus busDO)
        {
            BO.Bus busBO = new BO.Bus();
            int id = busDO.LicenseNum;
            busDO.CopyPropertiesTo(busBO);
            return busBO;
        }
        public void addBus(Bus bus)
        {
            DO.Bus busDO = new DO.Bus();
            bus.CopyPropertiesTo(busDO);
            try
            {
                dl.addBus(busDO);
            }
            catch (DO.badIdBusexeption ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void updateBus(Bus bus)
        {
            DO.Bus busDO = new DO.Bus();
            bus.CopyPropertiesTo(busDO);
            try
            {
                dl.updateBus(busDO);
            }
            catch (DO.badIdBusexeption ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void removeBus(int id)
        {
            try
            {
                dl.removeBus(id);
            }
            catch (DO.badIdBusexeption ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void refuelling(int fuel, BO.Bus bus)
        {
            DO.Bus busDo = new DO.Bus();
            bus.CopyPropertiesTo(busDo);
            dl.refuelling(fuel, busDo);
            bus.FuelRemain = busDo.FuelRemain;
        }
        public void treatment(BO.Bus bus)
        {
            DO.Bus busDo = new DO.Bus();
            bus.CopyPropertiesTo(busDo);
            dl.treatment(busDo);
            bus.Status = BusStatus.inTreatment;
            bus.previewTreatmentDate = busDo.previewTreatmentDate;
        }
        public Bus GetBus(int id)
        {
            DO.Bus busDO = new DO.Bus();
            try
            {
                busDO = dl.GetBus(id);
            }
            catch (DO.badIdBusexeption ex)
            {
                Console.WriteLine(ex.Message);
            }
            return busDoBoAdapter(busDO);
        }
        public IEnumerable<Bus> GetAllBus()
        {
            return from item in dl.GetAllBus()
                   select busDoBoAdapter(item);
        }
        #endregion

        #region line
        BO.Line lineDoBoAdapter(DO.Line lineDO)
        {
            BO.Line lineBO = new BO.Line();
            lineBO.Area = (Areas)lineDO.Area;
            lineBO.Code = lineDO.Code;
            lineBO.FirstStation = lineDO.FirstStation;
            lineBO.LastStation = lineDO.LastStation;
            lineBO.Id = lineDO.Id;
            if(lineDO.listOfStationInLine != null)
            lineBO.listOfStationInLine = from item in lineDO.listOfStationInLine
                                         select AdjacentStationDoBoAdapter(item);
            return lineBO;
        }
        
        public void addLine(Line line)
        {
            DO.Line lineDO = new DO.Line();
            line.CopyPropertiesTo(lineDO);
            try
            {
                dl.addLine(lineDO);
            }
            catch (DO.badIdLineexeption ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void updateLine(Line line)
        {
            DO.Line lineDO = new DO.Line();
            line.CopyPropertiesTo(lineDO);
            try
            {
                dl.updateLine(lineDO);
            }
            catch (DO.badIdLineexeption ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void removeLine(int id)
        {
            try
            {
                dl.removeLine(id);
            }
            catch (DO.badIdLineexeption ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Line getLine(int id)
        {
            DO.Line lineDO = new DO.Line();
            try
            {
                lineDO = dl.getLine(id);
            }
            catch (DO.badIdLineexeption ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lineDoBoAdapter(lineDO);
        }
        public IEnumerable<BO.Line> getAllLine()
        {
            return from item in dl.getAllLine()
                   select lineDoBoAdapter(item);
        }

        public IEnumerable<BO.AdjacentStations> getStationOfLine(Line line)
        {
            DO.Line lineDo = new DO.Line();
            lineDo.Area = (DO.Areas)line.Area;
            lineDo.Id = line.Id;
            lineDo.Code = line.Code;
            lineDo.FirstStation = line.FirstStation;
            lineDo.LastStation = line.LastStation;
            if(line.listOfStationInLine != null)
            lineDo.listOfStationInLine = from item in line.listOfStationInLine
                                         select AdjacentStationBoDoAdapter(item);
            return from item in dl.getStationOfLine(lineDo)
                   select AdjacentStationDoBoAdapter(item);
        }
        #endregion

        #region station
        BO.Station stationDoBoAdapter(DO.Station stationDO)
        {
            BO.Station stationBO = new BO.Station();
            int id = stationDO.Code;
            stationDO.CopyPropertiesTo(stationBO);
            return stationBO;
        }
        public void addStation(Station station)
        {
            DO.Station stationDO = new DO.Station();
            station.CopyPropertiesTo(stationDO);
            try
            {
                dl.addStation(stationDO);
            }
            catch (DO.badIdBusexeption ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void updateStation(Station station)
        {
            DO.Station stationDO = new DO.Station();
            station.CopyPropertiesTo(stationDO);
            try
            {
                dl.updateStation(stationDO);
            }
            catch (DO.badIdBusexeption ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void removeStation(int id)
        {
            try
            {
                dl.removeStation(id);
            }
            catch (DO.badIdBusexeption ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Station getStation(int id)
        {
            DO.Station stationDO = new DO.Station();
            try
            {
                stationDO = dl.getStation(id);
            }
            catch (DO.badIDStationexeption ex)
            {
                Console.WriteLine(ex.Message);
            }
            return stationDoBoAdapter(stationDO);
        }
        public IEnumerable<Station> getAllStation()
        {
            return from item in dl.getAllStation()
                   select stationDoBoAdapter(item);
        }
        #endregion
        #region adjacent station
        BO.AdjacentStations AdjacentStationDoBoAdapter(DO.AdjacentStations AdjacentStationDO)
        {
            BO.AdjacentStations AdjacentStationBO = new BO.AdjacentStations();
            AdjacentStationDO.CopyPropertiesTo(AdjacentStationBO);
            return AdjacentStationBO;
        }
        DO.AdjacentStations AdjacentStationBoDoAdapter(BO.AdjacentStations AdjacentStationBO)
        {
            DO.AdjacentStations AdjacentStationDO = new DO.AdjacentStations();
            AdjacentStationBO.CopyPropertiesTo(AdjacentStationDO);
            return AdjacentStationDO;
        }
        public IEnumerable<BO.AdjacentStations> getAdjacentStation()
        {
            return from item in dl.getAdjacentStation()
                   select AdjacentStationDoBoAdapter(item);
        }

        public void removeAdjacentStation(int id)
        {
            dl.removeAdjacentStation(id);
        }

        public void updateAdjacentStation(BO.AdjacentStations adjacentStationsBO)
        {
            DO.AdjacentStations AdjacentStationDO = new DO.AdjacentStations();
            adjacentStationsBO.CopyPropertiesTo(AdjacentStationDO);
            dl.updateAdjacentStation(AdjacentStationDO);
        }

        public BO.AdjacentStations getAdjacentStations(int id)
        {
            DO.AdjacentStations AdjacentStationsDO = new DO.AdjacentStations();
            AdjacentStationsDO = dl.getAdjacentStations(id);
            return AdjacentStationDoBoAdapter(AdjacentStationsDO);
        }

        public void addAdjacentStation(BO.AdjacentStations adjacentStationsBO)
        {
            DO.AdjacentStations AdjacentStationDO = new DO.AdjacentStations();
            adjacentStationsBO.CopyPropertiesTo(AdjacentStationDO);
            dl.addAdjacentStation(AdjacentStationDO);
        }
        #endregion
    }
}
