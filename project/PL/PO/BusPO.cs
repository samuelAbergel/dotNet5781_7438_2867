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

        public DateTime FromDate
        {
            get => bus.FromDate;
            set
            {
                if(value != bus.FromDate)
                {
                    bus.FromDate = value;
                    RaisePropertyChanged("FromDate");
                }
            }
        }
        public double TotalTrip
        {
            get => bus.TotalTrip;
            set
            {
                bus.TotalTrip = value;
                RaisePropertyChanged("TotalTrip");
            }
        }
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
        public BusStatus Status
        {
            get => bus.Status;
            set
            {
                bus.Status = value;
                RaisePropertyChanged("Status");
            }
        }
        public DateTime previewTreatmentDate {
            get => bus.previewTreatmentDate;
                set
            {
                bus.previewTreatmentDate = value;
                RaisePropertyChanged("previewTreatmentDate");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
