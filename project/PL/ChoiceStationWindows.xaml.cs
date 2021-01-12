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
using BO;
using PL.PO;

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour ChoiceStationWindows.xaml
    /// </summary>
    public partial class ChoiceStationWindows : Window
    {
        AdjacentStations adjacentStations;
        int index;
        public ChoiceStationWindows(AdjacentStations adjacentStations,int index)
        {
            InitializeComponent();
            this.adjacentStations = adjacentStations;
            this.index = index;
        }

        private void ButtonStation1_Click(object sender, RoutedEventArgs e)
        {
            if (index == 1)//open information of the station and close this window
            {
                InformationStationWindow wnd = new InformationStationWindow(adjacentStations.Station1);
                wnd.Show();
                this.Close();
            }
            if(index == 2)//open window of update station and close this window
            {
                UpdateStation wnd = new UpdateStation(adjacentStations.Station1);
                wnd.Show();
                this.Close();

            }
        }

        private void ButtonStation2_Click(object sender, RoutedEventArgs e)
        {
            if (index == 1)//open information of the station and close this window
            {
                InformationStationWindow wnd = new InformationStationWindow(adjacentStations.Station2);
                wnd.Show();
                this.Close();
            }
            if (index == 2)//open window of update station and close this window
            {
                UpdateStation wnd = new UpdateStation(adjacentStations.Station2);
                wnd.Show();
                this.Close();

            }
        }
    }
}
