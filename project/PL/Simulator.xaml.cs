using BLAPI;
using BO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour Simulator.xaml
    /// </summary>
    public partial class Simulator : Window
    {

        DispatcherTimer timer;
        Station station;
        IBL bl;
        ObservableCollection<DepartureLine> collection;
        public Simulator(BLAPI.IBL bl, BO.Station station)
        {
            InitializeComponent();
            this.bl = bl;
            this.station = station;
            SimuList.DataContext = null;
            collection = new ObservableCollection<DepartureLine>(from item in bl.listLineOfstationForsimu(station, clock.Instance.Time)
                                                                 select new DepartureLine(item));
            SimuList.DataContext = collection;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(SimuList.DataContext);
            view.SortDescriptions.Add(new SortDescription("Time", ListSortDirection.Ascending));
            collection.ToList().ForEach(item => BackToBeginning(item));
        }
        void BackToBeginning(DepartureLine objet)
        {
            timer = new DispatcherTimer();
            timer.Start();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, args) =>
            {
                 int ok = objet.Time.Subtract(TimeSpan.FromSeconds(clock.Instance.rate)).Seconds;
                if (objet.Time.Seconds <= 0 ||ok<=0)
                {
                    if (objet.Time.Minutes > 0)
                    {
                        objet.Time = objet.Time.Subtract(TimeSpan.FromMinutes(1));
                        objet.Time = objet.Time.Add(TimeSpan.FromSeconds(59));
                    }
                    else if (objet.Time.Minutes <= 0 && objet.Time.Hours > 0)
                    {
                        objet.Time = objet.Time.Subtract(TimeSpan.FromHours(1));
                        objet.Time = objet.Time.Add(TimeSpan.FromMinutes(59));
                        objet.Time = objet.Time.Add(TimeSpan.FromSeconds(59));
                    }
                    else
                        objet.Time = new TimeSpan(0, objet.Frequency.Minutes, 0);
                    this.Close();
                    Simulator wnd = new Simulator(bl, station);
                    wnd.Show();
                }
                else
                    objet.Time = objet.Time.Subtract(TimeSpan.FromSeconds(clock.Instance.rate));

            };
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
