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
        /// <summary>
        /// to change from do to bo
        /// </summary>
        /// <param name="busDO"></param>
        /// <returns></returns>
        BO.Bus busDoBoAdapter(DO.Bus busDO)
        {
            BO.Bus busBO = new BO.Bus();
            busDO.CopyPropertiesTo(busBO);//to copy property from DO to BO
            return busBO;
        }
        public void addBus(Bus bus)
        {
            DO.Bus busDO = new DO.Bus(); //create bus DO
            bus.CopyPropertiesTo(busDO); //and copy property from BO
            try
            {
                dl.addBus(busDO); // use add bus of dlObject
            }
            catch (DO.badIdBusexeption ex) // if there is an exception of dl.Addbus we return it here
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void updateBus(Bus bus)
        {
            DO.Bus busDO = new DO.Bus();//create bus DO
            bus.CopyPropertiesTo(busDO);//and copy property from BO
            try
            {
                dl.updateBus(busDO); //use update bus of DLObject
            }
            catch (DO.badIdBusexeption ex)//if there is an exception of dl.updateBus we return it here
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void removeBus(int id)
        {
            try
            {
                dl.removeBus(id);//use remove bus of DLObject
            }
            catch (DO.badIdBusexeption ex)//if there is an exception of dl.removeBus we return it here
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void refuelling(int fuel, BO.Bus bus)
        {
            DO.Bus busDo = new DO.Bus();//create bus DO
            bus.CopyPropertiesTo(busDo);//and copy property from BO
            dl.refuelling(fuel, busDo);//use dl.refuelling of DLObject
            bus.FuelRemain = busDo.FuelRemain;//change gasole of bus
        }
        public void treatment(BO.Bus bus)
        {
            DO.Bus busDo = new DO.Bus();//create bus DO
            bus.CopyPropertiesTo(busDo);//and copy property from BO
            dl.treatment(busDo);//use dl.treatment of DLObject
            bus.Status = BusStatus.inTreatment;//change statue of bus
            bus.previewTreatmentDate = busDo.previewTreatmentDate;
        }
        public Bus GetBus(int id)
        {
            DO.Bus busDO = new DO.Bus();//create bus DO
            try
            {
                busDO = dl.GetBus(id);//use dl.getBus of DLObject
            }
            catch (DO.badIdBusexeption ex)
            {
                Console.WriteLine(ex.Message);
            }
            return busDoBoAdapter(busDO);//return adapter of busBO in busDO
        }
        public IEnumerable<Bus> GetAllBus()
        {
            return from item in dl.GetAllBus()//search bus in dl.getallbus from DLObject
                   select busDoBoAdapter(item); //return adapter 
        }
        #endregion

        #region line
        /// <summary>
        /// to change from DO to BO
        /// </summary>
        /// <param name="lineDO"></param>
        /// <returns></returns>
        BO.Line lineDoBoAdapter(DO.Line lineDO)
        {
            //adapt the property one by one
            BO.Line lineBO = new BO.Line();
            lineBO.Area = (Areas)lineDO.Area;
            lineBO.Code = lineDO.Code;
            lineBO.FirstStation = lineDO.FirstStation;
            lineBO.LastStation = lineDO.LastStation;
            lineBO.Id = lineDO.Id;
            if(lineDO.listOfStationInLine != null)
            //to adapt this enumerable we use a linq
            lineBO.listOfStationInLine = from item in lineDO.listOfStationInLine//search in list of station of this line
                                         select stationDoBoAdapter(item);//return this adapt list
            return lineBO;
        }
        
        public void addLine(Line line)
        {
            DO.Line lineDO = new DO.Line();//create line DO
            line.CopyPropertiesTo(lineDO);//copy property from BO line in DO line
            try
            {
                dl.addLine(lineDO);//use dl.addLine of DLObject
            }
            catch (DO.badIdLineexeption ex)//if there is an error in the add we display the error here
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void updateLine(Line line)
        {
            DO.Line lineDO = new DO.Line();//create line DO
            line.CopyPropertiesTo(lineDO);//copy property from BO line to DO line
            try
            {
                dl.updateLine(lineDO);//use dl.updateline of DLObject
            }
            catch (DO.badIdLineexeption ex)//if there is an error in the update we display the error here
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void removeLine(int id)
        {
            try
            {
                dl.removeLine(id); //try to remove with dl.removeline from DLObject
            }
            catch (DO.badIdLineexeption ex)//if there is an error in the remove we display the error here
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Line getLine(int id)
        {
            DO.Line lineDO = new DO.Line();//create DO line
            try
            {
                lineDO = dl.getLine(id);//use dl.getline of DLObject
            }
            catch (DO.badIdLineexeption ex)//if there is an error in the getline we display the error here
            {
                Console.WriteLine(ex.Message);
            }
            return lineDoBoAdapter(lineDO);
        }
        public IEnumerable<BO.Line> getAllLine()
        {
            return from item in dl.getAllLine()//search line in de.getallline of dlobject
                   select lineDoBoAdapter(item);//select adapt line
        }
        /// <summary>
        /// get list of station of line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public IEnumerable<BO.Station> getStationOfLine(Line line)
        {
            DO.Line lineDo = new DO.Line();//create line DO
            //copy all property to DO line from line in parameter
            lineDo.Area = (DO.Areas)line.Area;
            lineDo.Id = line.Id;
            lineDo.Code = line.Code;
            lineDo.FirstStation = line.FirstStation;
            lineDo.LastStation = line.LastStation;
            if(line.listOfStationInLine != null)
            //to copy this property we use linq
            lineDo.listOfStationInLine = from item in line.listOfStationInLine
                                         select stationDoBoAdapter(item);
            //return all station of this using dl.getstation and lineDO
            return from item in dl.getStationOfLine(lineDo)
                   select stationDoBoAdapter(item);
        }
        #endregion

        #region station
        /// <summary>
        /// change from DO to BO
        /// </summary>
        /// <param name="stationDO"></param>
        /// <returns></returns>
        BO.Station stationDoBoAdapter(DO.Station stationDO)
        {
            BO.Station stationBO = new BO.Station();// create station BO
            stationDO.CopyPropertiesTo(stationBO);//copy property from DO to BO
            return stationBO; //return station BO
        }
        DO.Station stationDoBoAdapter(BO.Station stationBO)
        {
            DO.Station stationDO = new DO.Station();// create station DO
            stationBO.CopyPropertiesTo(stationDO);//copy property from BO to DO
            return stationDO; //return station DO
        }
        public void addStation(Station station)
        {
            DO.Station stationDO = new DO.Station();//create station do
            station.CopyPropertiesTo(stationDO);//copy property from DO to BO
            try
            {
                dl.addStation(stationDO);// try dl.addstation from dlobject
            }
            catch (DO.badIdBusexeption ex)//if there is an error from add we display error here
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void updateStation(Station station)
        {
            DO.Station stationDO = new DO.Station();//create do station
            station.CopyPropertiesTo(stationDO);//copy property from BO to DO
            try
            {
                dl.updateStation(stationDO);//try dl.update from dlobject
            }
            catch (DO.badIdBusexeption ex)//if there is an exeption from update we display error here
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void removeStation(int id)
        {
            try
            {
                dl.removeStation(id);//try dl.remove from dlobject
            }
            catch (DO.badIdBusexeption ex)//if there is an exeption from remove we display error here
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Station getStation(int id)
        {
            DO.Station stationDO = new DO.Station();//create do station
            try
            {
                stationDO = dl.getStation(id);//try dl.getstation from dlobject
            }
            catch (DO.badIDStationexeption ex)//if there is an exeption from get we display error here
            {
                Console.WriteLine(ex.Message);
            }
            return stationDoBoAdapter(stationDO);//return adapter station DO
        }
        public IEnumerable<Station> getAllStation()
        {
            return from item in dl.getAllStation()//search station in getallstation 
                   select stationDoBoAdapter(item);//select station adapter
        }

        public IEnumerable<Line> getLineOfStation(Station station)
        {
            DO.Station stationDO = new DO.Station();//create do station
            station.CopyPropertiesTo(stationDO);//copy property from BO to DO
            return from item in dl.getLineOfStation(stationDO)
                   select lineDoBoAdapter(item);
        }
        #endregion

        #region adjacent station
        /// <summary>
        /// change from DO to BO
        /// </summary>
        /// <param name="AdjacentStationDO"></param>
        /// <returns></returns>
        BO.AdjacentStations AdjacentStationDoBoAdapter(DO.AdjacentStations AdjacentStationDO)
        {
            BO.AdjacentStations AdjacentStationBO = new BO.AdjacentStations();
            AdjacentStationDO.CopyPropertiesTo(AdjacentStationBO);
            return AdjacentStationBO;
        }
        /// <summary>
        /// change from BO to DO
        /// </summary>
        /// <param name="AdjacentStationBO"></param>
        /// <returns></returns>
        DO.AdjacentStations AdjacentStationBoDoAdapter(BO.AdjacentStations AdjacentStationBO)
        {
            DO.AdjacentStations AdjacentStationDO = new DO.AdjacentStations();
            AdjacentStationBO.CopyPropertiesTo(AdjacentStationDO);
            return AdjacentStationDO;
        }
        public IEnumerable<BO.AdjacentStations> getAdjacentStation()
        {
            return from item in dl.getAdjacentStation()//search station in getadjacent station
                   select AdjacentStationDoBoAdapter(item);//select station adapter
        }

        public void removeAdjacentStation(int id)
        {
            try
            {
                dl.removeAdjacentStation(id);//try dl.removeAdjacentStation from dlobject

            }
            catch (Exception e)//if there is an exeption from remove we diplay error here
            {
                Console.WriteLine(e);
            }
        }

        public void updateAdjacentStation(BO.AdjacentStations adjacentStationsBO)
        {
            DO.AdjacentStations AdjacentStationDO = new DO.AdjacentStations();//create adjacent station DO
            adjacentStationsBO.CopyPropertiesTo(AdjacentStationDO);//copy property from DO to BO
            try
            {
                dl.updateAdjacentStation(AdjacentStationDO);//try update from dlobject
            }
            catch (Exception e)//if there is an error from update we display error here
            {
                Console.WriteLine(e);
            }
        }

        public BO.AdjacentStations getAdjacentStations(int id)
        {
            DO.AdjacentStations AdjacentStationsDO = new DO.AdjacentStations();//create adjacen station OD
            AdjacentStationsDO = dl.getAdjacentStations(id);//get station with his id
            return AdjacentStationDoBoAdapter(AdjacentStationsDO);//return this station adapt
        }

        public void addAdjacentStation(BO.AdjacentStations adjacentStationsBO)
        {
            DO.AdjacentStations AdjacentStationDO = new DO.AdjacentStations();//create adjacent station BO
            adjacentStationsBO.CopyPropertiesTo(AdjacentStationDO);//copy property from DO to BO
            try
            {
                dl.addAdjacentStation(AdjacentStationDO);//try add from dlobject

            }
            catch (Exception e)//if there is an exeption from add we display error here
            {
                Console.WriteLine(e);
            }
        }

        #endregion
    }
}
