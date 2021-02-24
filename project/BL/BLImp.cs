using BLAPI;
using BO;
using DLAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL
{
    public class BLImp : IBL
    {
        IDL dl = DLFactory.GetDL();

        //#region singelton
        //static readonly BLImp instance = new BLImp();
        //static BLImp() { }// static ctor to ensure instance init is done just before first usage
        //BLImp() { } // default => private
        //public static BLImp Instance { get => instance; }// The public Instance property to use
        //#endregion

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
            catch (BO.BLExeption ex) // if there is an exception of dl.Addbus we return it here
            {
                throw new BO.BLExeption(ex.Message);
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
            catch (BO.BLExeption ex)//if there is an exception of dl.updateBus we return it here
            {
                throw new BO.BLExeption(ex.Message);
            }
        }
        public void removeBus(int id)
        {
            try
            {
                dl.removeBus(id);//use remove bus of DLObject
            }
            catch (BO.BLExeption ex)//if there is an exception of dl.removeBus we return it here
            {
                throw new BO.BLExeption(ex.Message);
            }
        }
        public IEnumerable<Bus> searchBus(string item)
        {
            IEnumerable<Bus> lst = null;
            try
            {
                lst = from bus in dl.searchBus(item)
                      select busDoBoAdapter(bus);
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }
            return lst;
        }
        public void refuelling(int fuel, BO.Bus bus)
        {
            DO.Bus busDo = new DO.Bus();//create bus DO
            bus.CopyPropertiesTo(busDo);//and copy property from BO
            try
            {
                dl.refuelling(fuel, busDo);//use dl.refuelling 
                bus.FuelRemain = busDo.FuelRemain;//change gasole of bus
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }

        }
        public void treatment(BO.Bus bus)
        {
            DO.Bus busDo = new DO.Bus();//create bus DO
            bus.CopyPropertiesTo(busDo);//and copy property from BO
            try
            {
                dl.treatment(busDo);//use dl.treatment of DLObject
                bus.Status = BusStatus.inTreatment;//change statue of bus
                bus.previewTreatmentDate = busDo.previewTreatmentDate;
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }

        }
        public Bus GetBus(int id)
        {
            DO.Bus busDO = new DO.Bus();//create bus DO
            try
            {
                busDO = dl.GetBus(id);//use dl.getBus of DLObject
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }
            return busDoBoAdapter(busDO);//return adapter of busBO in busDO
        }
        public IEnumerable<Bus> GetAllBus()
        {
            return from item in dl.GetAllBus()//search bus in dl.getallbus from DLObject
                   select busDoBoAdapter(item); //return adapter 
        }
        public bool isBusExisting(int liscenceNumber)
        {
            bool flag;
            try
            {
                flag = dl.isBusExisting(liscenceNumber);// search in dl.isbusexist if this IDbus corespond to any bus
            }
            catch (BO.BLExeption ex)
            {

                throw new BO.BLExeption(ex.Message);
            }
            return flag;
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
            return lineBO;
        }
        DO.Line lineBoDoAdapter(BO.Line lineBO)
        {
            //adapt the property one by one
            DO.Line lineDO = new DO.Line();
            lineDO.Area = (DO.Areas)lineBO.Area;
            lineDO.Code = lineBO.Code;
            lineDO.FirstStation = lineBO.FirstStation;
            lineDO.LastStation = lineBO.LastStation;
            return lineDO;
        }
        public void addLine(BO.Line line)
        {
            //create DO line
            DO.Line lineDO = new DO.Line();
            line.CopyPropertiesTo(lineDO);
            try
            {
                dl.addLine(lineDO);//use dl.addLine of DLObject
            }
            catch (BO.BLExeption ex)//if there is an error in the add we display the error here
            {
                throw new BO.BLExeption(ex.Message);
            }
        }
        public void updateLine(Line line)
        {
            //create DO line
            DO.Line lineDO = new DO.Line();
            line.CopyPropertiesTo(lineDO);
            try
            {
                dl.updateLine(lineDO);//use dl.updateline of DLObject
            }
            catch (BO.BLExeption ex)//if there is an error in the update we display the error here
            {
                throw new BO.BLExeption(ex.Message);
            }
        }
        public void removeLine(int id)
        {
            try
            {
                dl.removeLine(id); //try to remove with dl.removeline from DLObject
            }
            catch (BO.BLExeption ex)//if there is an error in the remove we display the error here
            {
                throw new BO.BLExeption(ex.Message);
            }
        }
        public IEnumerable<BO.Line> searchLine(string item)
        {
            IEnumerable<BO.Line> lst = null;
            try
            {
                lst = from line in dl.searchLine(item) //search all line that code start with item
                      select lineDoBoAdapter(line);
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }
            return lst;
        }
        public Line getLine(int id)
        {
            DO.Line lineDO = new DO.Line();//create DO line
            try
            {
                lineDO = dl.getLine(id);//use dl.getline of DLObject
            }
            catch (BO.BLExeption ex)//if there is an error in the getline we display the error here
            {
                throw new BO.BLExeption(ex.Message);
            }
            return lineDoBoAdapter(lineDO);
        }
        public IEnumerable<BO.Line> getAllLine()
        {
            return from item in dl.getAllLine()//search line in de.getallline of dlobject
                   select lineDoBoAdapter(item);//select adapt line
        }
        public bool isLineExisting(BO.Line line)
        {
            //create DO line
            DO.Line lineDO = new DO.Line();
            line.CopyPropertiesTo(lineDO);
            bool flag;
            try
            {
                flag = dl.isLineExisting(lineDO);
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }
            return flag;
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
        DO.Station stationBoDoAdapter(BO.Station stationBO)
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
            catch (BO.BLExeption ex)//if there is an error from add we display error here
            {
                throw new BO.BLExeption(ex.Message);
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
            catch (BO.BLExeption ex)//if there is an exeption from update we display error here
            {
                throw new BO.BLExeption(ex.Message);
            }
        }
        public void removeStation(int id)
        {
            try
            {
                dl.removeStation(id);//try dl.remove from dlobject
            }
            catch (BO.BLExeption ex)//if there is an exeption from remove we display error here
            {
                throw new BO.BLExeption(ex.Message);
            }
        }
        /// <summary>
        /// search all station that code start with item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IEnumerable<BO.Station> searchStation(string item)
        {
            IEnumerable<BO.Station> lst = null;
            try
            {
                lst = from station in dl.searchStation(item)
                      select stationDoBoAdapter(station);
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }
            return lst;
        }
        public Station getStation(int id)
        {
            DO.Station stationDO = new DO.Station();//create do station
            try
            {
                stationDO = dl.getStation(id);//try dl.getstation from dlobject
            }
            catch (BO.BLExeption ex)//if there is an exeption from get we display error here
            {
                throw new BO.BLExeption(ex.Message);
            }
            return stationDoBoAdapter(stationDO);//return adapter station DO
        }
        public IEnumerable<Station> getAllStation()
        {
            return from item in dl.getAllStation()//search station in getallstation 
                   select stationDoBoAdapter(item);//select station adapter
        }
        /// <summary>
        /// get all line of specific station
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        public IEnumerable<BO.Line> getLineOfStation(Station station)
        {
            IEnumerable<BO.Line> lst = null;
            try
            {
                lst = from item in dl.getLineOfStation(stationBoDoAdapter(station))
                      select lineDoBoAdapter(item);
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }
            return lst;
        }
        public bool isStationExisting(int code)
        {
            return dl.isStationExisting(code);//if station witht this code return true
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
            IEnumerable<BO.AdjacentStations> lst = null;
            try
            {
                lst = from item in dl.getAllAdjacentStation()//search station in getadjacent station
                      select AdjacentStationDoBoAdapter(item);//select station adapter
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }
            return lst;
        }
        public void removeAdjacentStation(int id)
        {
            try
            {
                dl.removeAdjacentStation(id);//try dl.removeAdjacentStation from dlobject

            }
            catch (BO.BLExeption ex)//if there is an exeption from remove we diplay error here
            {
                throw new BO.BLExeption(ex.Message);
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
            catch (BO.BLExeption ex)//if there is an error from update we display error here
            {
                throw new BO.BLExeption(ex.Message);
            }
        }
        public BO.AdjacentStations getAdjacentStations(int id)
        {
            DO.AdjacentStations AdjacentStationsDO = new DO.AdjacentStations();//create adjacen station OD
            AdjacentStationsDO = dl.getAdjacentStations(id);//get station with his id
            AdjacentStations adj;
            try
            {
                adj = AdjacentStationDoBoAdapter(AdjacentStationsDO);//return this station adapt
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }
            return adj;
        }
        public void addAdjacentStation(int station1, int station2)
        {
            try
            {
                dl.addAdjacentStation(station1, station2);//to add a new adjacent station
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }

        }
        public IEnumerable<BO.Station> GetAdjacentStationsOfStation(BO.Station station)
        {
            DO.Station stationDO = new DO.Station();//create do station
            station.CopyPropertiesTo(stationDO);//copy property from BO to DO
            IEnumerable<BO.Station> lst = null;
            try
            {
                lst = from item in dl.GetAdjacentStationsOfStation(stationDO)
                      select stationDoBoAdapter(item);
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }
            return lst;
        }
        #endregion

        #region user
        public bool getUser(string username)
        {
            return dl.getUser(username);//get the password to verif it
        }
        public bool getLogin(string mail, string password)
        {
            return dl.getLogin(mail, password);
        }

        public void addUser(string name, string password)
        {
            dl.addUser(name, password);
        }
        public void SignIn(string mail)
        {
            try
            {
                dl.SignIn(mail);
            }
            catch (BLExeption ex)
            {
                throw new BLExeption(ex.Message);
            }
        }

        #endregion

        #region line station
        /// <summary>
        /// from bo to do
        /// </summary>
        /// <param name="lineStationBO"></param>
        /// <returns></returns>
        DO.LineStation lineStationBoDoAdapter(BO.LineStation lineStationBO)
        {
            DO.LineStation LineStationDO = new DO.LineStation();
            lineStationBO.CopyPropertiesTo(LineStationDO);
            return LineStationDO;
        }
        /// <summary>
        /// from do to bo
        /// </summary>
        /// <param name="lineStationDO"></param>
        /// <returns></returns>
        BO.LineStation lineStationDoBoAdapter(DO.LineStation lineStationDO)
        {
            BO.LineStation LineStationBO = new BO.LineStation();
            lineStationDO.CopyPropertiesTo(LineStationBO);
            return LineStationBO;
        }
        public IEnumerable<LineStation> getAllLineStation()
        {
            try
            {
                return from item in  dl.getAllLineStation()
                       select lineStationDoBoAdapter(item);
            }
            catch (BLExeption ex)
            {

                throw new BLExeption(ex.Message);
            }
        }
        /// <summary>
        /// add line station
        /// </summary>
        /// <param name="lineStation"></param>
        public void AddLineStation(BO.LineStation lineStation)
        {
            try
            {
                dl.AddLineStation(lineStationBoDoAdapter(lineStation));
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }

        }
        /// <summary>
        /// update line station
        /// </summary>
        /// <param name="lineStation"></param>
        public void updateLineStation(BO.LineStation lineStation)
        {
            try
            {
                dl.updateLineStation(lineStationBoDoAdapter(lineStation));
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }

        }
        /// <summary>
        /// remove line station
        /// </summary>
        /// <param name="id"></param>
        public void removeLineStation(int id)
        {
            try
            {
                dl.removeLineStation(id);
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }

        }
        /// <summary>
        /// get line station with his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BO.LineStation getLineStation(int id)
        {
            BO.LineStation linestation;
            try
            {
                linestation = lineStationDoBoAdapter(dl.getLineStation(id));
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }
            return linestation;

        }
        /// <summary>
        /// get all line station from specific line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public IEnumerable<BO.LineStation> GetLineStationsFromLine(BO.Line line)
        {
            IEnumerable<BO.LineStation> lst;
            try
            {
                lst = from item in dl.GetLineStationsFromLine(lineBoDoAdapter(line))
                      select lineStationDoBoAdapter(item);
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }
            return lst;
        }
        /// <summary>
        /// return true if this line station exist
        /// </summary>
        /// <param name="lineStation"></param>
        /// <returns></returns>
        public bool isLineStationExisting(BO.LineStation lineStation)
        {
            return dl.isLineStationExisting(lineStationBoDoAdapter(lineStation));
        }
        /// <summary>
        /// remove all station if you remove line
        /// </summary>
        /// <param name="id"></param>
        public void removeAllLineStationOfLine(int id)
        {
            dl.removeAllLineStationOfLine(id);
        }
        /// <summary>
        /// checks if all line stations are deleted after deleting the line due to a bug where if the user turns off the program before adding a line line stations were added anyway
        /// </summary>
        public void verif()
        {
            dl.verif();
        }



        #endregion

        #region line trip
        DO.LineTrip LineTripBoDoAdapter(BO.LineTrip LineTripBO)
        {
            DO.LineTrip LineTripDO = new DO.LineTrip();
            LineTripBO.CopyPropertiesTo(LineTripDO);
            return LineTripDO;
        }
        BO.LineTrip LineTripDoBoAdapter(DO.LineTrip LineTripDO)
        {
            BO.LineTrip LineTripBO = new BO.LineTrip();
            LineTripDO.CopyPropertiesTo(LineTripBO);
            return LineTripBO;
        }
        public TimeSpan getTime(BO.Line line)
        {
            return dl.getTime(lineBoDoAdapter(line));
        }

        public void addLineTrip(int id)
        {
            try
            {
                dl.addLineTrip(id);
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }
        }

        public void updateLineTrip(LineTrip LineTrip)
        {
            try
            {
                dl.updateLineTrip(LineTripBoDoAdapter(LineTrip));
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }
        }

        public void removeLineTrip(int id)
        {
            try
            {
                dl.removeLineTrip(id);
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }
        }

        public LineTrip getLineTrip(int id)
        {
            try
            {
                return LineTripDoBoAdapter(dl.getLineTrip(id));
            }
            catch (BO.BLExeption ex)
            {
                throw new BO.BLExeption(ex.Message);
            }
        }

        #endregion

        #region simulation
        public void startSimulator(TimeSpan startTime, int rate, Action<TimeSpan> updateTime)
        {

            clock simulator = clock.Instance;
            simulator.rate = rate;
            simulator.stopWatch.Restart();
            simulator.ClockObserver += updateTime;
            while (simulator.cancel == true)
            {
                simulator.Time = startTime + new TimeSpan(simulator.stopWatch.ElapsedTicks * simulator.rate);
                if (simulator.Time.Hours == 23 && simulator.Time.Minutes == 59 && simulator.Time.Seconds == 59)
                    simulator.Time = new TimeSpan(0, 0, 0);
                Thread.Sleep(100);
            }
        }
        public void stopSimulator()
        {
            clock.Instance.stopWatch.Stop();
            clock.Instance.cancel = true;
        }
        #endregion
        #region departure line
        public IEnumerable<DepartureLine> listLineOfstationForsimu(BO.Station station,TimeSpan time)
        {
            List<DO.LineStation> listLine = new List<DO.LineStation>();
            List<TimeSpan> listTimeBefore = new List<TimeSpan>();
            foreach(var item in dl.getAllLineStation())
            {
                if (item.Station == station.Code)
                    listLine.Add(item);
            }
            List<DO.LineStation> listLineStation;
            foreach (var item in listLine)
            {
                listLineStation = new List<DO.LineStation>();
                for(int i=0;i<item.LineStationIndex;i++)
                {
                    foreach (var item1 in dl.getAllLineStation())
                        if (item1.LineStationIndex == i && item1.LineId == item.LineId)
                            listLineStation.Add(item1);
                }
                int j = 0;
                List<DO.AdjacentStations> listAdjStat = new List<DO.AdjacentStations>();
                foreach(var item2 in dl.getAllAdjacentStation())
                {
                    if (j == listLineStation.Count()-1 || j == listLineStation.Count())
                        break;
                    if (item2.Station1 == listLineStation[j].Station && item2.Station2 == listLineStation[j + 1].Station)
                    {
                        listAdjStat.Add(item2);
                        j++;
                    }
                }
                TimeSpan t = new TimeSpan();
                foreach (var item3 in listAdjStat)
                    t += item3.Time;
                listTimeBefore.Add(t);
            }

             List<DepartureLine> lst1 = new List<DepartureLine>();
            int k = 0;
            foreach(var item in listLine)
            {
                TimeSpan value = dl.getLineTrip(item.LineId).Frequency;
                TimeSpan time1 = dl.getLineTrip(item.LineId).StartAt + listTimeBefore[k];
                if (time >= dl.getLineTrip(item.LineId).StartAt && time <= dl.getLineTrip(item.LineId).FinishAt)
                    time1 = dl.getLineTrip(item.LineId).StartAt - time + listTimeBefore[k];
                while (time >= time1)
                    time1 += value;
                time1 -= time;
                lst1.Add(new DepartureLine
                {
                    Id = item.LineId,
                    nameLasStation = dl.getStation(int.Parse(dl.getLine(item.LineId).LastStation)).Name,
                    Frequency = dl.getLineTrip(item.LineId).Frequency,
                    Time = new TimeSpan(time1.Hours,time1.Minutes,time1.Seconds),
                });
            }
            return lst1;
        }

       
        #endregion
    }
}
