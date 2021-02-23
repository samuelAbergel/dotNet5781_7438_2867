using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO
{
    class LineStationPO : INotifyPropertyChanged
    {
        BO.LineStation lineStation;
        public LineStationPO(BO.LineStation lineStation)
        {
            this.lineStation = lineStation;
            this.LineId = lineStation.LineId;
            this.Station = lineStation.Station;
            this.LineStationIndex = lineStation.LineStationIndex;
            this.ID = lineStation.id;
        }
        public BO.LineStation getLineStation()
        {
            return lineStation;
        }
        public int ID
        {
            get => lineStation.id;
            set
            {
                lineStation.id = value;
                RaisePropertyChanged("id");
            }
        }
        public int LineId {
            get => lineStation.LineId;
            set
            {
                lineStation.LineId = value;
                RaisePropertyChanged("LineId");
            }
        }
        public int Station
        {
            get => lineStation.Station;
            set
            {
                lineStation.Station = value;
                RaisePropertyChanged("Station");
            }
        }
        public int LineStationIndex
        {
            get => lineStation.LineStationIndex;
            set
            {
                lineStation.LineStationIndex = value;
                RaisePropertyChanged("LineStationIndex");
            }
        }
        protected void RaisePropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
