using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_03B_7438_2867
{
    public class ListBuses : IEnumerable
    {
        public ObservableCollection<Bus> listBuses;
        private static ListBuses singleton;

        public static ListBuses GetListBuses()
        {
            if (singleton == null)
                singleton = new ListBuses();

            return singleton;
        }

        private ListBuses()
        {
            listBuses = new ObservableCollection<Bus>();
            InitListBuses();
        }

        public void AddBus(Bus bus)
        {
            listBuses.Add(bus);
        }

        private void InitListBuses() // init 10 but 
        {
            Bus bus = new Bus();
            for (int i = 0; i < 10; i++)
            {
                listBuses.Add(bus);
                bus = new Bus();
            }
            listBuses[6].LastMaintenanceMileage = 125;
            listBuses[7].Gasol = 12;
            listBuses[9].Mileage = 19900;

        }

        public IEnumerator GetEnumerator()
        {
            return listBuses.GetEnumerator();
        }
    }
}
