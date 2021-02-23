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
        /// <summary>
        /// to verif is specific bus exist
        /// </summary>
        /// <param name="liscenceNumber"></param>
        /// <returns></returns>
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
        bool isLineExisting(Line line);
        #endregion

        #region adjacent station
        IEnumerable<AdjacentStations> getAllAdjacentStation();
        IEnumerable<Station> GetAdjacentStationsOfStation(Station station);
        void addAdjacentStation(int station1,int station2);
        void removeAdjacentStation(int id);
        void updateAdjacentStation(AdjacentStations adjacentStations);
        AdjacentStations getAdjacentStations(int id);
        TimeSpan getTime(Line line);
        #endregion

        #region line station
        void AddLineStation(LineStation lineStation);
        void updateLineStation(LineStation lineStation);
        void removeLineStation(int id);
        IEnumerable<LineStation> getAllLineStation();
        LineStation getLineStation(int id);
        /// <summary>
        /// get line stations from a specific line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        IEnumerable<LineStation> GetLineStationsFromLine(Line line);
        void removeAllLineStationOfLine(int id);
        /// <summary>
        /// to verif if this line station exist
        /// </summary>
        /// <param name="lineStation"></param>
        /// <returns></returns>
        bool isLineStationExisting(LineStation lineStation);
        /// <summary>
        /// checks if all line stations are deleted after deleting the line due to a bug where if the user turns off the program before adding a line line stations were added anyway
        /// </summary>
        void verif();
        #endregion

        #region user
        bool getUser(string username);

        bool getLogin(string mail, string password);
        void addUser(string name, string password);
        void SignIn(string mail);
        #endregion

        #region line timing
        void addLineTrip(int id);
        void updateLineTrip(LineTrip LineTrip);
        void removeLineTrip(int id);
        LineTrip getLineTrip(int id);
        #endregion
    }
}
