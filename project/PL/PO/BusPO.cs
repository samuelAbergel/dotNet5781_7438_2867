using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace PL.PO
{
    class BusPO : INotifyPropertyChanged
    {
        Bus bus;
        public BusPO(Bus bus)
        {
            this.bus = bus;
            this.LicenseNum = bus.LicenseNum;
            this.FromDate = bus.FromDate;
            this.FuelRemain = bus.FuelRemain;
            this.refuel = bus.refuel;
            this.Status = bus.Status;
            this.TotalTrip = bus.TotalTrip;
          
        }
        public Bus getBus()
        {
            return bus;
        }
        public int LicenseNum 
        {
            get => bus.LicenseNum;
            set
            {

                if (value != bus.LicenseNum)
                {
                    bus.LicenseNum = value;
                    RaisePropertyChanged("LicenseNum");
                }
            }
        }

        protected void RaisePropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public DateTime FromDate { get ; set; }
        public double TotalTrip { get; set; }
        public double FuelRemain { get => bus.FuelRemain; 
            set
            {
                if (value != bus.FuelRemain)
                {
                    bus.FuelRemain = value;
                    RaisePropertyChanged("FuelRemain");
                }
            }
          }
        public int refuel { get; set; }
        public BusStatus Status { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
