using BLAPI;
using System;
using System.Collections.Generic;
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

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour InformationStationWindow.xaml
    /// </summary>
    public partial class InformationStationWindow : Window
    {
        IBL bl;// create instance of IBL
        BO.Station station;
        IEnumerable<BO.Line> lineList;
        IEnumerable<BO.Station> listStation;
        public InformationStationWindow(int stationId, IBL bl)
        {
            InitializeComponent();
            this.bl = bl;
            Update(stationId);
            this.DataContext = station;//match datacontext and station

        }

        private void Update(int stationId)
        {
            try
            {
             station = bl.getStation(stationId);//use getstation of blimp and put in station
             lineList = bl.getLineOfStation(station);//search all linne of station
             lineBox.ItemsSource = lineList;
             lineBox.DisplayMemberPath = "Code";
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            listStation = bl.GetAdjacentStationsOfStation(station);//and get adjacent station of this station
            if (listStation != null)//if there are adj station
            {
                adjBox.ItemsSource = listStation;
                adjBox.DisplayMemberPath = "Code";
            }
            else
                adjBox.IsEnabled = false;

        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
