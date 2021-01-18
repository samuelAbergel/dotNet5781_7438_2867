using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLAPI
{
    public interface IDL
    {
        //CRUD Logic:
        // Create - add new instance
        // Request - ask for an instance or for a collection
        // Update - update properties of an instance
        // Delete - delete an instance
        #region bus
        void addBus(Bus bus);
        void updateBus(Bus bus);
        void removeBus(int id);
        IEnumerable<Bus> searchBus(string item);
        /// <summary>
        /// get bus with his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Bus GetBus(int id);
        /// <summary>
        /// refill gasoline
        /// </summary>
        /// <param name="fuel"></param>
        /// <param name="bus"></param>
        void refuelling(int fuel,Bus bus);
        /// <summary>
        /// treat a bus
        /// </summary>
        /// <param name="bus"></param>
        void treatment(Bus bus);
        IEnumerable<Bus> GetAllBus();
        bool isBusExisting(int liscenceNumber);
        #endregion

        #region station
        void addStation(Station station);
        void updateStation(Station station);
        void removeStation(int id);
        Station getStation(int id);
        IEnumerable<Station> searchStation(string item);
        IEnumerable<Station> getAllStation();
        IEnumerable<Line> getLineOfStation(Station station);
        bool isStationExisting(int code);
        #endregion

        #region line
        void addLine(Line line);
        void updateLine(Line line);
        void removeLine(int id);
        Line getLine(int id);
        IEnumerable<Line> searchLine(string item);
        IEnumerable<Line> getAllLine();
        IEnumerable<Station> getStationOfLine(Line line);
        bool isLineExisting(Line line);
        #endregion

        #region adjacent station
        IEnumerable<AdjacentStations> getAdjacentStation();
        IEnumerable<Station> GetAdjacentStationsOfStation(Station station);
        void addAdjacentStation(AdjacentStations adjacentStations);
        void removeAdjacentStation(int id);
        void updateAdjacentStation(AdjacentStations adjacentStations);
        AdjacentStations getAdjacentStations(int id);
        #endregion
    }
}
