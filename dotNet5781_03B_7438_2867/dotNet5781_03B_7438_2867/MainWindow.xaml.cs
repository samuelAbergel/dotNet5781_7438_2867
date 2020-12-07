using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace dotNet5781_03B_7438_2867
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListBuses listBuses;
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            listBuses = ListBuses.GetListBuses();
            busList.ItemsSource = listBuses.listBuses;
            busList.DataContext = listBuses.listBuses;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            busWindows wnd = new busWindows();
            wnd.Show();
        }

        private void BtnTrip_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ListViewItem item = e.Source as ListViewItem;
            Bus bus = ((FrameworkElement)e.OriginalSource).DataContext as Bus;
            if ( bus.Status != Status.midwayTrough && bus.Status != Status.refueling && bus.Status != Status.inTreatment)
            {
                tripWindows wnd = new tripWindows(bus);
                wnd.ShowDialog();
            }
            else
            {
                MessageBox.Show("you cannot travel because of your statue");
            }
            if (bus.Gasol - bus.GasolTrip >= 0 && bus.LastMaintenanceMileage + bus.GasolTrip <= 20000)
            {
                btn.IsEnabled = false;
                trip(bus, hour(bus.GasolTrip), btn);
            }
            else if (bus.Gasol - bus.GasolTrip < 0)
                MessageBox.Show("you cannot travel because of your gasoline ");
            else if (bus.LastMaintenanceMileage + bus.GasolTrip > 20000)
                MessageBox.Show("you cannot travel because of your mileage ");
            else
                MessageBox.Show("ERROR");
        }
        private int hour(int time)
        {
            int rnd1 = rnd.Next(20, 50);
            int result = (time / rnd1)*1000*6;
            if (result == 0)
                return 1000;
            return result;
        }
        private void trip(Bus bus, int time, Button btn)
        {
            List<Object> lst = new List<object> { bus, time, btn };
            BackgroundWorker trip = new BackgroundWorker();
            trip.DoWork += trip_DoWork;
            trip.RunWorkerCompleted += trip_RunWorkerCompleted;
            btn.Background = Brushes.LawnGreen;
            trip.RunWorkerAsync(lst);
        }


        private void trip_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Object> lst = (List<object>)e.Result;
            Button btn = lst[2] as Button;
            btn.IsEnabled = true;
            btn.Background = Brushes.MintCream;
            Bus bus1 = lst[0] as Bus;
            bus1.Status = Status.ReadyToGo;           
        }

        private void trip_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Object> lst = (List<object>)e.Argument;
            Bus bus = lst[0] as Bus;
            bus.Gasol -= bus.GasolTrip;
            bus.LastMaintenanceMileage += bus.GasolTrip;
            bus.Mileage += bus.GasolTrip;
            bus.GasolTrip = 0;
            int value = (int)lst[1];
            bus.Status = Status.midwayTrough;
            Thread.Sleep(value);
            e.Result = lst;
        }

        private void Btntid_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Bus bus = ((FrameworkElement)e.OriginalSource).DataContext as Bus;
            if (bus.Status != Status.refueling && bus.Status != Status.midwayTrough && bus.Status != Status.inTreatment)
            {
                btn.IsEnabled = false;
                Tid(bus, 12000, btn);
            }
            else
                MessageBox.Show("this is not possible at the moment");

        }

        private void Tid(Bus bus, int time, Button btn)
        {
            List<Object> lst = new List<object> { bus, time, btn };
            BackgroundWorker tid = new BackgroundWorker();
            tid.DoWork += tid_DoWork;
            tid.RunWorkerCompleted += tid_RunWorkerCompleted;
            btn.Background = Brushes.LawnGreen;
            tid.RunWorkerAsync(lst);
        }

        private void tid_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Object> lst = (List<object>)e.Result;
            Bus bus1 = lst[0] as Bus;
            bus1.Gasol = 1200;
            bus1.Status = Status.ReadyToGo;
            Button btn = lst[2] as Button;
            btn.IsEnabled = true;
            btn.Background = Brushes.MintCream;
        }

        private void tid_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Object> lst = (List<object>)e.Argument;
            Bus bus = lst[0] as Bus;
            int value = (int)lst[1];
            bus.Status = Status.refueling;
            Thread.Sleep(value);
            e.Result = lst;
        }

        private void busList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Bus bus = ((FrameworkElement)e.OriginalSource).DataContext as Bus;

            if (bus != null)
            {
                informationWindows wnd = new informationWindows(bus);
                wnd.ShowDialog();
            }
        }

    }
}
