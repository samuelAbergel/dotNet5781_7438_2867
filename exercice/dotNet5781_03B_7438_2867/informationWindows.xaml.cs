using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace dotNet5781_03B_7438_2867
{
    /// <summary>
    /// Logique d'interaction pour informationWindows.xaml
    /// </summary>
    public partial class informationWindows : Window
    {
        Bus myBus;
        public informationWindows(Bus bus)
        {
            InitializeComponent();
            myBus = bus;
            this.DataContext = bus;
        }

        private void BtnRefuelling_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Bus bus = ((FrameworkElement)e.OriginalSource).DataContext as Bus; // bus of row selected
            if (bus.Status != Status.refueling && bus.Status != Status.midwayTrough && bus.Status != Status.inTreatment) //if the status is suitable
            {
                btn.IsEnabled = false; // now you can't click
                Tid(bus, 12000, btn); // 12000 = 12 sec 2 hours in the exercise
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
            btn.Background = Brushes.LawnGreen; //change color of button
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

        private void BtnTreatment_Click(object sender, RoutedEventArgs e)
        {
            if (myBus.Status != Status.midwayTrough)
            {
                Button btn = sender as Button;
                btn.IsEnabled = false;
                treatment(myBus, 144000, btn);
            }
            else
                MessageBox.Show("this bus is traveling");
        }

        private void treatment(Bus bus, int time, Button btn)
        {
            List<Object> lst = new List<object> { bus, time, btn };
            BackgroundWorker treatment = new BackgroundWorker();
            treatment.DoWork += treatment_DoWork;
            treatment.RunWorkerCompleted += treatment_RunWorkerCompleted;
            btn.Background = Brushes.LawnGreen;
            treatment.RunWorkerAsync(lst);
        }

        private void treatment_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Object> lst = (List<object>)e.Result;
            Button btn = lst[2] as Button;
            Bus bus = lst[0] as Bus;
            bus.Status = Status.ReadyToGo;
            btn.IsEnabled = true;
            btn.Background = Brushes.MintCream;
        }

        private void treatment_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime date = DateTime.Today;
            List<Object> lst = (List<object>)e.Argument;
            Bus bus = lst[0] as Bus;
            int value = (int)lst[1];
            bus.LastMaintenanceMileage = 0;
            bus.MaintenanceDate = date;
            bus.Status = Status.inTreatment;
            Thread.Sleep(value);
            e.Result = lst;
        }
    }
}
