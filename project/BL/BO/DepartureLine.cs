using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class DepartureLine: INotifyPropertyChanged
    {
        public DepartureLine(DepartureLine departure)
        {
            this.Frequency = departure.frequency;
            this.Id = departure.Id;
            this.nameLasStation = departure.nameLasStation;
            this.Time = departure.Time;
        }
        public DepartureLine()
        {

        }
        private int id;
        private TimeSpan time;
        private TimeSpan frequency;
        private string namelaststation;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }
        public TimeSpan Time
        {
            get => time;
            set
            {
                time = value;
                RaisePropertyChanged("Time");
            }
        }
        public TimeSpan Frequency
        {
            get => frequency;
            set
            {
                frequency = value;
                RaisePropertyChanged("Frequency");
            }
        }
        public string nameLasStation
        {
            get => namelaststation;
            set
            {
                namelaststation = value;
                RaisePropertyChanged("nameLastStation");
            }
        }
        protected void RaisePropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
