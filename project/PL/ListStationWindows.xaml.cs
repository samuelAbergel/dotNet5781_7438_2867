using BLAPI;
using PL.PO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour ListStationWindows.xaml
    /// </summary>
    public partial class ListStationWindows : Window
    {
        IBL bl;
        ObservableCollection<AdjacentStationsPO> collection;
        AdjacentStationsPO adjacentStationsPO;
        public ListStationWindows()
        {
            InitializeComponent();
            bl = BLFactory.GetBL();
            updateDataContext();
        }
        void updateDataContext()
        {
            collection = new ObservableCollection<AdjacentStationsPO>(from item in bl.getAdjacentStation()
                                                                      select new AdjacentStationsPO(item));
            StationList.DataContext = null;
            StationList.DataContext = collection;
        }

        private void ButtonPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            MainStationWindow wnd = new MainStationWindow();
            wnd.Show();
            this.Close();
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Opwindow wnd = new Opwindow();
            wnd.Show();
            this.Close();
        }

        private void StationList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AdjacentStationsPO adjacentStationsPO = ((FrameworkElement)e.OriginalSource).DataContext as AdjacentStationsPO;
            ChoiceStationWindows wnd = new ChoiceStationWindows(adjacentStationsPO.getAdjacentStations(),1);
            wnd.Show();
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            AdjacentStationsPO adjacentStationsPO = btn.DataContext as AdjacentStationsPO;
            bl.removeAdjacentStation(adjacentStationsPO.Station1);
            updateDataContext();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            AdjacentStationsPO adjacentStationsPO = btn.DataContext as AdjacentStationsPO;
            ChoiceStationWindows wnd = new ChoiceStationWindows(adjacentStationsPO.getAdjacentStations(),2);
            wnd.Show();
            updateDataContext();
        }
    }
}
