using BLAPI;
using BO;
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

namespace PL
{
    /// <summary>
    /// main page
    /// </summary>
    public partial class MainWindow : Window
    {

        IBL bl = BLFactory.GetBL();
        DispatcherTimer dt = new DispatcherTimer();
        TimeSpan time;
        string currentTime = string.Empty;
        private BackgroundWorker worker = null;
        public MainWindow()
        {
            InitializeComponent();
            bl.verif();//checks if all line stations are deleted after deleting the line due to a bug where if the user turns off the program before adding a line line stations were added anyway
            worker = new BackgroundWorker();
            time = DateTime.Now.TimeOfDay;
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = TimeSpan.FromMilliseconds(1      );
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            if (clock.Instance.stopWatch.IsRunning)
            {
                startStopBtn.Content = "STOP";
                worker.RunWorkerAsync();
            }
            else
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
            
             bl.startSimulator(clock.Instance.startTime, clock.Instance.rate, showtimespan);

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
        private void ButtonSimu_Click(object sender, RoutedEventArgs e)
        {
            if (startStopBtn.Content.ToString() == "START")
            {
                startStopBtn.Content = "STOP";
                Time wnd = new Time(bl);
                wnd.ShowDialog();
                worker.RunWorkerAsync();
            }
            else if (startStopBtn.Content.ToString() == "STOP")
            {
                worker.CancelAsync();
                clock.Instance.cancel = false;
                startStopBtn.Content = "START";
                label1.Content = string.Empty;
            }

        }
        /// <summary>
        /// button to open the next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Opwindow wnd = new Opwindow(bl);
            wnd.Show();
            this.Close();
        }
        /// <summary>
        /// button to close all
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
             if (bl.getLogin(txtUsername.Text,txtPassword.Password))//verif password
             {
                Opwindow wnd = new Opwindow(bl);
                    wnd.Show();
                this.Close();
             }
            else
                MessageBox.Show("this password or username dosn't exist", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "bad entry", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }

        private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               Mail wnd = new Mail(bl);
               wnd.Show();
                this.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "bad entry", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox s = e.Source as TextBox;
                if (s != null)
                {
                    s.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }

                e.Handled = true;
            }
        }

    }
}
