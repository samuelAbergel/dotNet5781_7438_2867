using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLAPI
{
    public interface IBL
    {
        //CRUD Logic:
        // Create - add new instance
        // Request - ask for an instance or for a collection
        // Update - update properties of an instance
        // Delete - delete an instance
        #region bus
        void addBus(BO.Bus bus);
        void updateBus(BO.Bus bus);
        void removeBus(int id);
        IEnumerable<BO.Bus> searchBus(string item);
        void refuelling(int fuel, BO.Bus bus);
        void treatment(BO.Bus bus);
        BO.Bus GetBus(int id);
        IEnumerable<BO.Bus> GetAllBus();
        bool isBusExisting(int liscenceNumber);
        #endregion

        #region station
        void addStation(BO.Station station);
        void updateStation(BO.Station station);
        void removeStation(int id);
        IEnumerable<BO.Station> searchStation(string item);
        BO.Station getStation(int id);
        IEnumerable<BO.Station> getAllStation();
        bool isStationExisting(int code);
        #endregion

        #region line
        void addLine(BO.Line line);
        void updateLine(BO.Line line);
        void removeLine(int id);
        BO.Line getLine(int id);
        IEnumerable<BO.Line> searchLine(string item);
        IEnumerable<BO.Line> getAllLine();
        bool isLineExisting(BO.Line line);
        #endregion

        #region adjacent station
        void addAdjacentStation(int station1, int station2);
        IEnumerable<BO.AdjacentStations> getAdjacentStation();
        void removeAdjacentStation(int id);
        void updateAdjacentStation(BO.AdjacentStations adjacentStations);
        BO.AdjacentStations getAdjacentStations(int id);
        IEnumerable<BO.Line> getLineOfStation(BO.Station station);
        IEnumerable<BO.Station> GetAdjacentStationsOfStation(BO.Station station);
        TimeSpan getTime(BO.Line line);
        #endregion

        #region user
        bool getUser(string username);
        bool getLogin(string mail, string password);
        void addUser(string name, string password);
        void SignIn(string mail);

        #endregion

        #region linestation
        void AddLineStation(BO.LineStation lineStation);
        void updateLineStation(BO.LineStation lineStation);
        void removeLineStation(int id);
        BO.LineStation getLineStation(int id);
        IEnumerable<BO.LineStation> GetLineStationsFromLine(BO.Line line);
        void removeAllLineStationOfLine(int id);
        bool isLineStationExisting(BO.LineStation lineStation);
        IEnumerable<BO.LineStation> getAllLineStation();

        void verif();
        #endregion

        #region line trip
        void addLineTrip(int id);
        void updateLineTrip(BO.LineTrip LineTrip);
        void removeLineTrip(int id);
        BO.LineTrip getLineTrip(int id);
        #endregion

        #region simulation
        void startSimulator(TimeSpan startTime, int rate, Action<TimeSpan> updateTime);
        void stopSimulator();
        IEnumerable<BO.DepartureLine> listLineOfstationForsimu(BO.Station station, TimeSpan time);
        #endregion
    }
}
