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
            myBus.Gasol = 1200;
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
