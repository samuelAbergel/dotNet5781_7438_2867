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
        void refuelling(int fuel, BO.Bus bus);
        void treatment(BO.Bus bus);
        BO.Bus GetBus(int id);
        IEnumerable<BO.Bus> GetAllBus();
        #endregion

        #region station
        void addStation(BO.Station station);
        void updateStation(BO.Station station);
        void removeStation(int id);
        BO.Station getStation(int id);
        IEnumerable<BO.Station> getAllStation();
        #endregion

        #region line
        void addLine(BO.Line line);
        void updateLine(BO.Line line);
        void removeLine(int id);
        BO.Line getLine(int id);
        IEnumerable<BO.Line> getAllLine();
        IEnumerable<BO.Station> getStationOfLine(BO.Line line);
        #endregion

        #region adjacent station
        void addAdjacentStation(BO.AdjacentStations adjacentStations);
        IEnumerable<BO.AdjacentStations> getAdjacentStation();
        void removeAdjacentStation(int id);
        void updateAdjacentStation(BO.AdjacentStations adjacentStations);
        BO.AdjacentStations getAdjacentStations(int id);
        IEnumerable<BO.Line> getLineOfStation(BO.Station station);
        #endregion
    }
}
