using dotNet5781_03B_7438_2867;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace dotNet5781_03B_7438_2867
{
    public class Bus : INotifyPropertyChanged
    {
        static Random rnd = new Random();
        //field

        private string registration;   
        private DateTime startDate;       
        private Status status;
        private int gasol;            
        private int mileage = 0;
        private DateTime maintenanceDate;
        private int lastMaintenanceMileage = 0;

        private string startDateString;
        public string StartDateString { get => startDate.ToShortDateString(); set => startDateString = value; }
        private int gasolTrip = 0;
        public int GasolTrip { get => gasolTrip; set => gasolTrip = value; }
        //constructor

        public Bus()
        {
            this.startDate = RandomDay();
            this.status = Status.ReadyToGo;
            this.Mileage = 0;
            this.Gasol = 1200;
            this.registration = rnd.Next(1000000, 99999999).ToString();
            this.lastMaintenanceMileage = rnd.Next(20000);
            this.maintenanceDate = RandomDay();

        }
        //propertys
        public Status Status
        {
            get => status;
            set { status = value; OnPropertyChanged("Status"); }
        }

        public int Gasol
        {
            get => gasol;

            set { gasol = value; OnPropertyChanged("Gasol"); }
        }
        public int Mileage
        {
            get => mileage;
            set => mileage = value;
        }
        public DateTime StartDate
        {
            get => startDate;
            set { startDate = value; OnPropertyChanged("StartDate"); }
        }
                public string REGISTRATION
        {
            get => registration;
            set => registration = value;
        }
        public string Registration
        {
            get
            {
                string prefix, middle, suffix;
                //if (startDate.Year >= 2018)
                //    registration += rnd.Next(9).ToString();
                if (registration.Length == 7)
                {
                    // xx-xxx-xx
                    prefix = registration.Substring(0, 2);
                    middle = registration.Substring(2, 3);
                    suffix = registration.Substring(5, 2);
                    return registration = String.Format("{0}-{1}-{2}", prefix, middle, suffix);
                }
                else if (registration.Length == 8)
                {
                    // xxx-xx-xxx
                    prefix = registration.Substring(0, 3);
                    middle = registration.Substring(3, 2);
                    suffix = registration.Substring(5, 3);
                    return registration = String.Format("{0}-{1}-{2}", prefix, middle, suffix);
                }
                else if (registration.Length == 9 || registration.Length == 10)
                    return registration;
                else
                {
                    throw new Exception("taarich lo takin");
                }
            }
            set
            {
               registration = value;
               OnPropertyChanged("Registration");
            }
        }
        // field ans propertys of maintenance
        private string maintenanceDateString;
        public DateTime MaintenanceDate { get => maintenanceDate; set { maintenanceDate = value; OnPropertyChanged("MaintenanceDate"); } }
        public string MaintenanceDateString { get => maintenanceDate.ToShortDateString(); set => maintenanceDateString = value;}
        public int LastMaintenanceMileage { get => lastMaintenanceMileage; set { lastMaintenanceMileage = value; OnPropertyChanged("LastMaintenanceMileage"); } }

        //fonction random        
        static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(rnd.Next(3));
        }
        private DateTime RandomDay()
        {
            // random between 1 january 1995 and now
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rnd.Next(range));
        }

        //to string
        public override string ToString()
        {
            return String.Format("[ status: {0} , registration: {1} , startDate: {2} , gasol: {3}]", this.status.ToString(), REGISTRATION, startDate.ToShortDateString(),Gasol.ToString());
        }
        //inotifypropertuchanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(string.Empty));
            }
        }
    }
}
