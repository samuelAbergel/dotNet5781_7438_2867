using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace PL.PO
{
    class AdjacentStationsPO : INotifyPropertyChanged
    {
        AdjacentStations adjacentStations;
        public AdjacentStationsPO(AdjacentStations adjacentStations)
        {
            this.adjacentStations = adjacentStations;
            this.Station1 = adjacentStations.Station1;
            this.Station2 = adjacentStations.Station2;
            this.Time = adjacentStations.Time;
            this.Distance = adjacentStations.Distance;
        }
        public AdjacentStationsPO()
        {

        }
        public AdjacentStations getAdjacentStations()
        {
            return adjacentStations;
        }

        public int Station1
        {
            get => adjacentStations.Station1;
            set
            {
                adjacentStations.Station1 = value;
                RaisePropertyChanged("Station1");
            }
        }
        public int Station2
        {
            get => adjacentStations.Station2;
            set
            {
                adjacentStations.Station2 = value;
                RaisePropertyChanged("Station2");
            }
        }
        public double Distance
        {
            get => adjacentStations.Distance;
            set
            {
                adjacentStations.Distance = value;
                RaisePropertyChanged("Distance");
            }
        }
        public TimeSpan Time
        {
            get => adjacentStations.Time;
            set
            {
                adjacentStations.Time = value;
                RaisePropertyChanged("Time");
            }
        }
        protected void RaisePropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
