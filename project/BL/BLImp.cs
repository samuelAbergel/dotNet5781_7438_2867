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
            int id = lineDO.Id;
            lineDO.CopyPropertiesTo(lineBO);
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
        public IEnumerable<Line> getAllLine()
        {
            return from item in dl.getAllLine()
                   select lineDoBoAdapter(item);
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

    }
}
