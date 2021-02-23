using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.PO
{
    class StationPO : INotifyPropertyChanged
    {
        Station station;
        public StationPO(Station station)
        {
            this.station = station;
            this.Code = station.Code;
            this.Lattitude = station.Lattitude;
            this.Longitude = station.Longitude;
            this.Name = station.Name;
        }
        public Station getStation()
        {
            return station;
        }
        public int Code
        {
            get => station.Code;
            set
            {
                station.Code = value;
                RaisePropertyChanged("Code");
            }
        }
        public string Name
        {
            get => station.Name;
            set
            {
                station.Name = value;
                RaisePropertyChanged("Name");
            }
        }
        public string Longitude
        {
            get => station.Longitude;
            set
            {
                station.Longitude = value;
                RaisePropertyChanged("Longitude");
            }
        }
        public string Lattitude
        {
            get => station.Lattitude;
            set
            {
                station.Lattitude = value;
                RaisePropertyChanged("Lattitude");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
