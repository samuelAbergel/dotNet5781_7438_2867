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
        #region bus
        void addBus(Bus bus);
        void updateBus(Bus bus);
        void removeBus(int id);
        Bus GetBus(int id);
        void refuelling(int fuel,Bus bus);
        void treatment(Bus bus);
        IEnumerable<Bus> GetAllBus();
        #endregion

        #region station
        void addStation(Station station);
        void updateStation(Station station);
        void removeStation(int id);
        Station getStation(int id);
        IEnumerable<Station> getAllStation();
        #endregion

        #region line
        void addLine(Line line);
        void updateLine(Line line);
        void removeLine(int id);
        Line getLine(int id);
        IEnumerable<Line> getAllLine();
        IEnumerable<AdjacentStations> getStationOfLine(Line line);
        #endregion

    }
}
