using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using BLAPI;
using BO;

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour simu.xaml
    /// </summary>
    public partial class simu : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        TimeSpan time;
        string currentTime = string.Empty;
        private BackgroundWorker worker = null;
        IBL bl;
        public simu(IBL bl)
        {
            InitializeComponent();
            this.bl = bl;
            worker = new BackgroundWorker();
            time = DateTime.Now.TimeOfDay;
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = TimeSpan.FromMilliseconds(100);
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            startStopBtn.Content = "START";
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Content = string.Empty;
            dt.Stop();
            clock.Instance.cancel = true;
            bl.stopSimulator();
        }

        private static void showtimespan(TimeSpan timeSpan)
        {
            MessageBox.Show((new TimeSpan(clock.Instance.Time.Hours, clock.Instance.Time.Minutes, clock.Instance.Time.Seconds)).ToString());
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            dt.Start();

            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
                clock.Instance.cancel = false;
                return;
            }
            bl.startSimulator(DateTime.Now.TimeOfDay, 10, showtimespan);
        }

        private void dt_Tick(object sender, EventArgs e)
        {
            if (clock.Instance.stopWatch.IsRunning)
            {
                TimeSpan ts = clock.Instance.Time;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Hours, ts.Minutes, ts.Seconds);
                label1.Content = currentTime;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (startStopBtn.Content.ToString() == "START")
            {
                startStopBtn.Content = "STOP";
                worker.RunWorkerAsync();
            }
            else if (startStopBtn.Content.ToString() == "STOP")
            {
                worker.CancelAsync();
                clock.Instance.cancel = false;
                startStopBtn.Content = "START";
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = new MainWindow();
            wnd.Show();
            this.Close();
        }
    }
}
