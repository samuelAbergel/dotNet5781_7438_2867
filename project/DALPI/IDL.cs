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
        #endregion

        #region station
        void addStation(Station station);
        void updateStation(Station station);
        void removeStation(int id);
        Station getStation(int id);
        IEnumerable<Station> getAllStation();
        IEnumerable<Line> getLineOfStation(Station station);
        #endregion

        #region line
        void addLine(Line line);
        void updateLine(Line line);
        void removeLine(int id);
        Line getLine(int id);
        IEnumerable<Line> getAllLine();
        IEnumerable<Station> getStationOfLine(Line line);
        #endregion

        #region adjacent station
        IEnumerable<AdjacentStations> getAdjacentStation();
        void addAdjacentStation(AdjacentStations adjacentStations);
        void removeAdjacentStation(int id);
        void updateAdjacentStation(AdjacentStations adjacentStations);
        AdjacentStations getAdjacentStations(int id);
        #endregion
    }
}
